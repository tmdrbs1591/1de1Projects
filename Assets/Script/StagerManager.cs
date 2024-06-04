using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class StagerManager : MonoBehaviour
{
    public enum Stage
    {
        FirstStage,
        SecondStage,
        ThirdStage,
        fourthStage,
        fifthStage,
        CharPanel,
        TitleSettingPanel
    }

    public static StagerManager instance;
    public GameObject Fadein;
    public ButtonManager buttonManager;

    bool isStart;

    [SerializeField] GameObject fixedPanel; 

    bool charpanel = false;


    public Stage currentStage;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void Update()
    {
        // 이거를 지우고 하나의 로딩씬으로 가게 바꾸고 이걸 다른거에 옮겨 코루틴이랑 같이
        if (Input.GetKeyDown(KeyCode.Return) && !buttonManager.isCharPanel && !buttonManager.isTitleSettingPanel)
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        if (!isStart)
        {
        if (currentStage == Stage.FirstStage)
        {
            AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);
            CameraShake.instance.Shake();

            Fadein.SetActive(true);
            StartCoroutine(SceneLate(1));
        }
        else if (currentStage == Stage.SecondStage)
        {
            AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);
            CameraShake.instance.Shake();

            Fadein.SetActive(true);
            StartCoroutine(SceneLate(2));
        }
        else if (currentStage == Stage.ThirdStage)
        {
            AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);
            CameraShake.instance.Shake();

            Fadein.SetActive(true);
            StartCoroutine(SceneLate(3));
        }
        else
        {
            AudioManager.instance.PlaySound(transform.position, 5, Random.Range(1.0f, 1.0f), 1);
            FixedPanel();
        }
        }

    }
    void FixedPanel()
    {
        fixedPanel.SetActive(false);
        fixedPanel.SetActive(true);
    }
    IEnumerator SceneLate(int num)
    {
        isStart = true;
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(num);
    }

    public void CharPanel()
    {
        charpanel = true;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }
}