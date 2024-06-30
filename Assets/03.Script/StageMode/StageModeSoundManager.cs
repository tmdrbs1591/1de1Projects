using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageModeSoundManager : MonoBehaviour
{
    public AudioClip[] songs;
    public AudioSource audio;
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

    public void SetMusicVolume(float volume)
    {
        audio.volume = volume;
    }
    void Update()
    {
        // ���� ���������� ���� ���� ���
        if (StageModeStageManager.instance.currentStage == StageModeStageManager.Stage.FirstTheFirstStage)
        {
            PlaySong(1);
        }
        else if (StageModeStageManager.instance.currentStage == StageModeStageManager.Stage.FirstTheSecondStage)
        {
            PlaySong(2);
        }
        else if (StageModeStageManager.instance.currentStage == StageModeStageManager.Stage.FirstTheThirdStage)
        {
            PlaySong(3);
        }
        else if (StageModeStageManager.instance.currentStage == StageModeStageManager.Stage.FirstThefourthStage)
        {
            PlaySong(4);
        }
        else if (StageModeStageManager.instance.currentStage == StageModeStageManager.Stage.FirstThefifthStage)
        {
            PlaySong(5);
        }
        else if (StageModeStageManager.instance.currentStage == StageModeStageManager.Stage.FirstTheSixthStage)
        {
            PlaySong(6);
        }
        else if (StageModeStageManager.instance.currentStage == StageModeStageManager.Stage.FirstTheSeventhStage)
        {
            PlaySong(7);
        }
        else if (StageModeStageManager.instance.currentStage == StageModeStageManager.Stage.FirstTheEighthStage)
        {
            PlaySong(8);
        }
        else
        {
            PlaySong(0);
        }


        // ������ �������� Ȯ���ϰ�, ��� ���� ���� ������ isPlaying ������ false�� ����
        if (!audio.isPlaying)
        {
            isPlaying = false;
        }
    }
}
