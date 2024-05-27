using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaayerController : MonoBehaviour
{
    TimingManager theTimingManager;

    public GameObject DiePanel;
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
            bool wPressed = Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space);
            bool ePressed = Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.J);

            if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.F)) && wPressed ||
          (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && qPressed)
            {
                theTimingManager.CheckTimingWithKey("QW");
                return; // 동시 입력 처리 후 함수 종료
            }
            // W 또는 O가 눌린 상태에서 E 또는 P가 눌리면
            else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && ePressed ||
                     (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.J)) && wPressed)
            {
                theTimingManager.CheckTimingWithKey("EW");
                return; // 동시 입력 처리 후 함수 종료
            }

            if (qPressed)
            {
                QPanel.SetActive(true);
                theTimingManager.CheckTimingWithKey("Q");

            }

            if (Input.GetKey(KeyCode.Space))
            {
                theTimingManager.CheckTimingWithKey("Space");

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
