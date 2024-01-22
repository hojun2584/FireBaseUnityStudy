using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Floating : SingleTon<Floating>
{

    public TextMeshProUGUI textMeshPro;

    float fadeOutSpeed = 0.5f;

    public void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void JustFloating(string text)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(FadeOut(text));
    }

    public void OnEnable()
    {
        Color color = textMeshPro.color;
        color.a = 1f;
        textMeshPro.color = color;
        
    }

    IEnumerator FadeOut(string text)
    {

        textMeshPro.text = text;
        
        Color color = textMeshPro.color;

        while(textMeshPro.color.a > 0)
        {
            color = textMeshPro.color;
            color.a -= Time.deltaTime * fadeOutSpeed;
            textMeshPro.color = color;
            yield return null;
        }

        this.gameObject.SetActive(false);
    }


}
