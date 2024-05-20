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
    [SerializeField]
    TMP_Text titlename;

 

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
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

                targetIndex++;
                targetPos = pos[targetIndex];
            }
        }
        if (targetIndex > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AudioManager.instance.PlaySound(transform.position, 3, Random.Range(1f, 1f), 1);

                targetIndex--;
                targetPos = pos[targetIndex];
            }
        }
        if (!isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);

        if (scrollbar.value >= 0.8f && scrollbar.value <= 1f)
        {
            titlename.text = "5.AAAAAAAAAAAA";
        }
        if (scrollbar.value >= 0.55f && scrollbar.value <= 0.78f)
        {
            titlename.text = "4.NOOOOOOO";
        }
        if (scrollbar.value >= 0.31f && scrollbar.value <= 0.54f)
        {
            titlename.text = "3.Hello";
        }
        if (scrollbar.value >= 0.1f && scrollbar.value <= 0.3f)
        {
            StagerManager.instance.currentStage = StagerManager.Stage.SecondStage;
            titlename.text = "2.Nitro Fun - Final Boss";
        }
        if (scrollbar.value <= 0.2f)
        {
            StagerManager.instance.currentStage = StagerManager.Stage.FirstStage;
            titlename.text = "1.A Dance of Fire and Ice";
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
