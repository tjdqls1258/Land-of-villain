using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Anmation : MonoBehaviour
{
    public Text Fade;

    void Awake()
    {
        StartCoroutine(FadeIn());
    }

    void Update()
    {
    }

    // Fade 애니메이션 함수.  
    IEnumerator FadeIn()
    {
        Color startColor = Fade.color;

        for (int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a - 0.01f;
            Fade.color = startColor;

            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        Color startColor = Fade.color;

        for (int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a + 0.01f;
            Fade.color = startColor;

            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(FadeIn());
    }
}
