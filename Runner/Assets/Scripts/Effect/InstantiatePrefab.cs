using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [SerializeField] private GameObject m_prefabs;
    [SerializeField] private Vector3 m_spawn_prefabs;

    public void Effect()
    {
        Debug.Log("effect");
        Instantiate(m_prefabs, m_spawn_prefabs, Quaternion.identity);
    }
}
