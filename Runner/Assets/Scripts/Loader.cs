using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{

    [SerializeField] private GameObject m_gameManager;
    [SerializeField] private GameObject m_inputManager;

    // Use this for initialization
    void Awake()
    {
        if (GameManager.m_instance == null)
            Instantiate(m_gameManager);

        if (InputManager.m_instance == null)
            Instantiate(m_inputManager);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
