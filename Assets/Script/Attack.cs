using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   public  PlaayerController controller;
    public Transform Q;
    public Transform W;
    public Transform E;
    public GameObject laserRotation;
    public GameObject laser;

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)|| Input.GetKeyDown(KeyCode.F) && !controller.Death)
        {
            animator.SetTrigger("QAttack");
            RotateLaser(Q);
            StartCoroutine(laserSetActive());
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) && !controller.Death)
        {

            animator.SetTrigger("WAttack");
            RotateLaser(W);
            StartCoroutine(laserSetActive());

        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.J) && !controller.Death)
        {
            animator.SetTrigger("EAttack");

            RotateLaser(E);
            StartCoroutine(laserSetActive());

        }
        else if (Input.GetKey(KeyCode.Space) && !controller.Death)
        {
           // Space();

        }
    }
    void Space()
    {


            int randomValue = Random.Range(0, 3); // 0, 1, 2 중에서 랜덤한 값 생성

            switch (randomValue)
            {
                case 0:
                    animator.SetTrigger("EAttack");
                    RotateLaser(E);
                    StartCoroutine(laserSetActive());
                    break;
                case 1:
                    animator.SetTrigger("WAttack");
                    RotateLaser(E);
                    StartCoroutine(laserSetActive());
                    break;
                case 2:
                    animator.SetTrigger("QAttack");
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
        laser.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        laser.SetActive(false);

    }
}
