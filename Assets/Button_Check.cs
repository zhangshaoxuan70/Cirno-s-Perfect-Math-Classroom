using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button_Check : MonoBehaviour
{
    private Attitude attitude;
    public bool Choose;
    // Start is called before the first frame update
    void Start()
    {
        attitude = GameObject.Find("Temp").GetComponent<Attitude>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onTouch(Button button)
    {
        Button lastSelect = GameObject.Find("GamePage").GetComponent<GamePage_Setting>().LastSelectButton;
        attitude.Choosen = Choose;
        if (lastSelect != null)
        {
            lastSelect.interactable = true;
        }

        GameObject.Find("GamePage").GetComponent<GamePage_Setting>().LastSelectButton = button;
        button.interactable = false;

    }
}
