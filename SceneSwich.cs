using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwich : MonoBehaviour
{
   public GameObject gameobject = GameObject.Find("Cube");
    void start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        gameobject.SetActive(false);
    }
}

