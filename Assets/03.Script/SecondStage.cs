using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class SecondStage : ReFirstStage
{
    public GameObject powerEffect;
    public GameObject powerMap;

    void Start()
    {
        Song.Stop();
        thecomboManager = FindObjectOfType<ComboManager>();
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();

#if UNITY_EDITOR
        if (DataManager.instance.songPath == null) // 메인메뉴에서 고른게 없으면
        {
            // 창을 띄워서 할당하게 파일을
            var path = EditorUtility.OpenFilePanel("Load wave", Application.dataPath, "json");
            using (StreamReader reader = new StreamReader(path))
            {
                notemap = JsonUtility.FromJson<EditorManager.SerializableList<NoteInfo>>(reader.ReadToEnd()).list;
            }
        }
        else //그게 아니면
        {
            //데이터 매니저에서 정보 받아와서 할당
            var path = Application.dataPath + DataManager.instance.songPath;//경로
            using (StreamReader reader = new StreamReader(path)) //파일을 제이슨으로 받아와서 변환
            {
                notemap = JsonUtility.FromJson<EditorManager.SerializableList<NoteInfo>>(reader.ReadToEnd()).list;
            }
        }
#else
        Debug.LogError("Song path can only be set in the Unity Editor.");
#endif

        foreach (NoteInfo e in notemap)
        {
            allNotes++;
            maxNotes++;
            StartCoroutine(QueueToSpawn(e)); // 빋아온다
        }
    }

    void FixedUpdate()
    {
        if (thePlayerController != null)
        {
            thePlayerController = FindObjectOfType<PlaayerController>();

        }
        if (allNotes <= 0)
        {
            StartCoroutine(Clear(5f));
        }
        if (allNotes == maxNotes - 112)
        {
            powerMap.SetActive(true);
            map.MapSpeed *= 3;
        }

        if (allNotes == maxNotes - 154)
        {
            StartCoroutine(EffectTrue(0.45f, powerEffect));
        }
        if (allNotes == maxNotes - 155)
        {
            map.MapSpeed *= 3;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(maxNotes - allNotes);
        }
        double beatInterval = 60d / bpm;

        currentTime += Time.deltaTime;
    }
}