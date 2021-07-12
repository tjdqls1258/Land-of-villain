using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Get_Item : MonoBehaviour
{   //플레이어의 아이템 정보를 가져오기 위해 필요
    Player_Item PI;
    
    //아이템의 정보를 사용하기 위해 필요.
    Item_stats IS;
    //드롭아이템을 가지고 있을 게임오브젝트
    GameObject DI;

    //돈의 정보를 사용하기 위해 필요
    Money_Stats MS;
    //던의 정보를 가지고 있을 게임오브젝트.
    GameObject DM;

    //아이템이 충돌 됬는지 체크하는 변수
    bool Item_Check = false;
    // Start is called before the first frame update
    void Start()
    {   //플레이어의 아이템 정보
        PI = GetComponent<Player_Item>();
    }

    // Update is called once per frame
    void Update()
    {

        Drop_Item();
    }
  
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Item"))
        {   //Item_stats 받아오기
            IS = coll.GetComponent<Item_stats>();
            //아이템 습득시 게임오브젝트 삭제를 위한 할당
            DI = coll.gameObject;
            //충돌을 Drop_Item에서 확인 하기 위한 변수
            Item_Check = true;
        }
        else if (coll.gameObject.CompareTag("Money"))
        {   //Money_Stats 받아오기
            MS = coll.GetComponent<Money_Stats>();
            //돈 습득시 게임오브젝트를 삭제를 위한 할당
            DM = coll.gameObject;

            //가치가 동화일 경우. 기존 소지금에 1을 더해줌
            if (MS.Get_Money_Value() == 0)
            { PI.Set_Player_Money(PI.Get_Player_Money() + 1); }
            else if (MS.Get_Money_Value() == 1)//가치가 은화일 경우. 기존 소지금에 10을 더해줌
            { PI.Set_Player_Money(PI.Get_Player_Money() + 10); }
            else if (MS.Get_Money_Value() == 2)//가치가 금화일 경우. 기존 소지금에 100을 더해줌.
            { PI.Set_Player_Money(PI.Get_Player_Money() + 100); }
            //돈 오브젝트 삭제
            Destroy(DM.gameObject);
            Debug.Log(PI.Get_Player_Money());
            //초기화
            MS = null;
            DM = null;
        }


    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Item"))
        {   //초기화
            IS = null;
            DI = null;
            Item_Check = false;
        }
    }

    //참고로 이 함수는 아이템을 드랍하는(생성하는) 코드이기 때문에 몬스터를 죽이거나,보물방에서 아이템을 드랍하는 식으로 응용할 수 있음,
    //코드를 설명하자면 N에 들어가는 내용이 아이템의 이름임.
    //Instantiate는 오브젝트를 생성하는 코드임. Instantiate(게임오브젝트,포지션,회전값)
    //현재 Instantiate(Item_Prefab에 있는 프리팹(게임오브젝트),플레이어의 위치,회전값 변경 없음)으로 만듦
    public void Creat_Drop_Item(string N)
    { Instantiate(Resources.Load("Item/Item_Prefab/" + N), transform.position, Quaternion.identity); }

    //원래는 OnTriggerstay2D로 만들려 했으나 가만히 있으면 몇 프레임 동안만 호출하여 계속 움직여 줘야하는 문제가 생겨서 아래 코드로 제작
    public void Drop_Item()
    {

        if (Item_Check == true && Input.GetKeyDown(KeyCode.D) == true)
        {   //주우려는 장비 아이템의 종류와 플레이어의 아이템의 종류가 같고 장비가 없을 시
            if (PI.Get_Player_Item(IS.Get_Item_Kind()) == "NONE")
            {
                //플레이어의 아이템의 장비에 맞춰 플레이어 장비에 이름을 할당해줌.
                PI.Set_Player_Item(IS.Get_Item_Kind(), IS.Get_Item_Name());
                Destroy(DI.gameObject);//그리고 주운 아이템 파괴 처리

            }
            else if (PI.Get_Player_Item(IS.Get_Item_Kind()) != "NONE")//플레이어가 아이템을 가지고 있었다면.
            {
                //플레이어가 가지고 있던 아이템 프리팹을 생성
                Creat_Drop_Item(PI.Get_Player_Item(IS.Get_Item_Kind()));
                //플레이어의 아이템의 장비에 맞춰 플레이어 장비에 이름을 할당해줌.
                PI.Set_Player_Item(IS.Get_Item_Kind(), IS.Get_Item_Name());
                Destroy(DI.gameObject);//그리고 주운 아이템 파괴 처리


            }

        }
    }
}
