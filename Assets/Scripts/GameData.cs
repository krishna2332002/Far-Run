using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData 
{
    private static float _coins=0f;
    private static float _stars=0f;

    static GameData(){
        _coins=PlayerPrefs.GetFloat("Coins",0);
        _stars=PlayerPrefs.GetFloat("Stars",0);
    }

    public static float Coins{
        get{return _coins;}
        set{PlayerPrefs.SetFloat("Coins",(_coins=value));}
    }

    public static float Stars{
        get{return _stars;}
        set{PlayerPrefs.SetFloat("Stars",(_stars=value));}
    }
}
