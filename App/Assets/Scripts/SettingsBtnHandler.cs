using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SettingsBtnHandler : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    
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

    public void StartReport()
    {
        StartCoroutine(DelaySceneLoad("Report"));
    }

    public void StartMusic()
    {
        StartCoroutine(DelaySceneLoad("Music"));
    }

    public void StartShare()
    {
        StartCoroutine(DelaySceneLoad("Share"));
    }

    public void StartTreasure()
    {
        StartCoroutine(DelaySceneLoad("Treasure"));
    }

    public void StartTheme()
    {
        StartCoroutine(DelaySceneLoad("Theme"));
    }

    public void BackToHome()
    {
        StartCoroutine(DelaySceneLoad("MainMenu"));
    }
    
    IEnumerator DelaySceneLoad(string sceneName)
    {
        PlaySound();
        yield return new WaitForSeconds(sound.length);
        SceneManager.LoadScene(sceneName);
    }
}
