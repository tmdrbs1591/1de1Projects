using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class StageModeStageManager : MonoBehaviour
{
    public enum Stage
    {
        Main,
        FirstTheFirstStage,
        FirstTheSecondStage,
        FirstTheThirdStage,
        FirstThefourthStage,
        FirstThefifthStage,
        FirstTheSixthStage,
        FirstTheSeventhStage,
        FirstTheEighthStage,
       
    }

    public string[] songPath;

    public static StageModeStageManager instance;
    public GameObject Fadein;
    public ButtonManager buttonManager;

    bool isStart;

    [SerializeField] GameObject fixedPanel;

    bool charpanel = false;


    public Stage currentStage;

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
            Debug.Log("D");
        }
    }
    public void StartGame()
    {
        if (!isStart)
        {
            DataManager.instance.songPath = songPath[(int)currentStage];
            if (currentStage == Stage.FirstTheFirstStage)
            {
                AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);

                StartCoroutine(SceneLate("StagdeModeStage1"));
                Fadein.SetActive(true);

            }
            else if (currentStage == Stage.FirstTheSecondStage)
            {
                AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);

                Fadein.SetActive(true);
                StartCoroutine(SceneLate("Stage2"));
            }
            else if (currentStage == Stage.FirstTheThirdStage)
            {
                AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);

                Fadein.SetActive(true);
                StartCoroutine(SceneLate("StagdeModeStage1"));
            }
            else if (currentStage == Stage.FirstThefourthStage)
            {
                AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);

                Fadein.SetActive(true);
                StartCoroutine(SceneLate("StagdeModeStage1"));
            }
            else if (currentStage == Stage.FirstThefifthStage)
            {
                AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);

                Fadein.SetActive(true);
                StartCoroutine(SceneLate("StagdeModeStage1"));
            }
            else if (currentStage == Stage.FirstTheSixthStage)
            {
                AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);

                Fadein.SetActive(true);
                StartCoroutine(SceneLate("StagdeModeStage1"));
            }
            else if (currentStage == Stage.FirstTheSeventhStage)
            {
                AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);

                Fadein.SetActive(true);
                StartCoroutine(SceneLate("StagdeModeStage1"));
            }
            else if (currentStage == Stage.FirstTheEighthStage)
            {
                AudioManager.instance.PlaySound(transform.position, 2, Random.Range(1.0f, 1.0f), 1);

                Fadein.SetActive(true);
                StartCoroutine(SceneLate("StagdeModeStage1"));
            }
            else
            {
                //AudioManager.instance.PlaySound(transform.position, 5, Random.Range(1.0f, 1.0f), 1);
               // FixedPanel();
            }
        }

    }
    void FixedPanel()
    {
        fixedPanel.SetActive(false);
        fixedPanel.SetActive(true);
    }
    IEnumerator SceneLate(string sceneName)
    {
        isStart = true;
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(sceneName);
    }

    public void CharPanel()
    {
        charpanel = true;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }
}