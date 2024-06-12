using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GamePage_Setting : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public Button LastSelectButton;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 0);
        GameObject.Find("GamePage").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        canvasGroup.DOFade(1, 1f);
    }

    public void GameEnd()
    {
        canvasGroup.DOFade(0, 1f);
        Invoke("InActive", 1f);
    }
    private void InActive()
    {
        GameObject.Find("GamePage").SetActive(false);
    }
}
