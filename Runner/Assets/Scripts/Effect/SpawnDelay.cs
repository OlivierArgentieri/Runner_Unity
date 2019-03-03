using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDelay : MonoBehaviour
{
    [SerializeField] private GameObject m_prefabs;
    [SerializeField] private float m_cooldown;

    private float m_time_count_;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > m_time_count_)
        {
            Create();
            ResetCount();
        }
    }

    private void Create()
    {
        Instantiate(m_prefabs, transform.position, Quaternion.identity);
    }

    private void ResetCount()
    {
        m_time_count_ = Time.time + m_cooldown;
    }
}
