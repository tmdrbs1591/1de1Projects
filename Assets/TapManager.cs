using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapManager : MonoBehaviour
{


    public GameObject[] Tap;

    void Start() => TapClick(0);

    public void TapClick(int n)
    {
        for (int i = 0; i < Tap.Length; i++)
        {

            Tap[i].SetActive(i == n);
        }
    }
}
