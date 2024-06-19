using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [Header("UI Panels")]
    public GameObject StagePanel; // �������� ���� �г�
    public GameObject Fadein; //���̵��� �г�
    public GameObject CharPicPanel; //ĳ���� ���ϴ� â �г�
    public GameObject SettingPanel;//�ΰ��� ����â �г�
    public GameObject TitleSettingPanel;//Ÿ��Ʋ ����â �г�
    public GameObject VolumPanel; // �������� ���� �г�
    public GameObject CreditPanel; // ũ���� �г�
    public GameObject MethodPanel; // ����â �г�
    public GameObject ExitPanel; //�����г�
    public GameObject LanguagePanel; //����г�
    public GameObject KeySetPanel; //Ű�����г�

    [Header("Other Components")]
    public Animator anim;
    public Music music;

    public bool isSetting = false; // ���� ����â����
    public bool isCharPanel = false; // ���� ĳ���� â����
    public bool isTitleSettingPanel = false; // ���� Ÿ��Ʋ ���� â����



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isSetting && !isCharPanel && SettingPanel != null)
        {
            SettingPanel.SetActive(true);
            if (music.audioSource.isPlaying) // ������ ��� ���̶�� �ߴ��մϴ�.
                music.audioSource.Pause();
            isSetting = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isSetting && !isCharPanel)
        {
            SettingPanel.SetActive(false);
            if (!music.audioSource.isPlaying) // ������ �ߴܵǾ��ٸ� �ٽ� ����մϴ�.
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
    public void ButtonPanelOff()//��ư �гε� ����
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
        if (music.audioSource.isPlaying) // ������ ��� ���̶�� �ߴ��մϴ�.
            music.audioSource.Pause();
        SettingPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Play()
    {
        if (!music.audioSource.isPlaying) // ������ �ߴܵǾ��ٸ� �ٽ� ����մϴ�.
            music.audioSource.Play();
        SettingPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Retry(string Stage)//�ٽý���
    {
        SceneManager.LoadScene(Stage);
        Time.timeScale = 1;

    }
    public void Title()//Ÿ��Ʋ �� ����
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;

    }
    public void OpenStage() //�������� â ���� 
    {
        StagePanel.SetActive(true);
    }
    public void CloseStage()//�������� â �ݱ�
    {
        StagePanel.SetActive(false);
    }
    public void firstStage()
    {
        Fadein.SetActive(true);
        StartCoroutine(SceneLate());

    }



    public void OffPic()//ĳ���� ��â ���
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        isCharPanel = false;
        CharPicPanel.SetActive(false);
    }
    public void OnPic()//ĳ���� ��â ����
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1f, 1f), 1);

        ButtonPanelOff();
        OffTitleSetting();

        CharPicPanel.SetActive(true);
        isCharPanel = true;

        StagerManager.instance.currentStage = StagerManager.Stage.CharPanel;
    }




    public void OnTitleSetting()//����â ����
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        OffPic();
        isTitleSettingPanel = true;
        StagerManager.instance.currentStage = StagerManager.Stage.TitleSettingPanel;
        TitleSettingPanel.SetActive(true);
    }
    public void OffTitleSetting()//����â �ݱ�
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        isTitleSettingPanel = false;
        TitleSettingPanel.SetActive(false);
    }




    public void OnVolumPanel()//����â ����
    {
        VolumPanel.SetActive(true);
    }
    public void OffVolumPanel()//����â �ݱ�
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        VolumPanel.SetActive(false);
    }


    public void OnCreditPanel()//ũ���� â ����
    {
        CreditPanel.SetActive(true);
    }
    public void OffCreditPanel()//ũ���� â �ݱ�
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        CreditPanel.SetActive(false);
    }

    public void OnMethodPanel()//����â ����
    {
        MethodPanel.SetActive(true);
    }
    public void OffMethodPanel()//����â �ݱ�
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        MethodPanel.SetActive(false);
    }

    public void OnExitPanel()//�����г� ����
    {
        ExitPanel.SetActive(true);
    }
    public void OffExitPanel()//�����г� �ݱ�
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        ExitPanel.SetActive(false);
    }

    public void OnLanguagePanel()//����г� ����
    {
        LanguagePanel.SetActive(true);
    }
    public void OffLanguagePanel()//����г� �ݱ�
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        LanguagePanel.SetActive(false);
    }
    public void OnKeySetPanel()//����г� ����
    {
        KeySetPanel.SetActive(true);
    }
    public void OffKeySetPanel()//����г� �ݱ�
    {
        AudioManager.instance.PlaySound(transform.position, 7, Random.Range(1.0f, 1.0f), 1);

        KeySetPanel.SetActive(false);
    }
    public void GameExit()//��������
    {
        Application.Quit();
    }
    public void SecondStage()
    {
        Fadein.SetActive(true);
        StartCoroutine(SceneLate2());

    }
    IEnumerator SceneLate() // �� �ʰ� �̵�
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
