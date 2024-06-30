using System.Collections;
using UnityEngine;

public class StageModeSoundManager : MonoBehaviour
{
    public AudioClip[] songs;
    public AudioSource audio;
    private int currentSongIndex = -1; // ���� ��� ���� ���� �ε���
    private bool isPlaying = false; // ��� ������ ���θ� ��Ÿ���� ����
    private float originalVolume; // ���� ���� �� ����

    void Start()
    {
        audio = GetComponent<AudioSource>(); // AudioSource ������Ʈ�� ������
        originalVolume = audio.volume; // ���� ���� ���� ����
    }

    void PlaySong(int index)
    {
        // �̹� �ش� ���� ��� ���̸� �Լ��� ����
        if (currentSongIndex == index && isPlaying)
            return;

        // �ڷ�ƾ�� ����Ͽ� ���� �ٲٰ� ������ ������ Ű��
        StartCoroutine(FadeInNewSong(index));
    }

    IEnumerator FadeInNewSong(int newIndex)
    {
        // ���ο� ���� ����
        audio.clip = songs[newIndex];
        audio.Play();
        currentSongIndex = newIndex;
        isPlaying = true;

        // ������ 0���� ���� ������ ������ Ű��
        audio.volume = 0;
        for (float v = 0; v <= originalVolume; v += Time.deltaTime * 0.9f)
        {
            audio.volume = v;
            yield return null;
        }

        // ������ ���� ������ ����
        audio.volume = originalVolume;
    }

    public void SetMusicVolume(float volume)
    {
        audio.volume = volume;
        originalVolume = volume;
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
