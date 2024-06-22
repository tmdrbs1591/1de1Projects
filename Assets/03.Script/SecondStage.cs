using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SecondStage : MonoBehaviour
{
    public ParallaxScroll map;
    public GameObject SpeedEffect;
    public GameObject ClearPanel;
    public AudioSource Song;
    public PlaayerController thePlayerController;
    public Animator CameraAnim;
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

        Song.Stop();
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

        if (noteCount < 1) // 비트생성
        {
            if (currentTime >= beatInterval * 4)
            {
                
                Song.Play();
                SpawnRandomNote();
                currentTime -= beatInterval * 4;
                noteCount++;
            }
        }
        else if (noteCount < 32) // 비트생성
        {
            if (currentTime >= beatInterval * 0.94f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.94f;
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
            if (currentTime >= beatInterval * 0.94f)
            {
                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 0.94f;
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
        void SpawnRandomNote()// 1개짜리 몬스터 랜덤생성
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
    void SpawnDoubleRandomNote()// 2개짜리 몬스터 랜덤 생성
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
    void SpawnQNote()//q몬스터 생성
    {
        GameObject t_note = Instantiate(go1, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnWNote()//W몬스터 생성
    {
        GameObject t_note = Instantiate(go2, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnSpaceNote() //QWE몬스터 생성
    {
        GameObject t_note = Instantiate(go6, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnENote()//e몬스터 생성
    {
        GameObject t_note = Instantiate(go3, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnQWNote()//QW몬스터 생성
    {
        GameObject t_note = Instantiate(go4, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnEWNote()//EW몬스터 생성
    {
        GameObject t_note = Instantiate(go5, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    
    IEnumerator CameraBounce(float time) //카메라 바운스
    {
        yield return new WaitForSeconds(time);
        CameraAnim.SetTrigger("Bounce");

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {

            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                thePlayerController.TakeDamage(10); //플레이어HP 감소
                theEffectManager.judgementEffect(4);
                thecomboManager.ResetCombo();
            }


            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }

    }
    
}
