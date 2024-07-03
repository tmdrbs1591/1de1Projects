using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PlaayerController controller;
    public ButtonManager buttonManager;

    public Transform Q;
    public Transform W;
    public Transform E;
    public GameObject laserRotation;
    public GameObject QWEEffect;
    public List<GameObject> lasers; // 리스트로 laser GameObject들을 관리

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!controller.Death && !buttonManager.isCountDown) // 죽지 않거나 카운트 중이 아닐때만
        {
            if ((Input.GetKey(KeySetting.keys[KeyAction.Q]) && Input.GetKey(KeySetting.keys[KeyAction.W]) && Input.GetKey(KeySetting.keys[KeyAction.E])) )
            {
                QWEEffect.SetActive(true);
                TripleAttack();
            }
            else if (Input.GetKeyDown(KeySetting.keys[KeyAction.Q]))
            {
                animator.SetTrigger("QAttack");
                RotateLaser(Q);
                StartCoroutine(laserSetActive());
            }
            else if (Input.GetKeyDown(KeySetting.keys[KeyAction.W]))
            {
                animator.SetTrigger("WAttack");
                RotateLaser(W);
                StartCoroutine(laserSetActive());
            }
            else if (Input.GetKeyDown(KeySetting.keys[KeyAction.E]))
            {
                animator.SetTrigger("EAttack");
                RotateLaser(E);
                StartCoroutine(laserSetActive());
            }
            else
            {
                QWEEffect.SetActive(false);
            }
            
        }
    }


    public void TripleAttack()
    {
        int randomValue = Random.Range(0, 3); // 0, 1, 2 중에서 랜덤한 값 생성

        switch (randomValue)
        {
            case 0:
                RotateLaser(Q);
                StartCoroutine(laserSetActive());
                break;
            case 1:
                RotateLaser(W);
                StartCoroutine(laserSetActive());
                break;
            case 2:
                animator.SetTrigger("EAttack");
                RotateLaser(E);
                StartCoroutine(laserSetActive());
                break;
        }
    }

   public void RotateLaser(Transform targetTransform)
    {
        // Calculate rotation direction
        Vector3 direction = targetTransform.position - laserRotation.transform.position;

        // Calculate rotation only around the z axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // Apply rotation to the laser
        laserRotation.transform.rotation = rotation;
    }

    public IEnumerator laserSetActive()
    {
        // Find an inactive laser GameObject to use
        GameObject inactiveLaser = lasers.Find(laser => !laser.activeSelf);

        if (inactiveLaser != null)
        {
            inactiveLaser.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            inactiveLaser.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No inactive laser available!");
        }
    }
}
