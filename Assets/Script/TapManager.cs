using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TapManager : MonoBehaviour
{
    public GameObject[] Tap;
    private int currentIndex = 0;

    void Start()
    {
        TapClick(0);
    }

    public void TapClick(int n)
    {
        for (int i = 0; i < Tap.Length; i++)
        {
            Tap[i].SetActive(i == n);
        }
        currentIndex = n;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentIndex < Tap.Length - 1)
            {
                TapClick(currentIndex + 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentIndex > 0)
            {
                TapClick(currentIndex - 1);
            }
        }
    }
}
