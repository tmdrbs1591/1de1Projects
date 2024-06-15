using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TapManager : MonoBehaviour
{
    public GameObject[] Tap;
    private int currentIndex = 0;
    public ButtonManager buttonManager;
    public Image[] CharImage;
    public Image[] CharShadowImage;

    void Start()
    {
        TapClick(0);
    }
    
    public void TapClick(int n)
    {
        AudioManager.instance.PlaySound(transform.position, 9, Random.Range(1.0f, 1.0f), 1);

        for (int i = 0; i < Tap.Length; i++)
        {
            Tap[i].SetActive(i == n);
        }
        currentIndex = n;
    }
    public void TapClickRight()
    {
        if (currentIndex < Tap.Length - 1)
        {
            RightMove();

            TapClick(currentIndex + 1);
        }
    }
    public void TapClickLeft()
    {
        if (currentIndex > 0)
        {
            LeftMove();
            TapClick(currentIndex - 1);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && buttonManager.isCharPanel || Input.GetKeyDown(KeyCode.D) && buttonManager.isCharPanel)
        {
            if (currentIndex < Tap.Length - 1)
            {

                RightMove();
                TapClick(currentIndex + 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && buttonManager.isCharPanel || Input.GetKeyDown(KeyCode.A) && buttonManager.isCharPanel)
        {
            if (currentIndex > 0)
            {
                LeftMove();

                TapClick(currentIndex - 1);
            }
        }
    }
    void RightMove()
    {
        for (int i = 0; i < CharImage.Length; i++)
        {
            // 초기 위치로 이동 후, 이동 애니메이션 실행
            CharImage[i].rectTransform.anchoredPosition = new Vector2(1412, -563);
            CharImage[i].rectTransform.DOAnchorPos(new Vector2(-25, -568), 0.25f);
        }
        for (int i = 0; i < CharShadowImage.Length; i++)
        {
            // 초기 위치로 이동 후, 이동 애니메이션 실행
            CharShadowImage[i].rectTransform.anchoredPosition = new Vector2(1412, -563);
            CharShadowImage[i].rectTransform.DOAnchorPos(new Vector2(-25, -568), 0.3f);
        }
    }

    void LeftMove()
    {
        for (int i = 0; i < CharImage.Length; i++)
        {
            // 초기 위치로 이동 후, 이동 애니메이션 실행
            CharImage[i].rectTransform.anchoredPosition = new Vector2(-1412, -563);
            CharImage[i].rectTransform.DOAnchorPos(new Vector2(-25, -568), 0.25f);
        }
        for (int i = 0; i < CharShadowImage.Length; i++)
        {
            // 초기 위치로 이동 후, 이동 애니메이션 실행
            CharShadowImage[i].rectTransform.anchoredPosition = new Vector2(-1412, -563);
            CharShadowImage[i].rectTransform.DOAnchorPos(new Vector2(-25, -568), 0.3f);
        }
    }

}
