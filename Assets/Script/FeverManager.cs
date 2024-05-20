using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FeverManager : MonoBehaviour
{
    [SerializeField] GameObject Effect;

    [SerializeField] Slider feverSlider = null;
    [SerializeField] float feverThreshold = 2.0f; // �ǹ�Ÿ���� ���۵Ǵ� �����̴� ���� �Ӱ�ġ

    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 10;


    ComboManager theComboManager;

    public bool feverTime = false; // �ǹ�Ÿ�� ���� Ȯ��

    // �����̴��� �̵� �ӵ�
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

        // �����̴� �ε巴�� �̵�
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
        feverSlider.value = currentScore / 1000f; // �ʱⰪ�� ���� ������ ����
        StartCoroutine(FeverTime());
    }

    IEnumerator FeverTime()
    {
        Effect.SetActive(true);
        float targetValue = 0f;
        float startingValue = feverSlider.value;
        float distance = Mathf.Abs(targetValue - startingValue);
        float duration = distance / sliderMoveSpeed; // �Ÿ��� �̵� �ӵ��� ������ �̵� �ð��� ���
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            feverSlider.value = Mathf.Lerp(startingValue, targetValue, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;  
        }

        feverSlider.value = targetValue; // ���� ��ǥ�� ����
        currentScore = 0; // �ǹ�Ÿ�� ���� �� ���� �ʱ�ȭ
        feverSlider.value = 0f; // �����̴��� �ʱ�ȭ
        feverTime = false; // �ǹ�Ÿ�� ����
        Effect.SetActive(false);
    }


}
