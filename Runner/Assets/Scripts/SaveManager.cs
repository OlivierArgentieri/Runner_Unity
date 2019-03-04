using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveManager : MonoBehaviour
{
    public static SaveManager m_instance;

    private string m_path_;
    private const string m_file_name_ = "save.json";
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
        m_path_ = string.Format("{0}/{1}", Application.streamingAssetsPath, m_file_name_);
        Debug.Log(GetSavedTime());
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

    public float GetSavedTime()
    {
        if (IsFileExist())
        {
            string json = File.ReadAllText(m_path_);
            SaveData save = JsonUtility.FromJson<SaveData>(json);

            Debug.Log(save.m_saved_time);
            return save.m_saved_time;
        }
        return 0;
    }

    private bool IsFileExist()
    {
        return File.Exists(m_path_);
    }
}

public class SaveData
{
    public float m_saved_time;
}