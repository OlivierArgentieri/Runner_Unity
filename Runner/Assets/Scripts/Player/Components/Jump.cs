using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float m_jump_power;

    [Header("Gravity")]
    [SerializeField] private bool m_mass_as_gravity_;

    private Rigidbody m_rigidbody_;
    private bool m_is_jumping_;


    [Header("Constraint")]
    [SerializeField] private bool m_only_on_gameobject;
    
    private void Start()
    {
        this.m_is_jumping_ = true;
        m_rigidbody_ = GetComponent<Rigidbody>();
    }

    public void MakeJump()
    {
        if (m_only_on_gameobject && !m_is_jumping_)
            m_rigidbody_.AddForce(Vector3.up * m_jump_power);

        if (!m_only_on_gameobject)
            m_rigidbody_.AddForce(Vector3.up * m_jump_power);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Platform")
            this.m_is_jumping_ = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
            this.m_is_jumping_ = true;
    }

    private void LateUpdate()
    {
        if (m_mass_as_gravity_)
            m_rigidbody_.AddForce(Physics.gravity * m_rigidbody_.mass);
    }
}