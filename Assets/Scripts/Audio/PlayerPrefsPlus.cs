using UnityEngine;
using System.Collections;


public class PlayerPrefsPlus : MonoBehaviour
{
    public static void SetBool(string key, bool value)
    {
        if (value)
            PlayerPrefs.SetInt("PlayerPrefsPlus:bool:" + key, 1);
        else
            PlayerPrefs.SetInt("PlayerPrefsPlus:bool:" + key, 0);
    }

    public static bool GetBool(string key)
    {
        return GetBool(key, false);
    }

    public static bool GetBool(string key, bool defaultValue)
    {
        int value = PlayerPrefs.GetInt("PlayerPrefsPlus:bool:" + key, 2);
        if (value == 2)     //Return default
            return defaultValue;
        else if (value == 1)    //Return true
            return true;
        else                    //Return false
            return false;
    }


}
