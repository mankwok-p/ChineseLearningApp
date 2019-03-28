using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ThemeSettings : MonoBehaviour
{
    public GameObject BackgroundImage01;
    public GameObject BackgroundImage02;
    public GameObject BackgroundImage03;
    public GameObject BackgroundImage04;
    public GameObject BackgroundImage05;
    public GameObject BackgroundImage06;
    public GameObject BackgroundImage07;
    public GameObject BackgroundImage08;
    public GameObject BackgroundImage09;
    public GameObject BackgroundImage10;
    public GameObject BackgroundImage11;
    public GameObject BackgroundImage12;
    public GameObject BackgroundImage13;
    public GameObject BackgroundImage14;
    public GameObject BackgroundImage15;
    private int currentSettings;

    public void Start()
    {
        currentSettings = -1;
    }

    public void Update()
    {
        int settings = PlayerPrefs.GetInt("ThemeSettings", 0);
        if (settings != currentSettings)
        {
            currentSettings = settings;
            ClearSettings();

            if (settings == 0) BackgroundImage01.SetActive(true);
            else if (settings == 1) BackgroundImage01.SetActive(true);
            else if (settings == 2) BackgroundImage02.SetActive(true);
            else if (settings == 3) BackgroundImage03.SetActive(true);
            else if (settings == 4) BackgroundImage04.SetActive(true);
            else if (settings == 5) BackgroundImage05.SetActive(true);
            else if (settings == 6) BackgroundImage06.SetActive(true);
            else if (settings == 7) BackgroundImage07.SetActive(true);
            else if (settings == 8) BackgroundImage08.SetActive(true);
            else if (settings == 9) BackgroundImage09.SetActive(true);
            else if (settings == 10) BackgroundImage10.SetActive(true);
            else if (currentSettings == 11) BackgroundImage11.SetActive(true);
            else if (currentSettings == 12) BackgroundImage12.SetActive(true);
            else if (currentSettings == 13) BackgroundImage13.SetActive(true);
            else if (currentSettings == 14) BackgroundImage14.SetActive(true);
            else if (currentSettings == 15) BackgroundImage15.SetActive(true);
        }
    }

    private void ClearSettings()
    {
        BackgroundImage01.SetActive(false);
        BackgroundImage02.SetActive(false);
        BackgroundImage03.SetActive(false);
        BackgroundImage04.SetActive(false);
        BackgroundImage05.SetActive(false);
        BackgroundImage06.SetActive(false);
        BackgroundImage07.SetActive(false);
        BackgroundImage08.SetActive(false);
        BackgroundImage09.SetActive(false);
        BackgroundImage10.SetActive(false);
        BackgroundImage11.SetActive(false);
        BackgroundImage12.SetActive(false);
        BackgroundImage13.SetActive(false);
        BackgroundImage14.SetActive(false);
        BackgroundImage15.SetActive(false);
    }
}
