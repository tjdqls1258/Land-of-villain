using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_Stats : MonoBehaviour
{
    // Start is called before the first frame update
    //돈의 가치(0=동화=1원)(1=은화=10원)(2=금화=100원)
    
    public int Money_Value = 0;
    //현재 돈의 가치를 반환해줌
    public int Get_Money_Value()
    {
        return Money_Value;
    }
}
