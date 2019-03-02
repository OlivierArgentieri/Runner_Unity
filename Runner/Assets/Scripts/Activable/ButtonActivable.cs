using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Renderer))]
public class ButtonActivable : MonoBehaviour
{
    [SerializeField] private UnityEvent m_on_activate;
    [SerializeField] private Material m_ready_material;
    [SerializeField] private Material m_used_material;

    [SerializeField] private float m_cooldown;

    private bool m_used_;
    private float m_time_count_;

    private Renderer m_current_renderer_;
    // Use this for initialization
    void Start()
    {
        m_current_renderer_ = GetComponent<Renderer>();
        m_used_ = false;
        if (m_on_activate == null)
            m_on_activate = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > m_time_count_)
        {
            ResetButton();
        }
    }

    public void Activate()
    {
        if (!m_used_)
        {
            m_used_ = true;
            m_current_renderer_.material = m_used_material;
            m_on_activate.Invoke();
            m_time_count_ = Time.time + m_cooldown;
        }
    }

    private void ResetButton()
    {
        m_time_count_ = 0;
        m_used_ = false;
        m_current_renderer_.material = m_ready_material;
    }
}
