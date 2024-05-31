using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class NestedScrollManager : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Scrollbar scrollbar;
    const int SIZE = 5;
    float[] pos = new float[SIZE];
    float distance,curPos,targetPos;
    bool isDrag;
    int targetIndex;

    [SerializeField]  TMP_Text titlename;

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
        if (targetIndex < SIZE - 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && !buttonManager.isCharPanel || Input.GetKeyDown(KeyCode.D) && !buttonManager.isCharPanel)
            {
                AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

                targetIndex++;
                targetPos = pos[targetIndex];
            }
        }
        if (targetIndex > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !buttonManager.isCharPanel || Input.GetKeyDown(KeyCode.A) && !buttonManager.isCharPanel)
            {
                AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

                targetIndex--;
                targetPos = pos[targetIndex];
            }
        }
        if (!isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);

        if (scrollbar.value >= 0.8f && scrollbar.value <= 1f && !buttonManager.isCharPanel)
        {
            SetStage(StagerManager.Stage.fifthStage, "개발중", 4);
        }
        if (scrollbar.value >= 0.55f && scrollbar.value <= 0.78f && !buttonManager.isCharPanel)
        {
            SetStage(StagerManager.Stage.fourthStage, "개발중", 3);
        }
        if (scrollbar.value >= 0.31f && scrollbar.value <= 0.54f && !buttonManager.isCharPanel)
        {
            SetStage(StagerManager.Stage.ThirdStage, "IyaIya", 2);
        }
        if (scrollbar.value >= 0.1f && scrollbar.value <= 0.3f && !buttonManager.isCharPanel)
        {
            SetStage(StagerManager.Stage.SecondStage, "Nitro Fun - Final Boss", 1);
        }
        if (scrollbar.value <= 0.09f && !buttonManager.isCharPanel)
        {
            SetStage(StagerManager.Stage.FirstStage, "A Dance of Fire and Ice", 0);
        }
    }
    void SetStage(StagerManager.Stage stage, string title, int waveIndex) //스테이지 설정
    {
        StagerManager.instance.currentStage = stage;
        titlename.text = title;

        // 모든 Wave 오브젝트를 비활성화
        for (int i = 0; i < Wave.Length; i++)
        {
            Wave[i].SetActive(i == waveIndex);
        }
    }
    public void TabClick()
    {
        if (targetIndex < SIZE - 1) 
        {
            AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);
            targetIndex++;
            targetPos = pos[targetIndex];
        }
    }

    public void TabBackClick()
    {
        if (targetIndex > 0) 
        {
            AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

            targetIndex--;
            targetPos = pos[targetIndex];
        }
    }

}
