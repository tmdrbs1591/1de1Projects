using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    //[SerializeField] Animator noteHitAnimator = null;
    string hit = "Hit";
    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage = null;
    [SerializeField] Sprite[] jugementSprite = null;

    public void judgementEffect(int p_num)
    {
        judgementImage.sprite = jugementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }
    public void NoteHitEffect()
    {
       // noteHitAnimator.SetTrigger(hit);    
    }
}
