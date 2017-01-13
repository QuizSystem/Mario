using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void ButtonPlay()
    {
        Application.LoadLevel("Level1");
    }
}
