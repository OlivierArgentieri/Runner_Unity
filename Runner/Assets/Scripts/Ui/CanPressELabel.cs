using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanPressELabel : MonoBehaviour
{
    // Use this for initialization
    [SerializeField] private Text m_label_can_press_e;

    void Awake()
    {
        LevelManager.GetInstance().RegisterCanPressELabel(m_label_can_press_e);
    }

    private void Start()
    {
        LevelManager.GetInstance().SetActiveDisplayPressE(false);
    }
}
