using UnityEngine;
using System.Collections;

public class ToggleMusic : MonoBehaviour {

  public  bool stateMusic = false;
    UIToggle toggMusic;
    public static ToggleMusic instance;
    // Use this for initialization
    void Start()
    {
        instance = this;
        toggMusic = GetComponent<UIToggle>();
        toggMusic.value =PlayerPrefsPlus.GetBool("MUSIC");
    }
    public void ToogleMusicNGUI()
    {
        PlayerPrefsPlus.SetBool("MUSIC",toggMusic.value);
        AudioManager.Instance.bgMusic.mute =toggMusic.value;
    }
}
