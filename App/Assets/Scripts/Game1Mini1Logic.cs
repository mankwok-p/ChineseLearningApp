using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Game1Mini1Logic : MonoBehaviour
{
    public Button btn1, btn2, btn3, btn4, btnReset;
    public TMP_Text header;
    public TMP_Text textTrial;

    public AudioSource winAudio;
    public AudioSource loseAudio;

    public static readonly int MAX_TRIAL = 3;
    private int currentTrial = MAX_TRIAL;
    private bool isWin = false;
    private List<int> clickOrder = new List<int>(4);
    // Start is called before the first frame update
    void Start()
    {
        btn1.onClick.AddListener(() => onSoundBtnClick(1));
        btn2.onClick.AddListener(() => onSoundBtnClick(2));
        btn3.onClick.AddListener(() => onSoundBtnClick(3));
        btn4.onClick.AddListener(() => onSoundBtnClick(4));

        SetResetBtn(false);
        btnReset.onClick.AddListener(() => onResetBtnClick());
        setTrialText();
    }

    // Update is called once per frame
    void Update()
    {
            // if (isWin)
            // {
            //     header.SetText("You win");
            // }
            // else if (trial == 0)
            // {
            //     header.SetText("You Lose");
                
            // }
    }

    void onSoundBtnClick(int order)
    {
        if (currentTrial > 0)
        {
            clickOrder.Add(order);
            
            if (clickOrder.Count == 4)
            {
                clickOrder.Add(order);
                currentTrial--;
                setTrialText();
                if (IsPressInOrder())
                {
                    isWin = true;
                }
                else
                {
                    header.SetText("Try again");
                    loseAudio.PlayOneShot(loseAudio.clip);
                    clickOrder.Clear();
                }
            }
        }

        if (isWin || currentTrial == 0)
        {
            SetSoundBtn(false);
            if (isWin)
            {
                header.SetText("You win");
                winAudio.PlayOneShot(winAudio.clip);
                SetResetBtn(true);
            }
            else if (currentTrial == 0)
            {
                header.SetText("You Lose");
                loseAudio.PlayOneShot(loseAudio.clip);
                SetResetBtn(true);

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

    private void SetSoundBtn(bool interactable)
    {
        btn1.interactable = interactable;
        btn2.interactable = interactable;
        btn3.interactable = interactable;
        btn4.interactable = interactable;
    }

    private void SetResetBtn(bool interactable)
    {
        btnReset.interactable = interactable;
    }

    private void onResetBtnClick()
    {
        SetResetBtn(false);
        SetSoundBtn(true);
        clickOrder.Clear();
        currentTrial = MAX_TRIAL;
        isWin = false;
        header.SetText("");
        setTrialText();
    }
    private void setTrialText()
    {
        textTrial.SetText("Trial: " + currentTrial + "/" + MAX_TRIAL);
    }
}
