using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class NestedScrollManager : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Scrollbar scrollbar;
    const int SIZE = 10;
    float[] pos = new float[SIZE];
    float distance,curPos,targetPos;
    bool isDrag;
    int targetIndex;

    [SerializeField]  TMP_Text titlename;

    [SerializeField]  TMP_Text tracks;

    [SerializeField] GameObject[] Wave;
    

    [SerializeField] ButtonManager buttonManager;

 

    void Start()
    {
        distance = 1f/(SIZE-1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
       
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        curPos = SetPos();

    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;

        targetPos = SetPos();
        AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

        if (curPos == targetPos)
        {
            if (eventData.delta.x > 18 && curPos - distance >= 0)
            {

                --targetIndex;
                targetPos = curPos - distance;
            }
            else if(eventData.delta.x < -18 && curPos + distance <= 1.01f)
            {

                ++targetIndex;
                targetPos = curPos + distance;
            }
        }
    }
    float SetPos()
    {
        for (int i = 0; i < SIZE; i++)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        return 0;
    }
    public void NextStage()
    {
        scrollbar.value += 0.25f;

    }
    void Update()
    {
        if (targetIndex < SIZE - 1) //�뷡 ���������� �̵�
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && !buttonManager.isCharPanel || Input.GetKeyDown(KeyCode.D) && !buttonManager.isCharPanel)
            {
                AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

                targetIndex++;
                targetPos = pos[targetIndex];
            }
        }
        if (targetIndex > 0) //�뷡 �������� �̵�
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !buttonManager.isCharPanel || Input.GetKeyDown(KeyCode.A) && !buttonManager.isCharPanel)
            {
                AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

                targetIndex--;
                targetPos = pos[targetIndex];
            }
        }
        if (!isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);

        //Ư�� �������� ���� �뷡 ���� ���
       
       
     
        if (scrollbar.value <= 0.07f && !buttonManager.isCharPanel && !buttonManager.isTitleSettingPanel)
        {
            SetStage(StagerManager.Stage.FirstStage, "Lian Ai Audio Navigation","3Track",0);
        }
        else if (scrollbar.value >= 0.08f && scrollbar.value <= 0.18f && !buttonManager.isCharPanel && !buttonManager.isTitleSettingPanel)
        {
            SetStage(StagerManager.Stage.SecondStage, "Nitro Fun - Final Boss", "3Track", 1);
        }
        else if (scrollbar.value >= 0.19f && scrollbar.value <= 0.28f && !buttonManager.isCharPanel && !buttonManager.isTitleSettingPanel)
        {
            SetStage(StagerManager.Stage.ThirdStage, "IyaIya", "3Track", 2);
        }
        else if (scrollbar.value >= 0.29f && scrollbar.value <= 0.38f && !buttonManager.isCharPanel && !buttonManager.isTitleSettingPanel)
        {
            SetStage(StagerManager.Stage.fourthStage, "������", "", 3);
        }
        else if (scrollbar.value >= 0.39f && scrollbar.value <= 0.5f && !buttonManager.isCharPanel && !buttonManager.isTitleSettingPanel)
        {
            SetStage(StagerManager.Stage.fifthStage, "Gritty Dash", "4Track", 4);
        }
        else if (scrollbar.value >= 0.51f  && !buttonManager.isCharPanel && !buttonManager.isTitleSettingPanel)
        {
            SetStage(StagerManager.Stage.fourthStage, "������", "", 3);
        }
       
    }
    void SetStage(StagerManager.Stage stage, string title, string track, int waveIndex) //�������� ����
    {
        StagerManager.instance.currentStage = stage;
        titlename.text = title;
        tracks.text = track;

        // ��� Wave ������Ʈ�� ��Ȱ��ȭ
        for (int i = 0; i < Wave.Length; i++)
        {
            Wave[i].SetActive(i == waveIndex);
        }
    }
    public void TabClick() //�뷡 ���������� �̵�
    {
        if (targetIndex < SIZE - 1) 
        {
            AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);
            targetIndex++;
            targetPos = pos[targetIndex];
        }
    }

    public void TabBackClick()//�뷡 �������� �̵�
    {
        if (targetIndex > 0) 
        {
            AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

            targetIndex--;
            targetPos = pos[targetIndex];
        }
    }

}
