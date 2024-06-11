using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearPanel : MonoBehaviour
{
    public Sprite[] sprites; // 스프라이트 배열을 선언하여 스프라이트를 저장합니다.
    public Image image;

    void OnEnable()
    {
        StartCoroutine(CameraShakes());
        image.sprite = sprites[0];

        if (DataManager.instance.currentCharater == Character.White)
        {
            image.sprite = sprites[0];
        }
        else if (DataManager.instance.currentCharater == Character.Red)
        {
            image.sprite = sprites[1];
        }
        else if (DataManager.instance.currentCharater == Character.Blue)
        {
            image.sprite = sprites[2];
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            LoadingManager.LoadScene("Title");
        }
    }

    IEnumerator CameraShakes()
    {
        yield return new WaitForSeconds(1.45f);
        CameraShake.instance.Shake();
    }
}
