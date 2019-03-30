using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavBtnHandler : MonoBehaviour
{
    private UserData userData;

    void Start()
    {
        this.userData = UserData.LoadUserData();
    }

    public void OnFavBtnCliked(string gameName) 
    {
        this.userData.HandleFavouriteGame(gameName);
    }
}
