using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PlatformInvisible : MonoBehaviour
{

    private MeshRenderer m_mesh_renderer_;
    // Use this for initialization
    void Start()
    {
        m_mesh_renderer_ = GetComponent<MeshRenderer>();
        m_mesh_renderer_.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            this.m_mesh_renderer_.enabled = true;
    }
}
