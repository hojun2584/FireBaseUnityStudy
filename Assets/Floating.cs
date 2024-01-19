using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Floating : MonoBehaviour
{

    
    public TextMeshProUGUI textMeshPro;
    public static Floating instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void JustFloating(string text)
    {
        StartCoroutine(FadeOut(text));
    }
    

    IEnumerator FadeOut(string text)
    {

        textMeshPro.text = text;

        while(textMeshPro.alpha <= 0)
        {
            textMeshPro.alpha -= 0.01f;
            yield return null;
        }

    }


}
