using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

[System.Serializable]
public class NoteInfo
{
    public string note;
    public float timing;
    public GameObject gameObject; // 노트에 대응하는 게임 오브젝트

    // 생성자
    public NoteInfo(string noteType, float time, GameObject obj)
    {
        note = noteType;
        timing = time;
        gameObject = obj;
    }
}

public class EditorManager : MonoBehaviour
{
    [SerializeField] List<NoteInfo> map = new List<NoteInfo>();
    public float time;
    public EditNote editQNote;
    public EditNote editWNote;
    public EditNote editENote;
    public EditNote editQWNote;
    public EditNote editEWNote;
    public EditNote editSpaceNote;
    public AudioSource audioSource;

    void Add(string noteType)
    {
        GameObject prefab = null;
        switch (noteType)
        {
            case "Q": prefab = editQNote.gameObject; break;
            case "W": prefab = editWNote.gameObject; break;
            case "E": prefab = editENote.gameObject; break;
            case "QW": prefab = editQWNote.gameObject; break;
            case "EW": prefab = editEWNote.gameObject; break;
            case "QWE": prefab = editSpaceNote.gameObject; break;
        }

        if (prefab != null)
        {
            GameObject noteObject = Instantiate(prefab); // 프리팹 복제
            EditNote editNoteComponent = noteObject.GetComponent<EditNote>();
            editNoteComponent.Sart(noteType, time); // 노트 초기화

            NoteInfo newNote = new NoteInfo(noteType, time, noteObject);
            map.Add(newNote);
        }
        else
        {
            Debug.LogError("Prefab not found for note type: " + noteType);
        }
    }

    void Save()
    {
#if UNITY_EDITOR
        SerializableList<NoteInfo> r = new SerializableList<NoteInfo>(); // 리스트를 제이슨으로 변환할 수 있게 변환
        r.list = map; // r.list에 저장
        var path = EditorUtility.SaveFilePanel("Save your map", Application.dataPath, DateTime.Now.ToString("yyyyMMddHHmmss") + ".json", "json"); // 저장하는 창 열기
        using (StreamWriter sw = new StreamWriter(path)) // 파일 저장
        {
            sw.WriteLine(JsonUtility.ToJson(r));
        }
#else
        Debug.LogError("Save can only be called from within the Unity Editor.");
#endif
    }

    void Start()
    {
        audioSource.Play();
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
            time += Mathf.Sign(Input.mouseScrollDelta.y) / 2;

        if (Input.GetKeyDown(KeyCode.Q)) Add("Q");
        if (Input.GetKeyDown(KeyCode.W)) Add("W");
        if (Input.GetKeyDown(KeyCode.E)) Add("E");
        if (Input.GetKeyDown(KeyCode.Alpha1)) Add("QW");
        if (Input.GetKeyDown(KeyCode.Alpha2)) Add("EW");

        // "QWE" 입력 시 0.1초 간격으로 계속 노트 추가
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (Time.time >= nextNoteTime)
            {
                Add("QWE");
                nextNoteTime = Time.time + 0.07f; // 다음 노트 시간 갱신
            }
        }

        // 백스페이스 입력 시 가장 최근에 추가된 노트 삭제
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (map.Count > 0)
            {
                // 가장 최근에 추가된 노트 삭제
                NoteInfo removedNote = map[map.Count - 1];
                map.RemoveAt(map.Count - 1);

                // 삭제된 노트의 게임 오브젝트도 삭제
                Destroy(removedNote.gameObject);

                Debug.Log("Removed note: " + removedNote.note + " at timing: " + removedNote.timing);
            }
            else
            {
                Debug.Log("Map is empty, nothing to remove.");
            }
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)) Save();

        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) { audioSource.Stop(); audioSource.Play(); time = 0; }
    }

    float nextNoteTime = 0f; // 다음 노트 추가 시간을 저장하는 변수

    [System.Serializable]
    public class SerializableList<T>
    {
        public List<T> list;
    }
}
