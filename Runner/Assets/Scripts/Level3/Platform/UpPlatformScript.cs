using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovePlatform))]
public class UpPlatformScript : MonoBehaviour
{
    private MovePlatform m_move_script_;
    // Use this for initialization
    void Start()
    {
        m_move_script_ = GetComponent<MovePlatform>();
        m_move_script_.enabled = false;
    }

    public void Activate()
    {
        m_move_script_.enabled = true;
    }
}
