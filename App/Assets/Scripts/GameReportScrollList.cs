using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class GameHistoryItem
{
    public string labelText;
    public string gameName;

    public string playedTimeText;

}

public class GameReportScrollList : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;

    private UserData userData;

    void Start()
    {
        this.userData = UserData.LoadUserData();
        this.userData.RemoveOldHistory();

        RefreshDisplay();
    }

    void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        foreach (GameHistory gameHistory in this.userData.gameHistory)
        {
            GameHistoryItem item = new GameHistoryItem();
            item.labelText = GetDisplayName(gameHistory.gameName);
            item.gameName = gameHistory.gameName;
            item.playedTimeText = gameHistory.playTime.ToString("dd/MM/yyyy HH:mm");
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel, false);

            GameHistoryPrefab favBtn = newButton.GetComponent<GameHistoryPrefab>();
            favBtn.Setup(item, this);
        }
    }

    private string GetDisplayName(string sceneName)
    {
        string displayName = sceneName;
        //Scene name pattern:
        //[game number]_[sound char]
        //eg: 1_a => game #1 of final "a"

        if (sceneName.Length >= 3 && sceneName.IndexOf("_") > 0)
        {
            displayName = string.Format("Game {0}: {1}",
                sceneName.Substring(0, sceneName.IndexOf("_")),
                sceneName.Substring(sceneName.IndexOf("_") + 1)
            );
        }

        return displayName;
    }
}