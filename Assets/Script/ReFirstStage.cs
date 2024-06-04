using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFirstStage : MonoBehaviour
{
    public ParallaxScroll map;
    public GameObject SpeedEffect;
    public GameObject ClearPanel;
    public GameObject Warning;
    public PlaayerController thePlayerController;
    public int bpm = 120;
    double currentTime = 0d;
    int noteCount = 0; // 생성된 노트의 수

    enum BeatType
    {
        Whole = 1,
        Half = 2,
        Quarter = 4,
        Eighth = 8,
        Sixteenth = 16
    }

    public ObjectManager objectManager;
    public GameObject PowerEffect;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject go1 = null;
    [SerializeField] GameObject go2 = null;
    [SerializeField] GameObject go3 = null;
    [SerializeField] GameObject go4 = null;
    [SerializeField] GameObject go5 = null;
    [SerializeField] GameObject go6 = null;

    TimingManager theTimingManager;
    EffectManager theEffectManager;
    ComboManager thecomboManager;

    void Start()
    {

        thecomboManager = FindObjectOfType<ComboManager>();
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
    }

    void FixedUpdate()
    {
        if (thePlayerController != null)
        {
            thePlayerController = FindObjectOfType<PlaayerController>();

        }

        double beatInterval = 60d / bpm;

        currentTime += Time.deltaTime;
        #region beat

        if (noteCount < 1)
        {
            if (currentTime >= beatInterval * 4.4f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 4.4f;
                noteCount++;
            }
        }
        else if (noteCount < 3)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 6)
        {
            if (currentTime >= beatInterval * 2)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.75f;
                noteCount++;
            }
        }
        else if (noteCount < 7)
        {
            if (currentTime >= beatInterval * 3.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 3.5f;
                noteCount++;
            }
        }
        else if (noteCount < 13)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.78f;
                noteCount++;
            }
        }
        else if (noteCount < 14)
        {
            if (currentTime >= beatInterval * 2.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 16)
        {
            if (currentTime >= beatInterval * 1.5f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 17)
        {
            if (currentTime >= beatInterval * 2.45f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2.45f;
                noteCount++;
            }
        }
        else if (noteCount < 19)
        {
            if (currentTime >= beatInterval * 0.6f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.34f;
                noteCount++;
            }
        }
        else if (noteCount < 21)
        {
            if (currentTime >= beatInterval * 1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.65f;
                noteCount++;
            }
        }
        else if (noteCount < 22)
        {
            if (currentTime >= beatInterval * 2.7f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 24)
        {
            if (currentTime >= beatInterval * 1.7f)
            {
                Warning.SetActive(true);
                SpawnENote();
                currentTime -= beatInterval * 0.35f;
                noteCount++;
            }
        }
        else if (noteCount < 25)
        {
            if (currentTime >= beatInterval * 2.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2.3;
                noteCount++;
            }
        }
        else if (noteCount < 43)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnSpaceNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 47) // StartStartStartStartStartStart
        {
            if (currentTime >= beatInterval * 1.5f)
            {
                Warning.SetActive(false);

                SpawnRandomNote();
                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 50)
        {
            if (currentTime >= beatInterval * 2.9f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 52)
        {
            if (currentTime >= beatInterval * 3.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 56) // OOOO
        {
            if (currentTime >= beatInterval * 5f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 59)
        {
            if (currentTime >= beatInterval * 6.6f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 61)
        {
            if (currentTime >= beatInterval * 7f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 64)
        {
            if (currentTime >= beatInterval * 7.2f)
            {
                SpawnQWNote();
                currentTime -= beatInterval * 0.53f;
                noteCount++;
            }
        }
        else if (noteCount < 68) // OOOO
        {
            if (currentTime >= beatInterval * 7.3f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 71)
        {
            if (currentTime >= beatInterval * 8.6f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 73)
        {
            if (currentTime >= beatInterval * 9f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 74)
        {
            if (currentTime >= beatInterval * 10.72f)
            {
                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 10.72f;
                noteCount++;
            }
        }
        else if (noteCount < 78) // OOOO
        {
            if (currentTime >= beatInterval * 2.3f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 80) // OOOO
        {
            if (currentTime >= beatInterval * 2.6f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.6f;
                noteCount++;
            }
        }
        else if (noteCount < 81) 
        {
            if (currentTime >= beatInterval * 3.5f)
            {

                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 0.65f;
                noteCount++;
            }
        }
        else if (noteCount < 85) // OOOO
        {
            if (currentTime >= beatInterval * 3.8f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 88)
        {
            if (currentTime >= beatInterval * 5.2f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 90)
        {
            if (currentTime >= beatInterval * 5.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 94) // OOOO
        {
            if (currentTime >= beatInterval * 7f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 97)
        {
            if (currentTime >= beatInterval * 8.4f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 99)
        {
            if (currentTime >= beatInterval * 9.1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.68f;
                noteCount++;
            }
        }
        else if (noteCount < 102) // OOO
        {
            if (currentTime >= beatInterval * 9.2f)
            {

                SpawnEWNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 106) // OOOO
        {
            if (currentTime >= beatInterval * 9.21f)
            {
                
                SpawnRandomNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 109)
        {
            if (currentTime >= beatInterval * 10.4f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 111)
        {
            if (currentTime >= beatInterval * 10.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.68f;
                noteCount++;
            }
        }
    }

    IEnumerator ClearPanelCor()
    {

        yield return new WaitForSeconds(4f);
        ClearPanel.SetActive(true);
    }
    #endregion
    IEnumerator Effect()
    {
        yield return new WaitForSeconds(1.4f);



        map.MapSpeed *= 1000;

        PowerEffect.SetActive(true);
    }
    void SpawnRandomNote()
    {
        int randomIndex = Random.Range(1, 4);
        GameObject t_note = null;
        switch (randomIndex)
        {
            case 1:

                t_note = Instantiate(go1, tfNoteAppear.position, Quaternion.identity);
                break;
            case 2:
                t_note = Instantiate(go2, tfNoteAppear.position, Quaternion.identity);
                break;
            case 3:
                t_note = Instantiate(go3, tfNoteAppear.position, Quaternion.identity);
                break;
            default:
                break;
        }
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnDoubleRandomNote()
    {
        int randomIndex = Random.Range(1, 3);
        GameObject t_note = null;
        switch (randomIndex)
        {
            case 1:

                t_note = Instantiate(go4, tfNoteAppear.position, Quaternion.identity);
                break;
            case 2:
                t_note = Instantiate(go5, tfNoteAppear.position, Quaternion.identity);
                break;

            default:
                break;
        }
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnQNote()
    {
        GameObject t_note = Instantiate(go1, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnWNote()
    {
        GameObject t_note = Instantiate(go2, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnSpaceNote()
    {
        GameObject t_note = Instantiate(go6, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnENote()
    {
        GameObject t_note = Instantiate(go3, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnQWNote()
    {
        GameObject t_note = Instantiate(go4, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnEWNote()
    {
        GameObject t_note = Instantiate(go5, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {

            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                thePlayerController.CurHP--;
                theEffectManager.judgementEffect(4);
                thecomboManager.ResetCombo();
            }


            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }

    }
}
