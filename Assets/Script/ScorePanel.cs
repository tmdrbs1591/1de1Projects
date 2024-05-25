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
    private float animationDuration = 1.5f; // 애니메이션 지속 시간
    private float animationStartTime; // 애니메이션 시작 시간

    void Start()
    {
        animationStartTime = Time.time;
        targetScore = theScoreManager.currentScore;
    }

    void Update()
    {
        // 현재 시간과 애니메이션 시작 시간 간의 경과 시간 비율 계산
        float elapsedTimeRatio = (Time.time - animationStartTime) / animationDuration;
        int displayScore = Mathf.RoundToInt(Mathf.Lerp(0, targetScore, elapsedTimeRatio)); // 시작 값부터 목표 값까지의 보간된 값을 계산

        // 점수 텍스트 업데이트
        Score.text = "점수:" + displayScore.ToString();

        // 애니메이션 종료 후에는 실제 점수를 표시
        if (elapsedTimeRatio >= 1.0f)
        {
            Score.text = "점수:" + targetScore.ToString();
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
