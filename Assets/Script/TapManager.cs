using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TapManager : MonoBehaviour
{
    public GameObject[] Tap;
    private int currentIndex = 0;
    public ButtonManager buttonManager;


    void Start()
    {
        TapClick(0);
    }

    public void TapClick(int n)
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        for (int i = 0; i < Tap.Length; i++)
        {
            Tap[i].SetActive(i == n);
        }
        currentIndex = n;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && buttonManager.isCharPanel|| Input.GetKeyDown(KeyCode.D) && buttonManager.isCharPanel)
        {
            if (currentIndex < Tap.Length - 1)
            {
                TapClick(currentIndex + 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && buttonManager.isCharPanel || Input.GetKeyDown(KeyCode.A) && buttonManager.isCharPanel)
        {
            if (currentIndex > 0)
            {
                TapClick(currentIndex - 1);
            }
        }
    }
}
