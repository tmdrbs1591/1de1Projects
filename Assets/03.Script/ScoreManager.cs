using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text txtScore = null;

    [SerializeField] int increaseScore = 10;
    public int currentScore = 0;

    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 10;

    Animator myAnim;
    string animationScoreUp = "ScoreUp";

    ComboManager thecomboManager;

    void Start()
    {
        thecomboManager = FindObjectOfType<ComboManager>();
        myAnim = GetComponent<Animator>();
        currentScore = 0;
        txtScore.text = "0";
    }

  
   public void IncreaseScore(int p_JudgementState)
    {//�޺�����
        thecomboManager.IncreaseCombo();

        //�޺� ���ʽ� ���� ���
        int t_currentCombo = thecomboManager.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        int t_increateScore = increaseScore;
        //����ġ ���
        int t_increaseScore = increaseScore + t_bonusComboScore;    
        t_increateScore = (int)(t_increateScore * weight[p_JudgementState]);

        //���� �ݿ�
        currentScore += t_increateScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);
        //�ִϸ��̼�
        myAnim.SetTrigger(animationScoreUp);

    }
}
