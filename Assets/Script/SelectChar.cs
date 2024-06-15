using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character;
    SpriteRenderer spriteRenderer;
    public SelectChar[] chars;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSelection();
    }

    void Update()
    {
        // Ȱ��ȭ�Ǿ� �ִ� ĳ���Ͱ� ����� ������ ���� ������Ʈ
        if (DataManager.instance.currentCharater != character)
        {
            UpdateSelection();
        }
    }

    private void OnMouseUpAsButton()
    {
        DataManager.instance.currentCharater = character;
        UpdateSelection();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != this && chars[i] != null)
                chars[i].UpdateSelection();
        }
    }

    void UpdateSelection()
    {
        if (DataManager.instance.currentCharater == character)
            OnSelect();
        else
            OnDeSelect();
    }

    void OnDeSelect()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = Color.white;
    }

    void OnSelect()
    {

        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
            AudioManager.instance.PlaySound(transform.position, 10, Random.Range(1.0f, 1.0f), 1);

        }


    }
}
