using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainBtnHandler : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("GameSelect");
    }

    public void exitGame(){
		Application.Quit();
	}
}
