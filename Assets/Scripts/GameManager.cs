using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public delegate void UpdateCoinsEvent(int scores);
    public static event UpdateCoinsEvent dlgUpdateCoins;
    public static int  sumcoins;
    public UILabel lableCoins;
    public GameObject levelFail;
    private bool isPaused;
    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }
    void Start () {
        sumcoins = 0;
	}
	void OnEnable()
    {
        dlgUpdateCoins += UpdateCoins;
    }
    void OnDisable()
    {
        dlgUpdateCoins -= UpdateCoins;
    }
    #region Update UI

    private void UpdateCoins(int coins)
    {
        lableCoins.text =""+ coins;
    }
    public  void LevelFailUI()
    {
        levelFail.GetComponent<TweenScale>().PlayForward();
        PauseGame();
    }
    #endregion
    #region Handle Button

    public void ButtonPause()
    {
        PauseGame();
    }
    public void ButtonResume()
    {
        ResumeGame();
    }
    public void ButtonReplay()
    {
        ResumeGame();
        Application.LoadLevel(Application.loadedLevel);
    }
    public void ButtonMenu()
    {
        ResumeGame();
        Application.LoadLevel("Menu");
    }
    #endregion
    #region Handle Delegate
    public static void UpdateCoinsDelegate(int coins)
    {
        if (dlgUpdateCoins != null)
            dlgUpdateCoins.Invoke(coins);
    }
    #endregion
    public void PauseGame()
    {
        if (!isPaused)
        {

            Time.timeScale = 0.0f;
            isPaused = true;

        }

    }


    public void ResumeGame()
    {
        if (isPaused)
        {

            Time.timeScale = 1.0f;
            isPaused = false;


        }
    }
}
