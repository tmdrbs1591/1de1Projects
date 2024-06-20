using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthStage : MonoBehaviour
{
    public ParallaxScroll map;
    public GameObject SpeedEffect;
    public GameObject ClearPanel;
    public GameObject Warning;
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
    [SerializeField] GameObject go7 = null;


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

        if (noteCount < 1)
        {
            if (currentTime >= beatInterval * 5.4f)
            {
                Song.Play();
                SpawnRandomNote();
                currentTime -= beatInterval * 5.4f;
                noteCount++;
            }
        }
        else if (noteCount < 103)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.667f;
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
        int randomIndex = Random.Range(1, 5);
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
            case 4:
                t_note = Instantiate(go7, tfNoteAppear.position, Quaternion.identity);
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
                thePlayerController.TakeDamage(10);
                theEffectManager.judgementEffect(4);
                thecomboManager.ResetCombo();
            }


            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }

    }
}
