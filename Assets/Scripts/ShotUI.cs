using UnityEngine;
using System.Collections;

public class ShotUI : MonoBehaviour {
    public float shootRate=0.2f;
    float shootCurrent;
    bool shoot = false;
 float bullet;
 public delegate void DlgShot();
 public static DlgShot dlgShot;
 PlayerControler player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerControler>();
        shootCurrent = shootRate;
	}
	
	// Update is called once per frame
	void Update () {
        shootCurrent += Time.deltaTime;
        if (shoot == true)
        {
//            PlayerControl.instancePlayer.anim.SetTrigger("Shot");
            shoot = false;
        }

	}
    void OnClick()
        
    {
        //shoot = true;
     
        //if (shootCurrent >= shootRate)
        //{
            //if (GameControler.instance.bulletItem > 0)
            //{
             //   Guns.gun.ShotBullet();
 //  player.ShotBullet();
        dlgShot.Invoke();
                
             //   GameControler.bulletItem--;
               // GameControler.instanceControler.bulletItem = PlayerPrefs.GetFloat("SaveBullet");
           //     GameControler.instance.bulletItem--;
               // Debug.Log("Bullet---"+ GameControler.instanceControler.bulletItem);
           //  bullet--;
     //       }
           
        //    shootCurrent = 0;
           
        }
       
    }

