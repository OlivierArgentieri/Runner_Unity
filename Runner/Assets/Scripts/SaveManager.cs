﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager m_instance;
    
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save(Player _pPlayerObject )
    {

    }
}