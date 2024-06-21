using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DiePanel : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;

    void OnEnable()
    {
        StartCoroutine(CameraShakes());
        UpdateVideoClip();
    }

    void UpdateVideoClip()
    {
        if (DataManager.instance.currentCharater == Character.White)
        {
            videoPlayer.clip = videoClips[0];
        }
        else if (DataManager.instance.currentCharater == Character.Red)
        {
            videoPlayer.clip = videoClips[1];
        }
        else if (DataManager.instance.currentCharater == Character.Blue)
        {
            videoPlayer.clip = videoClips[2];
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
