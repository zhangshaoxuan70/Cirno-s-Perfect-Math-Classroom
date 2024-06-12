using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalPage_Setting : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 0);
        GameObject.Find("FinalPage").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowScore()
    {
        canvasGroup.DOFade(1, 1f);
    }

    public void End()
    {
        canvasGroup.DOFade(0, 1f);
        Invoke("InActive", 1f);
    }
    private void InActive()
    {
        GameObject.Find("FinalPage").SetActive(false);
    }
}
