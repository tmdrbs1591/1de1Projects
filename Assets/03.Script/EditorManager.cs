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
}
public class EditorManager : MonoBehaviour
{
    public class SerializableList<T> {
        public List<T> list;
    }

    [SerializeField] List<NoteInfo> map = new List<NoteInfo>();

    public float time;

    public NoteInfo[] noteList;
    public EditNote editQNote;
    public EditNote editWNote;
    public EditNote editENote;
    public EditNote editQWNote;
    public EditNote editEWNote;
    public EditNote editSpaceNote;

    public void Add(string noteType) { //맵에 저장하는 함수
        NoteInfo added = new NoteInfo();
        added.note = noteType;
        added.timing = time;
        map.Add(added);
        GameObject a = null;
        switch (noteType)
        {
            case "Q": a = Instantiate(editQNote.gameObject); break; //q면 q생성 임시로 보이는 오브젝트
            case "W": a = Instantiate(editWNote.gameObject); break;
            case "E": a = Instantiate(editENote.gameObject); break;
            case "QW": a = Instantiate(editQWNote.gameObject); break;
            case "EW": a = Instantiate(editEWNote.gameObject); break;
            case "QWE": a = Instantiate(editSpaceNote.gameObject); break;
        }
        
        a.GetComponent<EditNote>().Sart(noteType, time); // 노트타임이랑 타입을 저장한다
    }

    

    void Save() {//저장
        SerializableList<NoteInfo> r = new SerializableList<NoteInfo>(); // 리스트를 제이슨 으로 변형시킬수있게 변환
        r.list = map;//r.list에 저장
        var path = EditorUtility.SaveFilePanel("Save your map", Application.dataPath, DateTime.Now + ".json", "json"); // 저장하는 창 열기
        using (StreamWriter sw = new StreamWriter(path,true))//파일저장
        {
            sw.WriteLine(JsonUtility.ToJson(r)); 
        }
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

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)) Save();

        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) time = 0;
    }

    float nextNoteTime = 0f; // 다음 노트 추가 시간을 저장하는 변수

}
