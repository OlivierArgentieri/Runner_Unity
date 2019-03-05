using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

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
        //  Debug.Log(GetSavedData().m_levels_datas[0].m_level_name);
    }

    public void SaveLevelData(LevelData _lvlData)
    {
        var saved = GetSavedData();
        if (IsLevelExist(_lvlData.m_level_name))
        {
            saved.m_levels_datas.First(d => d.m_level_name == _lvlData.m_level_name).m_saved_time = _lvlData.m_saved_time;
        }
        else
            saved.m_levels_datas.Add(_lvlData);
        PersistData(saved);
    }

    private bool IsLevelExist(string _sLevelName)
    {
        return GetSavedData().m_levels_datas.Exists(d => d.m_level_name == _sLevelName);
    }

    private void PersistData(SaveData _sdData)
    {
        SaveData save = _sdData;
        if (_sdData == null)
            save = new SaveData();

        string json = JsonConvert.SerializeObject(save);
        File.WriteAllText(m_path_, json);
    }
    public SaveData GetSavedData()
    {
        if (IsFileExist())
        {
            string json = File.ReadAllText(m_path_);
            SaveData save = JsonConvert.DeserializeObject<SaveData>(json);
            
            return save;
        }
        return new SaveData();
    }

    private bool IsFileExist()
    {
        return File.Exists(m_path_);
    }

    public void SaveBestTimeByLevelName(string _sLevelName, float _fTestedTime)
    {
        if(GetTimeByLevel(_sLevelName) > _fTestedTime)
            SaveLevelData(new LevelData { m_level_name = _sLevelName, m_saved_time = _fTestedTime });
    }

    public float GetTimeByLevel(string _sLevelName)
    {
        if (IsLevelExist(_sLevelName))
            return GetSavedData().m_levels_datas.First(d => d.m_level_name == _sLevelName).m_saved_time;
        return float.MaxValue;
    }

}

public class SaveData
{
    [JsonProperty("Levels_Data")]
    public List<LevelData> m_levels_datas;

    public SaveData()
    {
        m_levels_datas = new List<LevelData>();
    }
}

public class LevelData
{
    [JsonProperty("Saved_Time")]
    public float m_saved_time;

    [JsonProperty("Level_Name")]
    public string m_level_name;
}