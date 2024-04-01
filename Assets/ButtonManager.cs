using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject StagePanel;
    public GameObject Fadein;
    public GameObject CharPicPanel;
    public Animator anim;
    public GameObject SettingPanel;
    public Music music;
    bool isSetting = false;

    void Start()
    {

    }


    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isSetting)
            {
                SettingPanel.SetActive(true);
                if (music.audioSource.isPlaying) // 음악이 재생 중이라면 중단합니다.
                    music.audioSource.Pause();
                isSetting = true;
                Time.timeScale = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isSetting)
            {
                SettingPanel.SetActive(false);
                if (!music.audioSource.isPlaying) // 음악이 중단되었다면 다시 재생합니다.
                    music.audioSource.Play();
                isSetting = false;
                Time.timeScale = 1;
            }
        }

    }
    public void Stop()
    {
        if (music.audioSource.isPlaying) // 음악이 재생 중이라면 중단합니다.
            music.audioSource.Pause();
        SettingPanel.SetActive(true);
        Time.timeScale = 0;     
    }
    public void Play()
    {
        if (!music.audioSource.isPlaying) // 음악이 중단되었다면 다시 재생합니다.
            music.audioSource.Play();
        SettingPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Retry(string Stage)
    {
        SceneManager.LoadScene(Stage);
        Time.timeScale = 1;

    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;

    }
    public void OpenStage()
    {
        StagePanel.SetActive(true);
    }
    public void CloseStage()
    {
        StagePanel.SetActive(false);
    }
    public void firstStage()
    {
        Fadein.SetActive(true);
        StartCoroutine(SceneLate());
        
    }
    public void OffPic()
    {
        CharPicPanel.SetActive(false);

    }
    public void OnPic()
    {
        CharPicPanel.SetActive(true);

    }
    public void SecondStage()
    {
        Fadein.SetActive(true);
        StartCoroutine(SceneLate2());

    }
    IEnumerator SceneLate()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(1);
    }
    IEnumerator SceneLate2()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(2);
    }
}
