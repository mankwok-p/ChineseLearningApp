using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class Item
{
    public string labelText;
    public string gameName;
}

public class FavGameScrollList : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public TMP_Text header;
    public SimpleObjectPool buttonObjectPool;

    private UserData userData;

    void Start()
    {
        userData = UserData.LoadUserData();
        header.text = header.text + " (" + userData.favouriteGames.Count + ")";
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
        UserData UserData = UserData.LoadUserData();

        foreach (string gameName in UserData.favouriteGames)
        {
            Item item = new Item();
            item.labelText = GetDisplayName(gameName);
            item.gameName = gameName;
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel, false);

            FavBtn favBtn = newButton.GetComponent<FavBtn>();
            favBtn.Setup(item, this);
        }
    }

    private string GetDisplayName(string gameName)
    {
        string displayName = gameName;
        //Scene name pattern:
        //[game number]_[sound char]
        //eg: 1_a => game #1 of final "a"

        if(gameName.Length >=3 && gameName.IndexOf("_") > 0)
        {
            displayName = string.Format("Game {0}: {1}", 
            gameName.Substring(0, gameName.IndexOf("_")), 
            gameName.Substring(gameName.IndexOf("_") + 1)
            );
        }

        return displayName;
    }
}