using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Back_Button : MonoBehaviour
{
    private Attitude attitude;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset_Value()
    {
        attitude = GameObject.Find("Temp").GetComponent<Attitude>();
        attitude.IsPre = false;
        attitude.IsStart = false;
        attitude.Current_Num = 0;
        attitude.Correct = 0;
        attitude.Correct_Answer = false;
        attitude.Choosen = false;
        
        GameObject.Find("Map").transform.Find("MainPage").gameObject.SetActive(true);
        GameObject MainPage = GameObject.Find("MainPage");
        CanvasGroup canvasGroup = MainPage.GetComponent<CanvasGroup>();
        canvasGroup.DOFade(1, 1f);
        GameObject.Find("FinalPage").GetComponent<FinalPage_Setting>().End();
    }
}
