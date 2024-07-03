using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinaSkill : MonoBehaviour
{
    [SerializeField] private GameObject AutoBox;// ���� ��ų�� �ڵ� �����̱� ������ �ڵ����� �ϰ� ���ִ� �ڽ� �߰�
    [SerializeField] private GameObject SkillPanel; // ��ų �г� 
    [SerializeField] private GameObject SkillParticl; // ��ų ��ƼŬ
    
    void Start()
    {
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ���߿� Ű���� �Ŵ������� �޾ƿͼ�
        {
            SkillOn();
        }
    }

    public void SkillOn() // ��ų ��  ��ư������ �����ؾ��ϱ� ������ public����
    {
        StartCoroutine(SkillCor());
    }
    IEnumerator SkillCor()
    {

        CameraShake.instance.Shake();
        StartCoroutine(SkillPanelCor());
        SkillParticl.SetActive(true);
        AutoBox.SetActive(true);
        yield return new WaitForSeconds(5); // 5�ʵ��� �ڵ����� ����
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
