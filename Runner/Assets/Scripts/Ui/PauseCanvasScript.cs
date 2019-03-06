using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PauseCanvasScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (GetComponent<PauseCanvasScript>() != null)
        {
            //Destroy(this.gameObject);
            //return;
        }
       
        LevelManager.m_instance.RegisterPauseCanvas(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartLevel()
    {
        LevelManager.m_instance.ResetLevel();
        LevelManager.m_instance.PauseCurrentLevel();
    }
}