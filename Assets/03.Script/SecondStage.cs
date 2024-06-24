using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SecondStage : ReFirstStage
{
    public GameObject powerEffect;
    void Start()
    {
        Song.Stop();
        thecomboManager = FindObjectOfType<ComboManager>();
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();

        if (DataManager.instance.songPath == null)
        {
            var path = EditorUtility.OpenFilePanel("Load wave", Application.dataPath, "json");
            using (StreamReader reader = new StreamReader(path))
            {
                notemap = JsonUtility.FromJson<EditorManager.SerializableList<NoteInfo>>(reader.ReadToEnd()).list;
            }
        }
        else
        {
            var path = Application.dataPath + DataManager.instance.songPath;
            using (StreamReader reader = new StreamReader(path))
            {
                notemap = JsonUtility.FromJson<EditorManager.SerializableList<NoteInfo>>(reader.ReadToEnd()).list;
            }
        }

        foreach (NoteInfo e in notemap)
        {
            allNotes++;
            maxNotes++;
            StartCoroutine(QueueToSpawn(e));
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
            ClearPanel.SetActive(true);
        }
        if (allNotes <= maxNotes - 10)
        {
            powerEffect.SetActive(true);
        }

        double beatInterval = 60d / bpm;

        currentTime += Time.deltaTime;
    }
}