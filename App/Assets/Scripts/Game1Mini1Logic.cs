using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Game1Mini1Logic : MonoBehaviour
{
    public Button btn1, btn2, btn3, btn4;
    public TMP_Text header;

    private int trial = 3;
    private bool isWin = false;
    private List<int> clickOrder = new List<int>(4);
    // Start is called before the first frame update
    void Start()
    {

        btn1.onClick.AddListener(() => onSoundBtnClick(1));
        btn2.onClick.AddListener(() => onSoundBtnClick(2));
        btn3.onClick.AddListener(() => onSoundBtnClick(3));
        btn4.onClick.AddListener(() => onSoundBtnClick(4));
    }

    // Update is called once per frame
    void Update()
    {
            if (isWin)
            {
                header.SetText("You win");
            }
            else if (trial == 0)
            {
                header.SetText("You Lose");
                
            }
    }

    void onSoundBtnClick(int order)
    {
        if (trial > 0)
        {
            clickOrder.Add(order);
            
            if (clickOrder.Count == 4)
            {
                clickOrder.Add(order);
                trial--;
                if (IsPressInOrder())
                {
                    isWin = true;
                }
                else
                {
                    clickOrder.Clear();
                }
            }
        }

        if (isWin || trial == 0)
        {
            DisableSoundBtn();
            if (isWin)
            {
                header.SetText("You win");
            }
            else if (trial == 0)
            {
                header.SetText("You Lose");

            }
        }
    }

    private bool IsPressInOrder()
    {
        if (clickOrder[0] == 1 && clickOrder[1] == 2 && clickOrder[2] == 3 && clickOrder[3] == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DisableSoundBtn()
    {
        btn1.interactable = false;
        btn2.interactable = false;
        btn3.interactable = false;
        btn4.interactable = false;
    }
}
