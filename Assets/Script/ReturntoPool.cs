using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturntoPool : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ReturntoPools());
    }
  
    void Update()
    {
        
    }
    IEnumerator ReturntoPools()
    {
        yield return new WaitForSeconds(2f);
        ObjectPool.ReturnToPool("NoteEffect", gameObject);
    }
}
