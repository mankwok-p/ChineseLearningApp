﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

[RequireComponent(typeof(Button))]
public class GameSelectBtnHandler : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioMixerGroup audioMixerGroup;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.outputAudioMixerGroup = audioMixerGroup;
        source.playOnAwake = false;
    }

    public void StartGame(string sceneName)
    {
        UserData UserData = UserData.LoadUserData();
        UserData.SaveGameHistory(sceneName);
        StartCoroutine(DelaySceneLoad(sceneName));
    }

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

    IEnumerator DelaySceneLoad(string sceneName)
    {
        PlaySound();
        yield return new WaitForSeconds(sound.length);
        SceneManager.LoadScene(sceneName);

    }
}
