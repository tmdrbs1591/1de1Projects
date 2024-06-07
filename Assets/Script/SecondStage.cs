using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStage : MonoBehaviour
{
    public ParallaxScroll map;
    public GameObject SpeedEffect;
    public GameObject ClearPanel;
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
      
        if (noteCount < 32)
        {
            if (currentTime >= beatInterval * 0.931f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.931f;
                noteCount++;
            }
        }
        else if (noteCount < 33)
        {
            if (currentTime >= beatInterval * 0.93f)
            {
                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 0.93f;
                noteCount++;
            }
        }
        else if (noteCount < 64)
        {
            if (currentTime >= beatInterval * 0.944f)
            {
                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 0.944f;
                noteCount++;
            }
        }
        else if (noteCount < 65)
        {
            if (currentTime >= beatInterval * 0.94f)
            {
                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 0.94f;
                noteCount++;
            }
        }
        else if (noteCount < 105)
        {
            if (currentTime >= beatInterval * 0.937f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.937f;
                noteCount++;
            }
        }
        else if (noteCount < 106)
        {
            if (currentTime >= beatInterval * 0.1f)
            {

                theTimingManager.camerashake = false;
                map.MapSpeed *= 4;
                SpeedEffect.SetActive(true);
                currentTime -= beatInterval * 0.1f;
                noteCount++;
            }
        }
        else if (noteCount < 120)
        {
            if (currentTime >= beatInterval * 0.2f)
            {
                
                SpawnSpaceNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }

        else if (noteCount < 121)
        {
            if (currentTime >= beatInterval * 0.1f)
            {
                map.MapSpeed *= 4;
                currentTime -= beatInterval * 0.1f;
                noteCount++;
             
            }
        }
        else if (noteCount < 160)
        {
            if (currentTime >= beatInterval * 0.1f)
            {
                SpawnSpaceNote();
                currentTime -= beatInterval * 0.1f;
                noteCount++;
            }
        }
        else if (noteCount < 161)
        {
            if (currentTime >= beatInterval * 1.57f)
            {
                SpawnWNote();
                map.MapSpeed /= 4;
                currentTime -= beatInterval * 1.57f;
                noteCount++;
                StartCoroutine(Effect());
              


            }
        }
       
        else if (noteCount < 162)
        {

            if (currentTime >= beatInterval * 0.943f)
            {

                SpawnRandomNote();

                currentTime -= beatInterval * 0.943f;
                noteCount++;
            }
        }
        else if (noteCount < 171)
        {

            if (currentTime >= beatInterval * 0.943f)
            {

                SpawnRandomNote();
                theTimingManager.camerashake = true;



                currentTime -= beatInterval * 0.943f;
                noteCount++;
            }
        }
        else if (noteCount < 172)
        {

            if (currentTime >= beatInterval * 0.9f)
            {

                SpawnQNote();

                currentTime -= beatInterval * 0.9f;
                noteCount++;
            }
        }
        else if (noteCount < 173)
        {

            if (currentTime >= beatInterval * 0.45f)
            {

                SpawnQNote();
                
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 174)
        {

            if (currentTime >= beatInterval * 0.34f)
            {

                SpawnQNote();

                currentTime -= beatInterval * 0.34f;
                noteCount++;
            }
        }
        else if (noteCount < 175)
        {

            if (currentTime >= beatInterval * 0.31f)
            {

                SpawnWNote();

                currentTime -= beatInterval * 0.31f;
                noteCount++;
            }
        }
        else if (noteCount < 177)
        {

            if (currentTime >= beatInterval * 0.28f)
            {

                SpawnWNote();

                currentTime -= beatInterval * 0.28f;
                noteCount++;
            }
        }
        else if (noteCount < 178)
        {

            if (currentTime >= beatInterval * 0.33f)
            {

                SpawnENote();

                currentTime -= beatInterval * 0.33f;
                noteCount++;

            }
        }
        else if (noteCount < 180)
        {

            if (currentTime >= beatInterval * 0.23f)
            {

                SpawnENote();

                currentTime -= beatInterval * 0.23f;
                noteCount++;
            }
        }
        else if (noteCount < 181)
        {

            if (currentTime >= beatInterval * 0.44f)
            {

                SpawnWNote();

                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 183)
        {

            if (currentTime >= beatInterval * 0.21f)
            {

                SpawnWNote();

                currentTime -= beatInterval * 0.21f;
                noteCount++;
            }
        }
        else if (noteCount < 184)
        {

            if (currentTime >= beatInterval *0.4f)
            {

                SpawnRandomNote();



                currentTime -= beatInterval * 0.4f;
                noteCount++;
            }
        }
        else if (noteCount < 199)
        {

            if (currentTime >= beatInterval * 0.932f)
            {

                SpawnRandomNote();



                currentTime -= beatInterval * 0.932f;
                noteCount++;
            }
        }
        else if (noteCount < 211)
        {

            if (currentTime >= beatInterval * 0.942f)
            {

                SpawnDoubleRandomNote();



                currentTime -= beatInterval * 0.942f;
                noteCount++;
            }
        }
        else if (noteCount < 212)
        {

            if (currentTime >= beatInterval * 0.9f)
            {

                SpawnQNote();

                currentTime -= beatInterval * 0.9f;
                noteCount++;
            }
        }
        else if (noteCount < 213)
        {

            if (currentTime >= beatInterval * 0.45f)
            {

                SpawnQNote();

                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 214)
        {

            if (currentTime >= beatInterval * 0.34f)
            {

                SpawnQNote();

                currentTime -= beatInterval * 0.34f;
                noteCount++;
            }
        }
        else if (noteCount < 215)
        {

            if (currentTime >= beatInterval * 0.31f)
            {

                SpawnWNote();

                currentTime -= beatInterval * 0.31f;
                noteCount++;
            }
        }
        else if (noteCount < 217)
        {

            if (currentTime >= beatInterval * 0.28f)
            {

                SpawnWNote();

                currentTime -= beatInterval * 0.28f;
                noteCount++;
            }
        }
        else if (noteCount < 218)
        {

            if (currentTime >= beatInterval * 0.33f)
            {

                SpawnENote();

                currentTime -= beatInterval * 0.33f;
                noteCount++;

            }
        }
        else if (noteCount < 220)
        {

            if (currentTime >= beatInterval * 0.23f)
            {

                SpawnENote();

                currentTime -= beatInterval * 0.23f;
                noteCount++;
            }
        }
        else if (noteCount < 221)
        {

            if (currentTime >= beatInterval * 0.44f)
            {

                SpawnWNote();

                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 223)
        {

            if (currentTime >= beatInterval * 0.21f)
            {

                SpawnWNote();

                currentTime -= beatInterval * 0.21f;
                noteCount++;
            }
        }
        else if (noteCount < 224)
        {

            if (currentTime >= beatInterval * 0.462f)
            {

                SpawnDoubleRandomNote();


                currentTime -= beatInterval * 0.462f;
                noteCount++;
            }
        }
        else if (noteCount < 238)
        {

            if (currentTime >= beatInterval * 0.93f)
            {

                SpawnDoubleRandomNote();


                currentTime -= beatInterval * 0.93f;
                noteCount++;
            }
        }
        else if (noteCount < 239)
        {

            if (currentTime >= beatInterval * 0.93f)
            {

                SpawnDoubleRandomNote();

                StartCoroutine(ClearPanelCor());
                currentTime -= beatInterval * 0.93f;
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
                thePlayerController.TakeDamage(1);
                theEffectManager.judgementEffect(4);
                thecomboManager.ResetCombo();
            }


            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }

    }
}
