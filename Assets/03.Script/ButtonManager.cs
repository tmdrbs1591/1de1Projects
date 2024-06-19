using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [Header("UI Panels")]
    public GameObject StagePanel; // 스테이지 고르는 패널
    public GameObject Fadein; //페이드인 패널
    public GameObject CharPicPanel; //캐릭터 픽하는 창 패널
    public GameObject SettingPanel;//인게임 설정창 패널
    public GameObject TitleSettingPanel;//타이틀 설정창 패널
    public GameObject VolumPanel; // 볼륨조절 세팅 패널
    public GameObject CreditPanel; // 크레딧 패널
    public GameObject MethodPanel; // 설명창 패널
    public GameObject ExitPanel; //종료패널
    public GameObject LanguagePanel; //언어패널
    public GameObject KeySetPanel; //키세팅패널

    [Header("Other Components")]
    public Animator anim;
    public Music music;

    public bool isSetting = false; // 현재 세팅창인지
    public bool isCharPanel = false; // 현재 캐릭터 창인지
    public bool isTitleSettingPanel = false; // 현재 타이틀 세팅 창인지



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
            ButtonPanelOff();
            isTitleSettingPanel = false;
        }
    }
    public void ButtonPanelOff()//버튼 패널들 끄기
    {
        VolumPanel.SetActive(false);
        CreditPanel.SetActive(false);
        MethodPanel.SetActive(false);
        TitleSettingPanel.SetActive(false);
        LanguagePanel.SetActive(false);
        KeySetPanel.SetActive(false);
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
    public void Retry(string Stage)//다시시작
    {
        SceneManager.LoadScene(Stage);
        Time.timeScale = 1;

    }
    public void Title()//타이틀 씬 가기
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;

    }
    public void OpenStage() //스테이지 창 열기 
    {
        StagePanel.SetActive(true);
    }
    public void CloseStage()//스테이지 창 닫기
    {
        StagePanel.SetActive(false);
    }
    public void firstStage()
    {
        Fadein.SetActive(true);
        StartCoroutine(SceneLate());

    }



    public void OffPic()//캐릭터 픽창 딛기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        isCharPanel = false;
        CharPicPanel.SetActive(false);
    }
    public void OnPic()//캐릭터 픽창 열기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1f, 1f), 1);

        ButtonPanelOff();
        OffTitleSetting();

        CharPicPanel.SetActive(true);
        isCharPanel = true;

        StagerManager.instance.currentStage = StagerManager.Stage.CharPanel;
    }




    public void OnTitleSetting()//설정창 열기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        OffPic();
        isTitleSettingPanel = true;
        StagerManager.instance.currentStage = StagerManager.Stage.TitleSettingPanel;
        TitleSettingPanel.SetActive(true);
    }
    public void OffTitleSetting()//설정창 닫기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        isTitleSettingPanel = false;
        TitleSettingPanel.SetActive(false);
    }




    public void OnVolumPanel()//볼륨창 열기
    {
        VolumPanel.SetActive(true);
    }
    public void OffVolumPanel()//볼륨창 닫기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        VolumPanel.SetActive(false);
    }


    public void OnCreditPanel()//크레딧 창 열기
    {
        CreditPanel.SetActive(true);
    }
    public void OffCreditPanel()//크레딧 창 닫기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        CreditPanel.SetActive(false);
    }

    public void OnMethodPanel()//설명창 열기
    {
        MethodPanel.SetActive(true);
    }
    public void OffMethodPanel()//설명창 닫기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        MethodPanel.SetActive(false);
    }

    public void OnExitPanel()//종료패널 열기
    {
        ExitPanel.SetActive(true);
    }
    public void OffExitPanel()//종료패널 닫기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        ExitPanel.SetActive(false);
    }

    public void OnLanguagePanel()//언어패널 열기
    {
        LanguagePanel.SetActive(true);
    }
    public void OffLanguagePanel()//언어패널 닫기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        LanguagePanel.SetActive(false);
    }
    public void OnKeySetPanel()//언어패널 열기
    {
        KeySetPanel.SetActive(true);
    }
    public void OffKeySetPanel()//언어패널 닫기
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        KeySetPanel.SetActive(false);
    }
    public void GameExit()//게임종료
    {
        Application.Quit();
    }
    public void SecondStage()
    {
        Fadein.SetActive(true);
        StartCoroutine(SceneLate2());

    }
    IEnumerator SceneLate() // 씬 늦게 이동
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
