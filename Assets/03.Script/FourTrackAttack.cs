using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourTrackAttack: MonoBehaviour
{
    public PlaayerController controller;
    public Transform Q;
    public Transform W;
    public Transform E;
    public Transform R;
    public GameObject laserRotation;
    public GameObject QWEEffect;
    public List<GameObject> lasers; // 리스트로 laser GameObject들을 관리

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!controller.Death)
        {
            if ((Input.GetKey(KeySetting.keys[KeyAction.D]) && Input.GetKey(KeySetting.keys[KeyAction.F]) && Input.GetKey(KeySetting.keys[KeyAction.J]) && Input.GetKey(KeySetting.keys[KeyAction.K])) )
            {
                QWEEffect.SetActive(true);
                TripleAttack();
            }
            else if (Input.GetKeyDown(KeySetting.keys[KeyAction.D]))
            {
                animator.SetTrigger("QAttack");
                RotateLaser(Q);
                StartCoroutine(laserSetActive());
            }
            else if (Input.GetKeyDown(KeySetting.keys[KeyAction.F]))
            {
                animator.SetTrigger("WAttack");
                RotateLaser(W);
                StartCoroutine(laserSetActive());
            }
            else if (Input.GetKeyDown(KeySetting.keys[KeyAction.J]))
            {
                animator.SetTrigger("EAttack");
                RotateLaser(E);
                StartCoroutine(laserSetActive());
            }
            else if (Input.GetKeyDown(KeySetting.keys[KeyAction.K]))
            {
                animator.SetTrigger("EAttack");
                RotateLaser(R);
                StartCoroutine(laserSetActive());
            }
            else
            {
                QWEEffect.SetActive(false);
            }
            
        }
    }


    void TripleAttack()
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

    void RotateLaser(Transform targetTransform)
    {
        // Calculate rotation direction
        Vector3 direction = targetTransform.position - laserRotation.transform.position;

        // Calculate rotation only around the z axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // Apply rotation to the laser
        laserRotation.transform.rotation = rotation;
    }

    IEnumerator laserSetActive()
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
