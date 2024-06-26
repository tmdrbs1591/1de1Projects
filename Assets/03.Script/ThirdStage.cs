using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ThirdStage : ReFirstStage
{
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
            //빌드랑 공유된 리소스 파일에서 가져오기
            var jsonString = (TextAsset)Resources.Load(DataManager.instance.songPath);
            notemap = JsonUtility.FromJson<EditorManager.SerializableList<NoteInfo>>(jsonString.text).list;
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
            ClearPanel.SetActive(true);
        }
      

        double beatInterval = 60d / bpm;

        currentTime += Time.deltaTime;
    }
}