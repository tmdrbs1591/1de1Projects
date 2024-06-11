using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearPanel : MonoBehaviour
{
    public Sprite[] sprites; // ��������Ʈ �迭�� �����Ͽ� ��������Ʈ�� �����մϴ�.
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
