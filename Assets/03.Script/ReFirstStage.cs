using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ReFirstStage : MonoBehaviour
{
    public ParallaxScroll map;
    public GameObject SpeedEffect;
    public GameObject ClearPanel;
    public GameObject Warning;
    public AudioSource Song;
    public PlaayerController thePlayerController;
    public Animator CameraAnim;
    public int bpm = 120;
    public double currentTime = 0d;
    public int noteCount = 0; // 생성된 노트의 수

    [SerializeField] public GameObject Glitch;//글리치 이펙트
    [SerializeField] public GameObject Flash;//플래시 이펙트


    enum BeatType
    {
        Whole = 1,
        Half = 2,
        Quarter = 4,
        Eighth = 8,
        Sixteenth = 16
    }

    protected ObjectManager objectManager;
    protected GameObject PowerEffect;

    [SerializeField] public Transform tfNoteAppear = null;
    [SerializeField] public GameObject go1 = null;
    [SerializeField] public GameObject go2 = null;
    [SerializeField] public GameObject go3 = null;
    [SerializeField] public GameObject go4 = null;
    [SerializeField] public GameObject go5 = null;
    [SerializeField] public GameObject go6 = null;


    public TimingManager theTimingManager;
    public EffectManager theEffectManager;
    public ComboManager thecomboManager;

    [SerializeField] public List<NoteInfo> notemap = new List<NoteInfo>();

    public bool firstNote;

    public int allNotes;
    public int maxNotes;

    void Start()
    {
        Song.Stop();
        thecomboManager = FindObjectOfType<ComboManager>();
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();

            string path = Application.dataPath + "/Songs/" + DataManager.instance.songPath + ".json";
            using (StreamReader reader = new StreamReader(path))
            {
                notemap = JsonUtility.FromJson<EditorManager.SerializableList<NoteInfo>>(reader.ReadToEnd()).list;
            }


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
            thePlayerController = FindObjectOfType<PlaayerController>();

        if (allNotes <= 0)
            StartCoroutine(Clear(3f));

        if (firstNote)
            StartCoroutine(EffectTrue(0.4f, Glitch));
        if (allNotes <= maxNotes - 3)
        {
            StartCoroutine(EffectTrue(0.4f, Flash));
            StartCoroutine(EffectFalse(0.4f, Glitch));
        }

        currentTime += Time.deltaTime;

    }

    protected IEnumerator QueueToSpawn(NoteInfo e) // 생성
    {
        yield return new WaitForSeconds(e.timing); //노트 나오는 타이밍 설정
        if (!firstNote) // 처음 노트가 생성되면 음악 시작
            Song.Play();
        firstNote = true;
        switch (e.note) //노트의 이름에 따라 생성
        {
            case "Q": SpawnQNote(); break;
            case "W": SpawnWNote(); break;
            case "E": SpawnENote(); break;
            case "QW": SpawnQWNote(); break;
            case "EW": SpawnEWNote(); break;
            case "QWE": SpawnSpaceNote(); break;
        }
        allNotes--;
        //StartCoroutine(NoteMinas());
    }
    public IEnumerator Clear(float time)
    {
        yield return new WaitForSeconds(time);
        ClearPanel.SetActive(true);
    }
    public IEnumerator EffectTrue(float time, GameObject Effect)
    {
        yield return new WaitForSeconds(time);
        Effect.SetActive(true);
    }
    public IEnumerator EffectFalse(float time, GameObject Effect)
    {
        yield return new WaitForSeconds(time);
        Effect.SetActive(false);
    }
    IEnumerator NoteMinas()
    {
        yield return new WaitForSeconds(5f);
        allNotes--;
    }
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
    IEnumerator StartEffect()
    {
        Glitch.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        Glitch.SetActive(false);
        Flash.SetActive(true);

    }
}