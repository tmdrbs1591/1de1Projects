using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlaayerController : MonoBehaviour
{
    TimingManager theTimingManager;

    public GameObject DiePanel; //������ ������ �г�
    public GameObject HitPanel;//������ ��Ʈ ����Ʈ �г�
    public GameObject QPanel; //Q �� ǥ��
    public GameObject WPanel;//W �� ǥ��
    public GameObject EPanel;//E �� ǥ��

    public bool Death = false;//���� �׾��ִ��� Ȯ���ϴ� �Ұ�
    public int MaxHP;//�ִ� HP
    public int CurHP;//���� HP
    public Vector2 appearPosition;//ó���� �����϶� ������ ��ġ��
    private Animator animator;

    [SerializeField]
    Slider HpBar;
    [SerializeField]
    Slider HpBar2;
    void Start()
    {
        transform.position = new Vector3(-11f, -2.82f,2);
        animator = GetComponent<Animator>();
        StartCoroutine(ApplyRootMotion());
        transform.DOMove(appearPosition, 2f);
        theTimingManager = FindObjectOfType<TimingManager>();
       
    }

    void Update()
    {
        HpBar.value = Mathf.Lerp(HpBar.value, (float)CurHP / (float)MaxHP, Time.deltaTime * 20);
        HpBar2.value = Mathf.Lerp(HpBar2.value, (float)CurHP / (float)MaxHP, Time.deltaTime * 3);

        Die();
        Key();
    }
    public void TakeDamage(int damage) // ������ �Ա�
    {
        CurHP -= damage;
        StartCoroutine(Hit());
        CameraShake.instance.Shake();
    }
    IEnumerator Hit()//�г� �ѹ� �����̴� �ڷ�ƾ
    {
        HitPanel.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        HitPanel.SetActive(false);

    }
    void Die()
    {
        if (CurHP <= 0)
        {
            Death = true;
            DiePanel.SetActive(true);

        }
    }
    void Key()
    {

        if (!Death)
        {
            bool qPressed = Input.GetKeyDown(KeySetting.keys[KeyAction.TOP]);
            bool wPressed = Input.GetKeyDown(KeySetting.keys[KeyAction.MID]);
            bool ePressed = Input.GetKeyDown(KeySetting.keys[KeyAction.BOTTOM]);

            if ((Input.GetKey(KeySetting.keys[KeyAction.TOP]) && wPressed) || (Input.GetKey(KeySetting.keys[KeyAction.MID]) && qPressed))
            {
                theTimingManager.CheckTimingWithKey("QW");
                return; // ���� �Է� ó�� �� �Լ� ����
            }
            // W �Ǵ� O�� ���� ���¿��� E �Ǵ� P�� ������
            if ((Input.GetKey(KeySetting.keys[KeyAction.MID]) && ePressed) || (Input.GetKey(KeySetting.keys[KeyAction.BOTTOM]) && wPressed))
            {
                theTimingManager.CheckTimingWithKey("EW");
                return; // ���� �Է� ó�� �� �Լ� ����
            }
            if (qPressed)
            {
                QPanel.SetActive(true);
                theTimingManager.CheckTimingWithKey("Q");

            }
            if (wPressed)
            {
                WPanel.SetActive(true);
                theTimingManager.CheckTimingWithKey("W");

            }
            if (ePressed)
            {
                EPanel.SetActive(true);
                theTimingManager.CheckTimingWithKey("E");

            }
            if (Input.GetKey(KeySetting.keys[KeyAction.TOP]) && Input.GetKey(KeySetting.keys[KeyAction.MID]) && Input.GetKey(KeySetting.keys[KeyAction.BOTTOM]))
            {
                theTimingManager.CheckTimingWithKey("Space");

            }
        }

        if (Input.GetKeyUp(KeyCode.Q) && !Death)
        {
            QPanel.SetActive(false);

        }
        else if (Input.GetKeyUp(KeyCode.W) && !Death)
        {
            WPanel.SetActive(false);

        }
        else if (Input.GetKeyUp(KeyCode.E) && !Death)
        {
            EPanel.SetActive(false);

        }
    }
    IEnumerator ApplyRootMotion()
    {
        animator.applyRootMotion = true;
        yield return new WaitForSeconds(2f);
        animator.applyRootMotion = false;
    }
}
