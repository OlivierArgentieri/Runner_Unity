using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (GetComponent<MainCanvasScript>() != null)
        {
            //Destroy(this.gameObject);
            //return;
        }
        //LevelManager.m_instance.RegisterMainCanvas(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
