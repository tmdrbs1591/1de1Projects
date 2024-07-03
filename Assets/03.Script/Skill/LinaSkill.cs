using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinaSkill : MonoBehaviour
{
    [SerializeField] private GameObject AutoBox;// 리나 스킬은 자동 공격이기 때문에 자동으로 하게 해주는 박스 추가
    [SerializeField] private GameObject SkillPanel; // 스킬 패널 
    [SerializeField] private GameObject SkillParticl; // 스킬 파티클
    
    void Start()
    {
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 나중에 키세팅 매니저에서 받아와서
        {
            SkillOn();
        }
    }

    public void SkillOn() // 스킬 온  버튼에서도 실행해야하기 때문에 public으로
    {
        StartCoroutine(SkillCor());
    }
    IEnumerator SkillCor()
    {

        CameraShake.instance.Shake();
        StartCoroutine(SkillPanelCor());
        SkillParticl.SetActive(true);
        AutoBox.SetActive(true);
        yield return new WaitForSeconds(5); // 5초동안 자동공격 시작
        AutoBox.SetActive(false);
        SkillParticl.SetActive(false);

    }
    IEnumerator SkillPanelCor()
    {
        SkillPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        SkillPanel.SetActive(false);

    }
}
