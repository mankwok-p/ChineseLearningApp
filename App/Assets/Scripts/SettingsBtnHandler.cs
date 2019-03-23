using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

[RequireComponent(typeof(Button))]
public class SettingsBtnHandler : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioMixerGroup audioMixerGroup;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.outputAudioMixerGroup = audioMixerGroup;
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

    public void BackToSettings()
    {
        StartCoroutine(DelaySceneLoad("Settings"));
    }

    IEnumerator DelaySceneLoad(string sceneName)
    {
        PlaySound();
        yield return new WaitForSeconds(sound.length);
        SceneManager.LoadScene(sceneName);
    }
}
