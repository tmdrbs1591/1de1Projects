using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoGoScene : MonoBehaviour
{

    void Start()
    {
        Invoke("Scene", 2.4f);
    }

    void Scene()
    {
        SceneManager.LoadScene("TTitle");
    }
  
    void Update()
    {
        
    }
}
