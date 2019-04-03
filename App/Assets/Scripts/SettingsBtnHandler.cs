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
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

        var shareSubject = "Share with friends";
        var shareMessage = "I am playing the Chinese Learning App. It is funny and good for learning Chinese. I recommend the app to you. \n\nCheers\n\n https://github.com/mankwok-p/ChineseLearningApp";

        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);

        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, shareSubject);
        currentActivity.Call("startActivity", chooser);
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
