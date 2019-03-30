using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FavBtn : MonoBehaviour
{
     
    public Button buttonComponent;
    public Text nameLabel;

    private Item item;
    private FavGameScrollList scrollList;
    
    
    // Use this for initialization
    void Start () 
    {
        buttonComponent.onClick.AddListener (HandleClick);
    }
    
     public void Setup(Item currentItem, FavGameScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.labelText;
        scrollList = currentScrollList;
    }
    
    public void HandleClick()
    {
        SceneManager.LoadScene(item.gameName);
    }
}
