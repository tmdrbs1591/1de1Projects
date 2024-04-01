using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

  
    void Update()
    {
        
    }
    public void Right()
    {
        anim.SetTrigger("Right");
    }
    public void Left()
    {
        anim.SetTrigger("Left");
    }
}
