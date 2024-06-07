using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaayerController : MonoBehaviour
{
    TimingManager theTimingManager;

    public GameObject DiePanel;
    public GameObject HitPanel;
    public GameObject QPanel;
    public GameObject WPanel;
    public GameObject EPanel;

    public bool Death = false;
    public int MaxHP;
    public int CurHP;

    [SerializeField]
    Slider HpBar;
    [SerializeField]
    Slider HpBar2;
    void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    void Update()
    {
        HpBar.value = Mathf.Lerp(HpBar.value, (float)CurHP / (float)MaxHP, Time.deltaTime * 20);
        HpBar2.value = Mathf.Lerp(HpBar2.value, (float)CurHP / (float)MaxHP, Time.deltaTime * 5);


        Die();
        Key();

    }
    public void TakeDamage(int damage)
    {
        CurHP -= damage;
        StartCoroutine(Hit());
    }
    IEnumerator Hit()
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
            bool qPressed = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.F);
            bool wPressed = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.H);
            bool ePressed = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.J);

            if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.F)) && wPressed ||
          (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && qPressed)
            {
                theTimingManager.CheckTimingWithKey("QW");
                return; // ���� �Է� ó�� �� �Լ� ����
            }
            // W �Ǵ� O�� ���� ���¿��� E �Ǵ� P�� ������
            else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.H)) && ePressed ||
                     (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.J)) && wPressed)
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
            if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.E))
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
}
