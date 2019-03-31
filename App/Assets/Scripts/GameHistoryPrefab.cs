using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHistoryPrefab : MonoBehaviour
{
     
    public Button buttonComponent;
    public Text nameLabel;

    public Text timeLabel;

    private GameHistoryItem item;
    private GameReportScrollList scrollList;
    
    
    // Use this for initialization
    void Start () 
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }
    
     public void Setup(GameHistoryItem currentItem, GameReportScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.labelText;
        timeLabel.text = item.playedTimeText;
        scrollList = currentScrollList;
    }
    
    public void HandleClick()
    {
        //Debug.Log(item.gameName);
    }
}
