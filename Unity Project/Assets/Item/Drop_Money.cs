using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Money : MonoBehaviour
{

    int Round = 1;//라운드에 따라서 돈을 얻을 수 있는 금액 증가.
    //몬스터의 종류에 따라 돈을 떨구는 코드 (0:일반 몬스터,1:레어 몬스터, 2:보스 몬스터)
    public void drop_Money(int get_Monster)
    {
        if (get_Monster == 0)
        { get_Nomal_Monster(); }
        else if (get_Monster == 1)
        { get_Rare_Monster(); }
        else if (get_Monster == 2)
        { get_Boss_Monster(); }
    }
    //일반 몬스터를 죽였을 시
    //일반 몬스터는 50%의 확률로 돈을 떨굼.
    public void get_Nomal_Monster()
    {
        get_Coin(50, 1, 50);
    }
    //레어 몬스터를 죽였을 시
    public void get_Rare_Monster()
    { get_Coin(75, 50, 200); }
    //보스 몬스터를 죽였을 시
    public void get_Boss_Monster()
    { get_Coin(100, 200, 500); }

    //N1은 몬스터가 돈을 떨굴 확률, N2는 몬스터가 돈을 떨굴 금액.
    public void get_Coin(int N1_Max,int N2_Min,int N2_Max)
    {
        int N1 = Random.Range(0, 100);
        if (N1 >= 100-N1_Max)
        {   //1~50*현재 (라운드/10) 만큼의 금액을 얻음
            int N2 = (Round/10) * Random.Range(N2_Min, N2_Max);
            //금화 현재 몬스터가 떨군 금액 /100 을 해서 떨굴 수 있는 금화의 갯수를 정해줌
            int G = N2 / 100;
            //은화는 몬스터가 떨군 금액에서 금화를 뺀 수치를 사용해 다시 10으로 나눈다. 
            int S = (N2 - G) / 10;
            //동화는 몬스터가 떨군 금액에서 금화,은화를 뺀 수치.
            int C = (N2 - G - S);

            //아래는 동전들의 값 만큼 죽은 몬스터와 가까운 위치에 동전을 생성.
            //돈이 생성되는 구간은 몬스터가 죽은 자리 + (-1,1)사이의 값
            for (int i = 0; i < G; i++)
            {
                Instantiate(Resources.Load("Money_Prefab/Gold_Coin"), new Vector2(transform.position.x+Random.Range(-1,1),transform.position.y + Random.Range(-1, 1)), Quaternion.identity);
            }

            for (int i = 0; i < S; i++)
            { Instantiate(Resources.Load("Money_Prefab/Silver_Coin"), new Vector2(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(-1, 1)), Quaternion.identity); }

            for (int i = 0; i < C; i++)
            { Instantiate(Resources.Load("Money_Prefab/Copper_Coin"), new Vector2(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(-1, 1)), Quaternion.identity); }
        }
    }
}
