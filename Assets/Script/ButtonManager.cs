using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [Header("UI Panels")]
    public GameObject StagePanel;
    public GameObject Fadein;
    public GameObject CharPicPanel;
    public GameObject SettingPanel;
    public GameObject TitleSettingPanel;
    public GameObject VolumPanel;
    public GameObject CreditPanel;
    public GameObject MethodPanel;

    [Header("Other Components")]
    public Animator anim;
    public Music music;

    public bool isSetting = false;
    public bool isCharPanel = false;
    public bool isTitleSettingPanel = false;



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isSetting && !isCharPanel && SettingPanel != null)
        {
            SettingPanel.SetActive(true);
            if (music.audioSource.isPlaying) // 음악이 재생 중이라면 중단합니다.
                music.audioSource.Pause();
            isSetting = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isSetting && !isCharPanel)
        {
            SettingPanel.SetActive(false);
            if (!music.audioSource.isPlaying) // 음악이 중단되었다면 다시 재생합니다.
                music.audioSource.Play();
            isSetting = false;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isCharPanel)
        {
            CharPicPanel.SetActive(false);
            isCharPanel = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isTitleSettingPanel)
        {
            VolumPanel.SetActive(false);
            CreditPanel.SetActive(false);
            MethodPanel.SetActive(false);
            TitleSettingPanel.SetActive(false);
            isTitleSettingPanel = false;
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
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        isCharPanel = false;
        CharPicPanel.SetActive(false);
    }
    public void OnPic()
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1f, 1f), 1);
        OffTitleSetting();
        isCharPanel = true;
        StagerManager.instance.currentStage = StagerManager.Stage.CharPanel;
        CharPicPanel.SetActive(true);
    }




    public void OnTitleSetting()
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        OffPic();
        isTitleSettingPanel = true;
        StagerManager.instance.currentStage = StagerManager.Stage.TitleSettingPanel;
        TitleSettingPanel.SetActive(true);
    }
    public void OffTitleSetting()
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        isTitleSettingPanel = false;
        TitleSettingPanel.SetActive(false);
    }




    public void OnVolumPanel()
    {
        VolumPanel.SetActive(true);
    }
    public void OffVolumPanel()
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        VolumPanel.SetActive(false);
    }


    public void OnCreditPanel()
    {
        CreditPanel.SetActive(true);
    }
    public void OffCreditPanel()
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        CreditPanel.SetActive(false);
    }

    public void OnMethodPanel()
    {
        MethodPanel.SetActive(true);
    }
    public void OffMethodPanel()
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        MethodPanel.SetActive(false);
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
