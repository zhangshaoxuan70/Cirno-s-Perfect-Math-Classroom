using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Timing : MonoBehaviour
{
    private Slider slider;
    private Countdown countdown;
    private Attitude attitude;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        countdown = GameObject.Find("Countdown_Text").GetComponent<Countdown>();
        attitude = GameObject.Find("Temp").GetComponent<Attitude>();
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Start_Time(float time)
    {
        StartCoroutine(Delay(time));
        
    }

    private IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(1);
        Pretime(time);
    }

    private void Pretime(float time)
    {
        slider.value = 0;
        countdown.Start_Time(time);
        DOTweenModuleUI.DOValue(slider, 1, 0.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            DOTweenModuleUI.DOValue(slider, 0, time).SetEase(Ease.Linear).OnComplete(() =>
            {
                attitude.Check();
            });

        });
    }

}
