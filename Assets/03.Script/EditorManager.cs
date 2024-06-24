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

    public void Add(string noteType) { //�ʿ� �����ϴ� �Լ�
        NoteInfo added = new NoteInfo();
        added.note = noteType;
        added.timing = time;
        map.Add(added);
        GameObject a = null;
        switch (noteType)
        {
            case "Q": a = Instantiate(editQNote.gameObject); break; //q�� q���� �ӽ÷� ���̴� ������Ʈ
            case "W": a = Instantiate(editWNote.gameObject); break;
            case "E": a = Instantiate(editENote.gameObject); break;
            case "QW": a = Instantiate(editQWNote.gameObject); break;
            case "EW": a = Instantiate(editEWNote.gameObject); break;
            case "QWE": a = Instantiate(editSpaceNote.gameObject); break;
        }
        
        a.GetComponent<EditNote>().Sart(noteType, time); // ��ƮŸ���̶� Ÿ���� �����Ѵ�
    }

    

    void Save() {//����
        SerializableList<NoteInfo> r = new SerializableList<NoteInfo>(); // ����Ʈ�� ���̽� ���� ������ų���ְ� ��ȯ
        r.list = map;//r.list�� ����
        var path = EditorUtility.SaveFilePanel("Save your map", Application.dataPath, DateTime.Now + ".json", "json"); // �����ϴ� â ����
        using (StreamWriter sw = new StreamWriter(path,true))//��������
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

        // "QWE" �Է� �� 0.1�� �������� ��� ��Ʈ �߰�
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (Time.time >= nextNoteTime)
            {
                Add("QWE");
                nextNoteTime = Time.time + 0.07f; // ���� ��Ʈ �ð� ����
            }
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)) Save();

        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) time = 0;
    }

    float nextNoteTime = 0f; // ���� ��Ʈ �߰� �ð��� �����ϴ� ����

}
