using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float m_jump_power;
    private Rigidbody m_rigidbody_;


    private void Start()
    {
        m_rigidbody_ = GetComponent<Rigidbody>();
    }

    public void jump()
    {
        m_rigidbody_.AddForce(Vector3.up * m_jump_power);
    }

   
}