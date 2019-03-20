using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]
public class MainBtnHandler : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
    }

    public void PlaySound()
    {
        source.PlayOneShot(sound);
    }

    public void StartGame()
    {
        StartCoroutine(DelaySceneLoad("GameSelect"));
    }

    public void StartSettings()
    {
        StartCoroutine(DelaySceneLoad("Settings"));
    }

    public void BackToHome()
    {
        StartCoroutine(DelaySceneLoad("MainMenu"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowInstruction(GameObject instructionPanel)
    {
        PlaySound();
        // if (instructionPanel.activeSelf)
        //     instructionPanel.SetActive(false);
        // else 
        //      instructionPanel.SetActive(true);
        StartCoroutine(ActivatePanel(instructionPanel));
    }
    IEnumerator ActivatePanel(GameObject instructionPanel)
    {
        instructionPanel.SetActive(true);
        yield return new WaitForSeconds(10);
        instructionPanel.SetActive(false);
    }

    IEnumerator DelaySceneLoad(string sceneName)
    {
        PlaySound();
        yield return new WaitForSeconds(sound.length);
        SceneManager.LoadScene(sceneName);

    }
}
