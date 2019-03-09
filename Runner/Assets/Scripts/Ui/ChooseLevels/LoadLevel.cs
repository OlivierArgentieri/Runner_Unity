using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string m_name_scene;
    
    public void LoadScene()
    {
        LevelManager.GetInstance().SwitchScene(m_name_scene);
        ClearDontDestroyOnLoad();
    }
    public void ClearDontDestroyOnLoad()
    {
        if (GameObject.Find("Pause Canvas") != null)
            Destroy(GameObject.Find("Pause Canvas"));

        if (GameObject.Find("Main Canvas") != null)
            Destroy(GameObject.Find("Main Canvas"));
    }
}
