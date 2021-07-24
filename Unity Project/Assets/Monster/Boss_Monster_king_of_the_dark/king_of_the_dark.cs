using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class king_of_the_dark : MonoBehaviour
{

    string Name = "king_of_the_dark"; //이름
    int MaxHP = 1000; //최대 체력
    int HP = 0;//체력
    //    int HP = 1000;//체력
    int ATK =0;//공격력
    int DEF = 20;//방어력
    int AGI = 5;//이동 속도
    int LUC = 0; //운(치명타)

    //추척을 위한 FSM 변수들
    private Rigidbody2D RB2D;//Rigidboy2D
    private GameObject target;//타겟이 될 게임오브젝트를 가져옴.
    private Vector2 VD;//자신의 백터 위치

    //패턴 1의 플레이어의 AGI를 저장해둠.(패턴1)
    int Save_P_AGI = 0;
    //사망시 보스에 걸맞는 돈과 아이템을 떨구기 위한 Drop_Item 클래스를 가져옴.
    Drop_Item DI = new Drop_Item();
    Drop_Money DM=new Drop_Money();
    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();//Rigidbody2D 컴포넌트를 찾아서 가져옴
        VD = Vector2.zero; //Vector2 초기화
        target = GameObject.Find("Player");//타겟을 Player라는 이름을 가진 오브젝트로 선택.
        //시작시 플레이어의 AGI를 가져옴.(패턴1)
        Save_P_AGI = target.GetComponent<Player_Stat>().Get_P_State(4);
        //시작시 플레이어의 AGI를 -5함(패턴1)
        Pattern_One();
    
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어의 HP<=0이면 실행.
        Dead();
        //플레이어 추적
        Move();
        //10초마다 하위의 적을 소환하는 패턴(패턴2)
        Pattern_Two();


    }
    //필요한 것

    //1.이동(플레이어 추척)
    public void Move()
    {

        //플레이어 추적
        VD = Seek(target.transform.position) * Time.deltaTime;
        RB2D.velocity += VD;//Rigidbody2D의 Velocity값 변경
    }
    Vector2 Seek(Vector2 TargetPos)
    {
        Vector2 DesiredVelocity = TargetPos - RB2D.position;
        DesiredVelocity.Normalize();
        DesiredVelocity *= AGI;
        return (DesiredVelocity - RB2D.velocity);
    }



    //2.패턴1(플레이어의 이동속도 5 감소) 한번만 실행되면 계속 유지되게끔. (원래는 90% 감소를 하려 했지만 플레이어의 스텟이 int인 관계로 -5를 함.)
    public void Pattern_One()
    {
        target.GetComponent<Player_Stat>().Set_P_State(4, Save_P_AGI - 5);
    }
    //3.패턴2(하위 몬스터 10초 마다 소환)
    public void Pattern_Two()
    {   //10초마다 한번씩 소환.(일단 기본적으로 시작할 때 적을 5기 배치하는 것도 구상중.)
        InvokeRepeating("Spawn_Enemy",10f, 10f);

    }
    //적을 소환하는 메소드.
    public void Spawn_Enemy()
    {
        //하위 몬스터를 만들어야함.
        //적의 위치애서 -1~1사이에 몬스터 생성.
        //Instantiate(Resources.Load("하위 몬스터 프리팹의 위치"), new Vector2(transform.position.x+Random.Range(-1,1),transform.position.y + Random.Range(-1, 1)), Quaternion.identity);
    }
    //4.사망시 아이템 드롭 후 자체 파괴, 플레이어의 이동속도를 원상복구 해야함.
    public void Dead()
    {  if (HP <= 0)
        {
            //파괴
            Destroy(gameObject);

            //사망시 아이템을 떨굼. 
            DI.drop_Item(1, transform);
            //사망시 돈을 떨굼.
            DM.drop_Money(2, transform);
            //다시 플레이어의 AGI를 원상복구
            target.GetComponent<Player_Stat>().Set_P_State(4, Save_P_AGI);

        }

    }

}
