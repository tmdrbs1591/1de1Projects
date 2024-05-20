using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FeverManager : MonoBehaviour
{
    [SerializeField] GameObject Effect;

    [SerializeField] Slider feverSlider = null;
    [SerializeField] float feverThreshold = 2.0f; // 피버타임이 시작되는 슬라이더 값의 임계치

    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 10;


    ComboManager theComboManager;

    public bool feverTime = false; // 피버타임 여부 확인

    // 슬라이더의 이동 속도
    float sliderMoveSpeed = 0.1f;
        
    void Start()
    {
        theComboManager = FindObjectOfType<ComboManager>();
        currentScore = 0;
    }

    void Update()
    {
        if (feverSlider.value >= feverThreshold)
        {
            StartFeverTime();
        }

        // 슬라이더 부드럽게 이동
        if (!feverTime)
        {
            feverSlider.value = Mathf.MoveTowards(feverSlider.value, (float)currentScore / 1000f, sliderMoveSpeed * Time.deltaTime);
        }
    }

    public void IncreaseFever(int judgementState)
    {

        int currentCombo = theComboManager.GetCurrentCombo();
        int bonusComboScore = (currentCombo / 10) * comboBonusScore;

        int scoreIncrease = increaseScore;
        scoreIncrease = (int)(scoreIncrease * weight[judgementState]);

        if (feverTime)
        {
            scoreIncrease *= 2;
        }

        currentScore += scoreIncrease;
    }

    void StartFeverTime()
    {
        feverTime = true;
        feverSlider.value = currentScore / 1000f; // 초기값을 현재 값으로 설정
        StartCoroutine(FeverTime());
    }

    IEnumerator FeverTime()
    {
        Effect.SetActive(true);
        float targetValue = 0f;
        float startingValue = feverSlider.value;
        float distance = Mathf.Abs(targetValue - startingValue);
        float duration = distance / sliderMoveSpeed; // 거리를 이동 속도로 나누어 이동 시간을 계산
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            feverSlider.value = Mathf.Lerp(startingValue, targetValue, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;  
        }

        feverSlider.value = targetValue; // 최종 목표값 설정
        currentScore = 0; // 피버타임 종료 후 점수 초기화
        feverSlider.value = 0f; // 슬라이더도 초기화
        feverTime = false; // 피버타임 종료
        Effect.SetActive(false);
    }


}
