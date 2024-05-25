using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audio;
    private int currentSongIndex = -1; // ���� ��� ���� ���� �ε���
    private bool isPlaying = false; // ��� ������ ���θ� ��Ÿ���� ����

    void Start()
    {
        audio = GetComponent<AudioSource>(); // AudioSource ������Ʈ�� ������
    }

    void PlaySong(int index)
    {
        // �̹� �ش� ���� ��� ���̸� �Լ��� ����
        if (currentSongIndex == index && isPlaying)
            return;

   
        audio.clip = songs[index];
        audio.Play();
        currentSongIndex = index; // ���� ��� ���� ���� �ε��� ������Ʈ
        isPlaying = true; // ��� ������ ǥ��
    }

   
    void Update()
    {
        // ���� ���������� ���� ���� ���
        if (StagerManager.instance.currentStage == StagerManager.Stage.FirstStage)
        {
            PlaySong(0);
        }
        else if (StagerManager.instance.currentStage == StagerManager.Stage.SecondStage)
        {
            PlaySong(1);
        }

        // ������ �������� Ȯ���ϰ�, ��� ���� ���� ������ isPlaying ������ false�� ����
        if (!audio.isPlaying)
        {
            isPlaying = false;
        }
    }
}
