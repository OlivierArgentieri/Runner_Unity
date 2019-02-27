using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterLabel : MonoBehaviour
{
    [SerializeField] private Text m_label_meter_instance;
    // Use this for initialization
    void Start()
    {
        GameManager.m_instance.RegisterTextMeterLabel(m_label_meter_instance);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
