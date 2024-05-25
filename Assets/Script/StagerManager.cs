using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StagerManager : MonoBehaviour
{
    public enum Stage
    {
        FirstStage,
        SecondStage,
        CharPanel
    }

    public static StagerManager instance;
    public GameObject Fadein;
    public ButtonManager buttonManager;
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
        // �̰Ÿ� ����� �ϳ��� �ε������� ���� �ٲٰ� �̰� �ٸ��ſ� �Ű� �ڷ�ƾ�̶� ����
        if (Input.GetKeyDown(KeyCode.Return) && !buttonManager.isCharPanel)
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
        }
    }
    IEnumerator SceneLate(int num)
    {
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