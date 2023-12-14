using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration;
    public Color fadeColor;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if(fadeOnStart ) 
        {
            FadeIn();
        }
    }

    // Update is called once per frame
    void Fade(float fadeIn,float fadeOut)
    {
        StartCoroutine(FadeRoutine(fadeIn,fadeOut));
    }
    public IEnumerator FadeRoutine(float fadeIn,float fadeOut)
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(fadeIn, fadeOut, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor;
        newColor2.a = fadeOut;
        rend.material.SetColor("_Color", newColor2);
    }

   public void FadeIn()
    {
        Fade(1, 0);
    }
   public void FadeOut()
    {
        Fade(0, 1);
    }
}
