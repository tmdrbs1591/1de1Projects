using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBox : MonoBehaviour
{
    TimingManager theTimingManager;
    public Attack playerAttack; 
    public FourTrackAttack fourTrackPlayerAttack; 
    void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();

    }


    void Update()
    {
        if (playerAttack != null)
        {
            playerAttack = FindObjectOfType<Attack>();
        }
        if (fourTrackPlayerAttack != null)
        {
            fourTrackPlayerAttack = FindObjectOfType<FourTrackAttack>();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Note note = collision.GetComponent<Note>();
        if (note.noteKey == "Q")
        {
            theTimingManager.CheckTimingWithKey("Q");
            playerAttack.animator.SetTrigger("QAttack");
            playerAttack.RotateLaser(playerAttack.Q);
            playerAttack.StartCoroutine(playerAttack.laserSetActive());

        }
        if (note.noteKey == "W")
        {
            theTimingManager.CheckTimingWithKey("W");
            playerAttack.animator.SetTrigger("WAttack");
            playerAttack.RotateLaser(playerAttack.W);
            playerAttack.StartCoroutine(playerAttack.laserSetActive());
        }
        if (note.noteKey == "E")
        {
            theTimingManager.CheckTimingWithKey("E");
            playerAttack.animator.SetTrigger("EAttack");
            playerAttack.RotateLaser(playerAttack.E);
            playerAttack.StartCoroutine(playerAttack.laserSetActive());
        }
        if (note.noteKey == "QW")
        {
            theTimingManager.CheckTimingWithKey("QW");
            playerAttack.animator.SetTrigger("QAttack");
            playerAttack.RotateLaser(playerAttack.W);
            playerAttack.StartCoroutine(playerAttack.laserSetActive());
        }
        if (note.noteKey == "EW")
        {
            theTimingManager.CheckTimingWithKey("EW");
            playerAttack.animator.SetTrigger("QAttack");
            playerAttack.RotateLaser(playerAttack.W);
            playerAttack.StartCoroutine(playerAttack.laserSetActive());
        }
        if (note.noteKey == "Space")
        {
            theTimingManager.CheckTimingWithKey("Space");
            playerAttack.QWEEffect.SetActive(true);
            playerAttack.TripleAttack();
        }
        if (note.noteKey == "D")
        {
            theTimingManager.CheckTimingWithKey("D");
            fourTrackPlayerAttack.animator.SetTrigger("QAttack");
            fourTrackPlayerAttack.RotateLaser(fourTrackPlayerAttack.Q);
            fourTrackPlayerAttack.StartCoroutine(fourTrackPlayerAttack.laserSetActive());
        }
        if (note.noteKey == "F")
        {
            theTimingManager.CheckTimingWithKey("F");
            fourTrackPlayerAttack.animator.SetTrigger("QAttack");
            fourTrackPlayerAttack.RotateLaser(fourTrackPlayerAttack.W);
            fourTrackPlayerAttack.StartCoroutine(fourTrackPlayerAttack.laserSetActive());
        }
        if (note.noteKey == "J")
        {
            theTimingManager.CheckTimingWithKey("J");
            fourTrackPlayerAttack.animator.SetTrigger("WAttack");
            fourTrackPlayerAttack.RotateLaser(fourTrackPlayerAttack.E);
            fourTrackPlayerAttack.StartCoroutine(fourTrackPlayerAttack.laserSetActive());
        }
        if (note.noteKey == "K")
        {
            theTimingManager.CheckTimingWithKey("K");
            fourTrackPlayerAttack.animator.SetTrigger("EAttack");
            fourTrackPlayerAttack.RotateLaser(fourTrackPlayerAttack.R);
            fourTrackPlayerAttack.StartCoroutine(fourTrackPlayerAttack.laserSetActive());
        }
        if (note.noteKey == "DF")
        {
            theTimingManager.CheckTimingWithKey("DF");
            fourTrackPlayerAttack.animator.SetTrigger("WAttack");
            fourTrackPlayerAttack.RotateLaser(fourTrackPlayerAttack.W);
            fourTrackPlayerAttack.StartCoroutine(fourTrackPlayerAttack.laserSetActive());
        }
        if (note.noteKey == "JK")
        {
            theTimingManager.CheckTimingWithKey("JK");
            fourTrackPlayerAttack.animator.SetTrigger("EAttack");
            fourTrackPlayerAttack.RotateLaser(fourTrackPlayerAttack.E);
            fourTrackPlayerAttack.StartCoroutine(fourTrackPlayerAttack.laserSetActive());
        }
        if (note.noteKey == "DFJK")
        {
            theTimingManager.CheckTimingWithKey("DFJK");
            fourTrackPlayerAttack.QWEEffect.SetActive(true);
            fourTrackPlayerAttack.TripleAttack();
        }
     
    }
}
