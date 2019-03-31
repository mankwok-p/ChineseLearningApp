using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class FavBtn : MonoBehaviour
{
     
    public Button buttonComponent;
    public Text nameLabel;

    public AudioClip sound;
    public AudioMixerGroup audioMixerGroup;

    private Item item;
    private FavGameScrollList scrollList;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    
    // Use this for initialization
    void Start () 
    {
        buttonComponent.onClick.AddListener (HandleClick);
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.outputAudioMixerGroup = audioMixerGroup;
        source.playOnAwake = false;
    }
    
     public void Setup(Item currentItem, FavGameScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.labelText;
        scrollList = currentScrollList;
    }
    
    public void HandleClick()
    {
       StartGame(item.gameName);
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
