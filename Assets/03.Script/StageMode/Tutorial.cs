using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tutorial : MonoBehaviour  // �ڵ� ���� �����̶� �ּ� ����
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
    int noteCount = 0; // ������ ��Ʈ�� ��
    public GameObject GlitchVolume;
    public GameObject DigitalGlitchVolume;

    public TMP_Text messageText;
    public GameObject messageBox;
    public GameObject autoBox;
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

    private void Awake()
    {
        DataManager.instance.currentCharater = Character.White;
    }
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
                TextUpdate("�ݰ���!");
                currentTime -= beatInterval * 5.4f;
                noteCount++;
            }
        }
        else if (noteCount < 2)
        {
            if (currentTime >= beatInterval * 8f)
            {
                TextUpdate("����, �⺻���� �������� �������!");
                currentTime -= beatInterval * 15f;
                noteCount++;

            }
        }
        else if (noteCount < 3)
        {
            if (currentTime >= beatInterval * 1.99f)
            {
                SpawnQNote();
                autoBox.SetActive(true); // �ڵ��ÿ��� ���� autobox Ȱ��ȭ
                TextUpdate("Q�� ���� ����� ���� ������ �� �־�!");
                currentTime -= beatInterval * 1.99f;
                noteCount++;
            }
        }
        else if (noteCount < 9)
        {
            if (currentTime >= beatInterval * 1.99f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 1.99f;
                noteCount++;
            }
        }
        else if (noteCount < 18)
        {
            if (currentTime >= beatInterval * 4f)
            {
                autoBox.SetActive(false); 
                messageBox.SetActive(false);
                SpawnQNote();
                currentTime -= beatInterval * 1.99f;
                noteCount++;
            }
        }
        else if (noteCount < 19)
        {
            if (currentTime >= beatInterval * 1.99f)
            {
                TextUpdate("���Ҿ�!");
                currentTime -= beatInterval * 1.99f;
                noteCount++;
            }
        }
        else if (noteCount < 20)
        {
            if (currentTime >= beatInterval * 4f)
            {
                TextUpdate("����� �ִ°�?");
                currentTime -= beatInterval * 4f;
                noteCount++;
            }
        }
        else if (noteCount < 21)
        {
            if (currentTime >= beatInterval * 4f)
            {
                TextUpdate("���� �ܰ�� ������?");
                currentTime -= beatInterval * 10f;
                noteCount++;
            }
        }
        else if (noteCount < 22)
        {
            if (currentTime >= beatInterval * 1.99f)
            {
                SpawnWNote();
                autoBox.SetActive(true); // �ڵ��ÿ��� ���� autobox Ȱ��ȭ
                TextUpdate("W�� ���� �ߴ��� ���� ������ �� �־�!");
                currentTime -= beatInterval * 1.99f;
                noteCount++;
            }
        }
        else if (noteCount < 30)
        {
            if (currentTime >= beatInterval * 2f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 37)
        {
            if (currentTime >= beatInterval * 4f)
            {
                messageBox.SetActive(false);
                autoBox.SetActive(false);
                SpawnWNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 38)
        {
            if (currentTime >= beatInterval * 4f)
            {
                SpawnENote();
                autoBox.SetActive(true); // �ڵ��ÿ��� ���� autobox Ȱ��ȭ
                TextUpdate("E�� ���� �ϴ��� ���� ������ �� �־�!");
                currentTime -= beatInterval * 4f;
                noteCount++;
            }
        }
        else if (noteCount < 45)
        {
            if (currentTime >= beatInterval * 2f)
            {
                SpawnENote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 52)
        {
            if (currentTime >= beatInterval * 4f)
            {
                messageBox.SetActive(false);
                autoBox.SetActive(false);
                SpawnENote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 53)
        {
            if (currentTime >= beatInterval * 1.99f)
            {
                TextUpdate("���Ҿ�!");
                currentTime -= beatInterval * 4f;
                noteCount++;
            }
        }
        else if (noteCount < 54)
        {
            if (currentTime >= beatInterval * 4f)
            {
                TextUpdate("�� ���� �ȶ��ϱ���!");
                currentTime -= beatInterval * 4f;
                noteCount++;
            }
        }
        else if (noteCount < 55)
        {
            if (currentTime >= beatInterval * 8f)
            {
                TextUpdate("���� �ܰ�� ������?");
                currentTime -= beatInterval * 8f;
                noteCount++;
            }
        }
        else if (noteCount < 56)
        {
            if (currentTime >= beatInterval * 3f)
            {
                SpawnQWNote();
                autoBox.SetActive(true); // �ڵ��ÿ��� ���� autobox Ȱ��ȭ
                TextUpdate("QW�� ���� ���ߴ��� ���ÿ� ���� ������ ������ �� �־�!");
                currentTime -= beatInterval * 3f;
                noteCount++;
            }
        }
        else if (noteCount < 62)
        {
            if (currentTime >= beatInterval * 2f)
            {
                SpawnQWNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 70)
        {
            if (currentTime >= beatInterval * 4f)
            {
                messageBox.SetActive(false);
                autoBox.SetActive(false);
                SpawnQWNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 71)
        {
            if (currentTime >= beatInterval * 4f)
            {
                SpawnEWNote();
                autoBox.SetActive(true); // �ڵ��ÿ��� ���� autobox Ȱ��ȭ
                TextUpdate("WE�� ���� ���ϴ��� ���ÿ� ���� ������ ������ �� �־�!");
                currentTime -= beatInterval * 3f;
                noteCount++;
            }
        }
        else if (noteCount < 78)
        {
            if (currentTime >= beatInterval * 2f)
            {
                SpawnEWNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 86)
        {
            if (currentTime >= beatInterval * 4f)
            {
                messageBox.SetActive(false);
                autoBox.SetActive(false);
                SpawnEWNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 87)
        {
            if (currentTime >= beatInterval * 8f)
            {
                SpawnSpaceNote();
                autoBox.SetActive(true); // �ڵ��ÿ��� ���� autobox Ȱ��ȭ
                TextUpdate("QWE�� ���� �����ϴ��� �������� ���� ������ ������ �� �־�!");
                currentTime -= beatInterval * 8f;
                noteCount++;
            }
        }
        else if (noteCount < 100)
        {
            if (currentTime >= beatInterval * 0.2f)
            {
                SpawnSpaceNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 125)
        {
            if (currentTime >= beatInterval * 2f)
            {
                messageBox.SetActive(false);
                autoBox.SetActive(false);
                SpawnSpaceNote();
                currentTime -= beatInterval * 0.2f;
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
    void SpawnRNote()
    {
        GameObject t_note = Instantiate(go7, tfNoteAppear.position, Quaternion.identity);
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
    IEnumerator CameraBounce(float time) //ī�޶� �ٿ
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

    IEnumerator GlitchOn(float time)
    {
        yield return new WaitForSeconds(time);
        GlitchVolume.SetActive(true);
    }
    IEnumerator DigitalGlitchOn(float time)
    {
        yield return new WaitForSeconds(time);
        DigitalGlitchVolume.SetActive(true);
    }

    void TextUpdate(string message)
    {
        messageBox.SetActive(false);
        messageText.text = message;
        messageBox.SetActive(true);
    }
}
