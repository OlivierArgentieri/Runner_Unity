using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ButtonActivable : MonoBehaviour
{
    [SerializeField] private UnityEvent m_on_activate;

    // Use this for initialization
    void Start()
    {
        if(m_on_activate == null)
            m_on_activate = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        m_on_activate.Invoke();
    }
}
