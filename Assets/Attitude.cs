using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;


public class Attitude : MonoBehaviour
{
    public bool IsPre;
    public bool IsStart;
    public int Current_Num;
    public int Correct;
    public bool Correct_Answer = false;
    public bool Choosen = false;

    private CanvasGroup Rest_canvasGroup;
    private Slider_Timing slider;
    private GameObject Map;
    // Start is called before the first frame update
    void Start()
    {
        IsStart = false;
        Current_Num = 0;
        Correct = 0;

        
        Rest_canvasGroup = GameObject.Find("Rest").GetComponent<CanvasGroup>();
        Map = GameObject.Find("Map");
        slider = GameObject.Find("Slider").GetComponent<Slider_Timing>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Start_Question()
    {
        GamePage_Setting GP_setting = GameObject.Find("GamePage").GetComponent<GamePage_Setting>();
        GP_setting.LastSelectButton = null;
        GameObject[] Buttons = GameObject.FindGameObjectsWithTag("Button");
        foreach(GameObject Button in Buttons)
            Button.GetComponent<Button>().interactable = true;
        if (Current_Num > 0)
            if (Choosen == Correct_Answer)
                Correct++;
        Choosen = false;
        Question_Generator();
        slider.Start_Time(1);
        Current_Num++;
    }

    public void Check()
    {
        if (Current_Num >= 20)
        {
            IsStart = false;
            if (Choosen == Correct_Answer)
                Correct++;
            GameObject.Find("GamePage").GetComponent<GamePage_Setting>().GameEnd();
            Map.transform.Find("FinalPage").gameObject.SetActive(true);

            TMP_Text Question_Score = GameObject.Find("Scores").GetComponent<TMP_Text>();
            Question_Score.text = string.Format("结束啦!\n你在这20道题中做对了{0}道!\n占比{1}",Correct, (((double)Correct / Current_Num)).ToString("P"));
            FinalPage_Setting FP_setting = GameObject.Find("FinalPage").GetComponent<FinalPage_Setting>();
            FP_setting.ShowScore();
        }
        

        if (IsPre == true)
        {
            Map.transform.Find("GamePage").gameObject.SetActive(true);
            GamePage_Setting GP_setting =GameObject.Find("GamePage").GetComponent<GamePage_Setting>();

            GP_setting.GameStart();
            Rest_canvasGroup.DOFade(0, 1f);
            IsPre = false;
            IsStart = true;

            Start_Question();
        }
        else if (IsStart == true)
            Start_Question();
    }

    public void Question_Generator()
    {
        bool is_correct;
        int correct_set = Random.Range(0, 2);
        if (correct_set == 0)
            is_correct = true;
        else
            is_correct = false;
        int a = Random.Range(0, 11);
        int b = Random.Range(0, 11);
        int equal_type = Random.Range(0, 2);
        while (true)
        {
            a = Random.Range(0, 11);
            b = Random.Range(0, 11);
            equal_type = Random.Range(0, 2);
            if (equal_type == 0)
                if (is_correct && a + b == 9)
                    break;
                else if (!is_correct && a + b != 9)
                    break;
        }
        Correct_Answer = is_correct;
        if (equal_type == 0)
        {
            GameObject.Find("Question").GetComponent<TMP_Text>().text = a.ToString() + "+" + b.ToString() + "=⑨?";
            //Debug.Log(a.ToString() + "+" + b.ToString() + "=" + (a + b).ToString());
        }
        else
        {
            GameObject.Find("Question").GetComponent<TMP_Text>().text = a.ToString() + "-" + b.ToString() + "=⑨?";
            //Debug.Log(a.ToString() + "-" + b.ToString() + "=" + (a - b).ToString());
        }
    }

}
