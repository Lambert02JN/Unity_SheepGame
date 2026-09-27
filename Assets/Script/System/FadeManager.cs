using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    Image fadeImage;
    private float fadeTime=2f;
    public GameObject fadeCanvas;
    public event Action FadeInComplete;
    // Start is called before the first frame update
    void Awake()
    {
        fadeImage=fadeCanvas.GetComponentInChildren<Image>();
    }
    public void FadeIn(){
        fadeImage.CrossFadeAlpha(0,fadeTime,true);
        Invoke("TriggerFade",fadeTime);
    }
    public void FadeOut(){
        fadeImage.CrossFadeAlpha(1,fadeTime,true);
    }
    public IEnumerator LoadInScene(string sceneName){
        FadeOut();
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName);
    }

    void TriggerFade()
    {
        if (FadeInComplete != null) FadeInComplete();
    }
}
