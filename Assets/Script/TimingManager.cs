using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
     PlaayerController thePlayerController;
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;

    Vector2[] timingBoxs = null;

    EffectManager theEffect;
    ScoreManager theScoreManager;
    ComboManager thecomboManager;
    FeverManager theFeverManager;

    public FeverManager feverManager;
    public GameObject EffectPrefab;
    public GameObject childEffectPrefab;
    public GameObject FeverchildEffectPrefab;
    public GameObject laserRotation;
    public SecondStage secondStage;
    public bool camerashake = true;

    private void Update()
    {
        
    }
    void Start()
    {
        // 현재 활성화된 GameObject에서 스크립트를 찾음
        thePlayerController = gameObject.GetComponent<PlaayerController>();
        theFeverManager = FindObjectOfType<FeverManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theEffect = FindObjectOfType<EffectManager>();
        thecomboManager = FindObjectOfType<ComboManager>();

        timingBoxs = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    SetActiveRecursively(boxNoteList[i], false);
                    boxNoteList.RemoveAt(i);

                    if (x < timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();

                    theEffect.judgementEffect(x);
                    return;
                }
            }
        }
        theEffect.judgementEffect(timingBoxs.Length);
    }

    public void CheckTimingWithKey(string key)
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            Note noteComponent = boxNoteList[i].GetComponent<Note>();
            if (noteComponent != null && noteComponent.noteKey == key)
            {
                float t_notePosX = boxNoteList[i].transform.localPosition.x;

                for (int x = 0; x < timingBoxs.Length; x++)
                {
                    if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                    {
                        AudioManager.instance.PlaySound(transform.position, 0, Random.Range(1f, 1f), 1);
                        if (camerashake) { 
                            CameraShake.instance.Shake();
                        }

                       
                        GameObject parentEffect = Instantiate(EffectPrefab, boxNoteList[i].transform.position, Quaternion.identity);
                        Destroy(parentEffect, 2f);
                        foreach (Transform child in boxNoteList[i].transform)
                        {
                            if (!feverManager.feverTime)
                            {
                                Destroy(Instantiate(childEffectPrefab, child.position, Quaternion.identity, parentEffect.transform),2f);
                            }
                            else
                            {
                                Destroy(Instantiate(FeverchildEffectPrefab, child.position, Quaternion.identity, parentEffect.transform),2f);
                            }
                           
                        }

                        SetActiveRecursively(boxNoteList[i], false);
                        GameObject destroyedNote = boxNoteList[i];
                        boxNoteList.RemoveAt(i);

                        if (x < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();

                        theScoreManager.IncreaseScore(x);
                        theEffect.judgementEffect(x);
                        theFeverManager.IncreaseFever(x);

                        Destroy(destroyedNote);

                        return;
                    }
                }
            }
        }
       // thePlayerController.CurHP--;
        //thecomboManager.ResetCombo();
        theEffect.judgementEffect(timingBoxs.Length);
    }

    void SetActiveRecursively(GameObject obj, bool active)
    {
        obj.SetActive(active);
        foreach (Transform child in obj.transform)
        {
            SetActiveRecursively(child.gameObject, active);
        }
    }
}
