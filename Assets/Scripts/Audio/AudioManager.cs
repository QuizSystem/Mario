using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    public AudioSource bgMusic;
    public AudioClip clipMusic;
	// Use this for initialization
    void Awake()
    {
        Instance = this;
        bgMusic.mute =PlayerPrefsPlus.GetBool("MUSIC");
  
    }

    public void LoadBGMusic(string nameSong)
    {
        clipMusic = Resources.Load<AudioClip>(nameSong);
        bgMusic.clip = clipMusic;
        bgMusic.Play();
    }
    void DelayPlayOnWake()
    {
        GetComponent<AudioSource>().enabled = true;
    }
}
