using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DisplayEachScore : MonoBehaviour
{

    [SerializeField] private List<Text> m_LevelLabels;
    [SerializeField] private List<Text> m_LevelScores;

    // Use this for initialization
    void Start()
    {
        DisableAllText();
        SaveData sd = SaveManager.GetInstance().GetSavedData();
        if (sd != default(SaveData))
        {
            for (int i = 0; i < sd.m_levels_datas.Count; i++)
            {
                m_LevelLabels[i].enabled = true;
                m_LevelLabels[i].text = sd.m_levels_datas[i].m_level_name;
                m_LevelScores[i].enabled = true;
                m_LevelScores[i].text = string.Format("{0:0.0} s", sd.m_levels_datas[i].m_saved_time);
            }
        }
    }

    private void DisableAllText()
    {
        m_LevelLabels.ForEach(t => t.enabled = false);
        m_LevelScores.ForEach(t => t.enabled = false);
    }
}