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
       
        LevelManager.GetInstance().RegisterPauseCanvas(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void RestartLevel()
    {
        LevelManager.GetInstance().ResetLevel();
        LevelManager.GetInstance().PauseCurrentLevel();
    }
}