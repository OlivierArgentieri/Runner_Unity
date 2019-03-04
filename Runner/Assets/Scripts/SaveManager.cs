using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveManager : MonoBehaviour
{
    public static SaveManager m_instance;

    private string m_path_;
    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;

        if (m_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
      m_path_ = Application.streamingAssetsPath + "/save.json";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveTime(float _fTime)
    {
        SaveData save = new SaveData();
        save.m_saved_time = _fTime;
        File.WriteAllText(m_path_, JsonUtility.ToJson(save));
    }

    public float GetSavedTime(float _fTime)
    {
        string json = File.ReadAllText(m_path_);
        SaveData save = JsonUtility.FromJson<SaveData>(m_path_);

        Debug.Log(save.m_saved_time);
        return 0;
    }

    
}

public class SaveData
{
    public float m_saved_time;
}