using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScorePanel : MonoBehaviour
{
    public ScoreManager theScoreManager;
    public TMP_Text Score;
    public TMP_Text Tear;

    [SerializeField] float S_Score;
    [SerializeField] float A_Score;
    [SerializeField] float B_Score;
    [SerializeField] float C_Score;
    [SerializeField] float D_Score;

    private int targetScore;
    private float animationDuration = 1.5f; // �ִϸ��̼� ���� �ð�
    private float animationStartTime; // �ִϸ��̼� ���� �ð�
    private float delayBeforeAnimation = 1f; // �ִϸ��̼� ���� �� ���� �ð�

    void Start()
    {
        animationStartTime = Time.time + delayBeforeAnimation;
        targetScore = theScoreManager.currentScore;
    }

    void Update()
    {
        // ���� �ð��� �ִϸ��̼� ���� �ð� ���� ��� �ð� ���� ���
        float elapsedTime = Time.time - animationStartTime;

        if (elapsedTime >= 0) // 3�� ���� �� �ִϸ��̼� ����
        {
            float elapsedTimeRatio = elapsedTime / animationDuration;
            int displayScore = Mathf.RoundToInt(Mathf.Lerp(0, targetScore, elapsedTimeRatio)); // ���� ������ ��ǥ �������� ������ ���� ���

            // ���� �ؽ�Ʈ ������Ʈ
            Score.text = "SCORE:" + displayScore.ToString();

            // �ִϸ��̼� ���� �Ŀ��� ���� ������ ǥ��
            if (elapsedTimeRatio >= 1.0f)
            {
                Score.text = "SCORE:" + targetScore.ToString();
            }

           
        }
        // ��� �ؽ�Ʈ ������Ʈ

        if (targetScore >= S_Score)
        {
            Tear.text = "S";
            //GoldManager.instance.CrearGold("S");
        }
        else if (targetScore >= A_Score)
            Tear.text = "A";
        else if (targetScore >= B_Score)
            Tear.text = "B";
        else if (targetScore >= C_Score)
            Tear.text = "C";
        else if (targetScore >= D_Score)
            Tear.text = "D";
        else
            Tear.text = "E";
    }
        
    public void Retry()
    {
        LoadingManager.LoadScene("Title");
    }
}
