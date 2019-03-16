using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Game2Logic : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isWin = false;
    public static bool isWrong = false;
    public TMP_Text header;
    public Button question1, question2, question3, question4;
    public GameObject placeHolder;
    public Button answer1, answer2, answer3, answer4, btnReset;

    private Vector3 defaultQuestionPos;

    private List<Vector3> defaultAnswerPos = new List<Vector3>();

    void Start()
    {
        //initialPosition = this.transform.position;

        btnReset.onClick.AddListener(() => ResetGame());

        defaultQuestionPos = question1.transform.position;

        defaultAnswerPos.Add(answer1.transform.position);
        defaultAnswerPos.Add(answer2.transform.position);
        defaultAnswerPos.Add(answer3.transform.position);
        defaultAnswerPos.Add(answer4.transform.position);

        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin)
        {
            header.SetText("You win");
            answer1.interactable = false;
            answer2.interactable = false;
            answer3.interactable = false;
            answer4.interactable = false;
        }
        else if (isWrong)
        {
            header.SetText("Try again");
        }
    }

    private void ResetGame()
    {
        isWin = false;
        isWrong = false;
        header.SetText("");

        answer1.interactable = true;
        answer2.interactable = true;
        answer3.interactable = true;
        answer4.interactable = true;

        SetQuestionAndAnswer();
        ResetAnswerPos();
        ShuffleAnswerPos();
    }

    private void SetQuestionAndAnswer()
    {
        int n = (new System.Random()).Next(0, 4);
        string answerTag = "answer";
        string unTag = "Untagged";

        question1.gameObject.SetActive(false);
        question2.gameObject.SetActive(false);
        question3.gameObject.SetActive(false);
        question4.gameObject.SetActive(false);

        answer1.tag = unTag;
        answer2.tag = unTag;
        answer3.tag = unTag;
        answer4.tag = unTag;

        switch (n)
        {
            case 0:
                question1.gameObject.SetActive(true);
                answer1.tag = answerTag;
                break;
            case 1:
                question2.gameObject.SetActive(true);
                answer2.tag = answerTag;
                break;
            case 2:
                question3.gameObject.SetActive(true);
                answer3.tag = answerTag;
                break;
            case 3:
                question4.gameObject.SetActive(true);
                answer4.tag = answerTag;
                break;

        }


    }

    private void ResetAnswerPos()
    {
        // List<Button> btnList = new List<Button>();
        // btnList.Add(answer1);
        // btnList.Add(answer2);
        // btnList.Add(answer3);
        // btnList.Add(answer4);

        // for (int i = 0; i < btnList.Count; i++)
        // {
        //     btnList[i].transform.position = defaultAnswerPos[i];
        // }

        answer1.transform.position = defaultAnswerPos[0];
        answer2.transform.position = defaultAnswerPos[1];
        answer3.transform.position = defaultAnswerPos[2];
        answer4.transform.position = defaultAnswerPos[3];
        
    }
    private void ShuffleAnswerPos()
    {
        List<Vector3> posList = new List<Vector3>();
        posList.Add(answer1.transform.position);
        posList.Add(answer2.transform.position);
        posList.Add(answer3.transform.position);
        posList.Add(answer4.transform.position);

        List<Button> btnList = new List<Button>();
        btnList.Add(answer1);
        btnList.Add(answer2);
        btnList.Add(answer3);
        btnList.Add(answer4);

        for (int i = btnList.Count - 1; i >= 0; i--)
        {
            int n = (new System.Random()).Next(0, btnList.Count);
            btnList[n].transform.position = posList[i];
            btnList.RemoveAt(n);
        }

    }
}
