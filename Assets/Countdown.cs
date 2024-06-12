using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Countdown : MonoBehaviour
{
    private TMP_Text Countdown_Text;
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        Countdown_Text = GetComponent<TMP_Text>();
        canvasGroup  = GetComponent<CanvasGroup>();
        Countdown_Text.text = string.Empty;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_Time(float time)
    {
        Countdown_Text.text = time.ToString();
        canvasGroup.DOFade(1, 0.5f).OnComplete(() =>
        {
            StartCoroutine(ChangeTime(time));
        });
    }

    private IEnumerator ChangeTime(float time)
    {
        float timer = time;
        yield return new WaitForSeconds(0.5f);
        while (timer > 0)
        {
            
            timer--;
            if (timer == 0)
                Countdown_Text.text = "вс";
            else
                Countdown_Text.text = timer.ToString();
            if (timer == 0)
                break;
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(0.5f);
        canvasGroup.DOFade(0, 1);
        
    }
}
