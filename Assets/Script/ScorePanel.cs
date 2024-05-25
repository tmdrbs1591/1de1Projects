using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScorePanel : MonoBehaviour
{
    public ScoreManager theScoreManager;
    public TMP_Text Score;

    private int targetScore;
    private float animationDuration = 1.5f; // �ִϸ��̼� ���� �ð�
    private float animationStartTime; // �ִϸ��̼� ���� �ð�

    void Start()
    {
        animationStartTime = Time.time;
        targetScore = theScoreManager.currentScore;
    }

    void Update()
    {
        // ���� �ð��� �ִϸ��̼� ���� �ð� ���� ��� �ð� ���� ���
        float elapsedTimeRatio = (Time.time - animationStartTime) / animationDuration;
        int displayScore = Mathf.RoundToInt(Mathf.Lerp(0, targetScore, elapsedTimeRatio)); // ���� ������ ��ǥ �������� ������ ���� ���

        // ���� �ؽ�Ʈ ������Ʈ
        Score.text = "����:" + displayScore.ToString();

        // �ִϸ��̼� ���� �Ŀ��� ���� ������ ǥ��
        if (elapsedTimeRatio >= 1.0f)
        {
            Score.text = "����:" + targetScore.ToString();
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
