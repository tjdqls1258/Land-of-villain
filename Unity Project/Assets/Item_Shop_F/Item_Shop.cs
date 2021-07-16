using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Shop : MonoBehaviour
{   //플레이어의 소지금을 표현하기 위함.
    public Text P_Money;
    //아이템 구매 버튼을 위함.

    private Button[] BS = new Button[4];
    //아이템 이름을 표현하기 위함

    private Text[] T_Item_Name = new Text[4];
    //아이템 가격을 표현하기 위함.

    private Text[] T_Item_Price = new Text[4];
    //아이템이 구매 가능한지 품절인지를 표현하기 위한 버튼 안의 텍스트

    private Text[] Button_Text = new Text[4];
    //아이템의 이름들을 가져오기 위함.
    Item_List IL = new Item_List();

    //실제 사용될 아이템의 이름, 가격

    private string[] Item_Name = new string[4] { "","","",""};

    private int[] Item_Price = new int[4] { 0,0,0,0};
    //아이템 샵이 새로운 라운드로 넘어가 열리는 것을 알리기 위한 변수.
    private bool Shop_Open = false;
    //아이템이 구매 되었는지 안 되었는지 확인하기 위한 변수.

    private bool[] Item_Buy = new bool[4] { false,false,false,false };
    //플레이어들의 돈을 가져오기 위해.
    Player_Item PE;
    //플레이어의 위치에 아이템을 떨구기 위해.
    GameObject PT;
    // Start is called before the first frame update

    void Start()
    {   //아이템 이름 텍스트 찾아 텍스트 컴포넌트 넣기
        T_Item_Name[0] = GameObject.Find("Item_Name1").GetComponent<Text>();
        T_Item_Name[1] = GameObject.Find("Item_Name2").GetComponent<Text>();
        T_Item_Name[2] = GameObject.Find("Item_Name3").GetComponent<Text>();
        T_Item_Name[3] = GameObject.Find("Item_Name4").GetComponent<Text>();
        //아이템 가격 텍스트 찾아 텍스트 컴포넌트 넣기
        T_Item_Price[0] = GameObject.Find("Item_Price1").GetComponent<Text>();
        T_Item_Price[1] = GameObject.Find("Item_Price2").GetComponent<Text>();
        T_Item_Price[2] = GameObject.Find("Item_Price3").GetComponent<Text>();
        T_Item_Price[3] = GameObject.Find("Item_Price4").GetComponent<Text>();
        //버튼 찾아 버튼 컴포넌트 넣기.
        BS[0] = GameObject.Find("Item_Buy_Button1").GetComponent<Button>();
        BS[1] = GameObject.Find("Item_Buy_Button2").GetComponent<Button>();
        BS[2] = GameObject.Find("Item_Buy_Button3").GetComponent<Button>();
        BS[3] = GameObject.Find("Item_Buy_Button4").GetComponent<Button>();
        //버튼을 누를 시 사용될 함수를 설정해줌.
        BS[0].onClick.AddListener(onButton1);
        BS[1].onClick.AddListener(onButton2);
        BS[2].onClick.AddListener(onButton3);
        BS[3].onClick.AddListener(onButton4);
        //버튼안에 텍스트를 가져오기 위함. 참고로 버튼의 텍스트는 버튼의 자식클래스이기 때문에 GetChild를 사용함.
        Button_Text[0] = BS[0].transform.GetChild(0).GetComponent<Text>();
        Button_Text[1] = BS[1].transform.GetChild(0).GetComponent<Text>();
        Button_Text[2] = BS[2].transform.GetChild(0).GetComponent<Text>();
        Button_Text[3] = BS[3].transform.GetChild(0).GetComponent<Text>();

        //플레이어의 돈을 가져오기 위해 사용(오브젝트의 이름을 찾아 스크립트를 가져온다.)
        PE = GameObject.Find("Player").GetComponent<Player_Item>();
        //플레이어의 위치를 사용하기 위해.
        PT = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Open_Item_Shop();

    }

    //버튼을 누를 시 사용되는 함수(사용법: Start()함수 안에 B_1.onClick.AddListener(onButton1);)
    public void onButton1()
    {   //소지금이 아이템의 가격보다 크거나 같고, 아이템이 구매가 되기 전이라면
        if (PE.Get_Player_Money() >= Item_Price[0] && Item_Buy[0] == false)
        {   
            //참고로 아이템의 이름이 NONE과 프리팹이 없는 이름일 경우 경우 오류가 발생하니 나중에 아이템 리스트를 꽉채워야하고 프리팹에 이름에 맞는 아이템을 넣어놔야함..
           Instantiate(Resources.Load("Item_Prefab/" + Item_Name[0]), PT.transform.position, Quaternion.identity);
            //품절이기에 버튼 텍스트를 NONE으로 만듦.
            Button_Text[0].text = "NONE";
            //아이템의 가격만큼 소지금에서 뺌.
            PE.Set_Player_Money(PE.Get_Player_Money() - Item_Price[0]);
            Item_Buy[0] = true;
        }
    }
    public void onButton2()
    {
        //소지금이 아이템의 가격보다 크거나 같고, 아이템이 구매가 되기 전이라면
        if (PE.Get_Player_Money() >= Item_Price[1] && Item_Buy[1] == false)
        {   

            Instantiate(Resources.Load("Item_Prefab/" + Item_Name[1]), PT.transform.position, Quaternion.identity);
            //품절이기에 버튼 텍스트를 NONE으로 만듦.
            Button_Text[1].text = "NONE";
            //아이템의 가격만큼 소지금에서 뺌.
            PE.Set_Player_Money(PE.Get_Player_Money() - Item_Price[1]);
            Item_Buy[1] = true;
        }
    }
    public void onButton3()
    {
        //소지금이 아이템의 가격보다 크거나 같고, 아이템이 구매가 되기 전이라면
        if (PE.Get_Player_Money() >= Item_Price[2] && Item_Buy[2] == false)
        {   
            Instantiate(Resources.Load("Item_Prefab/" + Item_Name[2]), PT.transform.position, Quaternion.identity);
            //품절이기에 버튼 텍스트를 NONE으로 만듦.
            Button_Text[2].text = "NONE";
            //아이템의 가격만큼 소지금에서 뺌.
            PE.Set_Player_Money(PE.Get_Player_Money() - Item_Price[2]);

            Item_Buy[2] = true;
        }
    }
    public void onButton4()
    {
        //소지금이 아이템의 가격보다 크거나 같고, 아이템이 구매가 되기 전이라면
        if (PE.Get_Player_Money() >= Item_Price[3] && Item_Buy[3] == false)
        {   
            Instantiate(Resources.Load("Item_Prefab/" + Item_Name[3]), PT.transform.position, Quaternion.identity);
            //품절이기에 버튼 텍스트를 NONE으로 만듦.
            Button_Text[3].text = "NONE";
            //아이템의 가격만큼 소지금에서 뺌.
            PE.Set_Player_Money(PE.Get_Player_Money() - Item_Price[3]);

            Item_Buy[3] = true;
        }
    }
    public void Open_Item_Shop()
    {   //아이템 상점이 새롭게 열리면 가격 정해줌을 멈춰줘야하니까. 만약에 이 스크립을 프리팹으로 만들어 생성/제거를 한다면 Start()에 넣어서 한번만 실행 시키는 것이 좀더 좋다고 생각함.
        if (Shop_Open == false)
        {
            int N1;
            //아이템의 이름과 가격을 정해줌.            
            for (int i = 0; i < 4; i++)
            {
                N1 = Item_Select_Rank();
                Item_Name[i] = Item_Select_Name(N1);
                Item_Price[i] = Item_Select_Price(N1);
            }
            //텍스트에 아이템의 이름과 가격을 넣어줌.
            Copy_Item_Name_And_Price();
            //전에 아이템을 구매 했을 수도 있으니 버튼 텍스트를 Buy으로 만듦.
            for (int i = 0; i < 4; i++)
            {
                Button_Text[i].text = "BUY";
            }
            //아이템 상점아이템을 한번만 실행시켜 주기 위해.
            Shop_Open = true;
        }
        //플레이어의 소지금을 표현하기 위함.
        P_Money.text = "Player Money : "+PE.Get_Player_Money().ToString();


    }
    //라운드가 넘어가서 다음번 상점을 열었을 때 상품 품목을 초기화 시켜주는 코드.
    public void On_Shop_Open()
    {
        Shop_Open = false;
    }
    public int Item_Select_Rank()//아이템의 등급을 정해줌.
    {

        int RN1=0;//처음에 아이템의 등급을 정해주기 위함

         RN1 = Random.Range(0, 100);

        if (RN1 <= 49)//0~49이면 Nomal 장비
        {
            return 0;
        }
        else if (RN1 >= 50 && RN1 <= 79) //50~79이면 Rare장비
        {
            return 1;
        }
        else if (RN1 >= 80)//80~100이면 Epic장비
        {
            return 2;
        }
        else
        {
            return 3;
        }


    }
    public int Item_Select_Price(int N)//아이템의 가격을 반환
    { 
      //<기존 계획> 아이템 가격((Round/10)*100)+ (노말은 100~200, 레어는 200~300, 에픽은 300~400 랜덤으로 해서)
      //일단은 그냥 랜덤만 해둘거임 Round를 어디서 받아오는지 알 수가 없음.
        if (N == 0)
        {
            return Random.Range(100, 200); 
        }
        else if (N == 1)
        {
            return Random.Range(200, 300); 
        }
        else if (N == 2)
        {

            return Random.Range(300, 400);
        }
        else
        {
            return 0;
        }
    }
    public string Item_Select_Name(int N)//아이템의 이름을 반환
    { //아이템 리스트에서 이름 정해주기, 아이템 가격 정해주기 /아이템[랜덤(0,0배열최대),랜덤(0,1배열최대)]
        if (N == 0)
        {
            return IL.Get_N_Item_Name(Random.Range(0, IL.Get_N_Item_List().GetLength(0)), Random.Range(0, IL.Get_N_Item_List().GetLength(1)));
        }
        else if (N == 1)
        {
            return IL.Get_R_Item_Name(Random.Range(0, IL.Get_R_Item_List().GetLength(0)), Random.Range(0, IL.Get_R_Item_List().GetLength(1)));
        }
        else if (N == 2)
        {

            return IL.Get_E_Item_Name(Random.Range(0, IL.Get_E_Item_List().GetLength(0)), Random.Range(0, IL.Get_E_Item_List().GetLength(1)));
        }
        else
        {
            return "";
        }
    }
    public void Copy_Item_Name_And_Price() //아이템의 이름과 가격을 텍스트에 넣어주는 과정
    {   //아이템의 이름을 텍스트 아이템 이름에 넣어줌
        for (int i = 0; i < 4; i++)
        {
            //아이템의 이름을 텍스트 아이템 이름에 넣어줌
            T_Item_Name[i].text = Item_Name[i];
            //아이템의 가격을 텍스트 아이템 가격에 넣어줌.
            T_Item_Price[i].text = Item_Price[i].ToString();
        }

    }

}
