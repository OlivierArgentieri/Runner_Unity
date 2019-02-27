using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    //public string[] m_tags = UnityEditorInternal.InternalEditorUtility.tags;
    [SerializeField] private float m_jump_power;
    [SerializeField] private bool m_only_on_platform;
    [SerializeField] private bool m_mass_as_gravity_;

    private Rigidbody m_rigidbody_;
    private bool m_is_jumping_;

    private void Start()
    {
        
        m_rigidbody_ = GetComponent<Rigidbody>();
    }

    public void MakeJump()
    {
        if (m_only_on_platform && !m_is_jumping_)
            m_rigidbody_.AddForce(Vector3.up * m_jump_power);

        if (!m_only_on_platform)
            m_rigidbody_.AddForce(Vector3.up * m_jump_power);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
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