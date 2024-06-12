using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Start_Button : MonoBehaviour
{
    
    public Attitude component;
    private GameObject MainPage;
    private Slider_Timing Slider;
    private CanvasGroup Rest_canvasGroup;
    public float loadtime;
    // Start is called before the first frame update
    void Start()
    {
        component=GameObject.Find("Temp").GetComponent<Attitude>();
        MainPage = GameObject.Find("MainPage");
        Slider = GameObject.Find("Slider").GetComponent<Slider_Timing>();
        Rest_canvasGroup = GameObject.Find("Rest").GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ontouch()
    {
        component.IsPre=true;
        CanvasGroup canvasGroup = MainPage.GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 1f);
        Slider.Start_Time(loadtime);
        Rest_canvasGroup.DOFade(1, 1f);
        Invoke("InActive", 1f);
        
        //GameObject.Find("Question").GetComponent<Question_Gen_Check>().Generator();
    }
    private void InActive()
    {
        MainPage.SetActive(false);
    }
}
