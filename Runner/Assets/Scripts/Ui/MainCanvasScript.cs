using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
