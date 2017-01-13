using UnityEngine;
using System.Collections;

public class MoveUI : MonoBehaviour
{
  public  float direct = 1.0f;
    bool mHover = false;
    PlayerControler player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerControler>();
	}

    void FixedUpdate()
    {
        if (mHover)
        {
            player.MovePlayer(direct);
        }
           
    }
    void OnPress(bool isOver)
    {

        mHover = isOver;
      

    }
}
