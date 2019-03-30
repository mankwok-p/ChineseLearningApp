using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FavBtnHandler : MonoBehaviour
{
    private UserData userData;
    public TMP_Text treasureText;


    void Start()
    {
        this.userData = UserData.LoadUserData();
    }

    public void OnFavBtnCliked(string gameName) 
    {
        bool isAdded = this.userData.HandleFavouriteGame(gameName);
        if(isAdded) 
        {
            treasureText.text = "Added to Treasure Box";
        }
        else {
            treasureText.text = "Removed from Treasure Box";
        }
    }
}
