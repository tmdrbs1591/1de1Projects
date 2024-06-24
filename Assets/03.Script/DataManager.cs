using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    White,Red,Blue,Green
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance; 
    void Start()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }



    public Character currentCharater;
    public string songPath;

}
