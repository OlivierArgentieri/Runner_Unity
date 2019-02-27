using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float m_move_speed_;

    private Vector3 m_move_vector_;
    private float m_start_time_;
    private Vector3 m_distance_;
    // Use this for initialization
    void Start()
    {
        m_move_vector_ = Vector3.zero;
    }
    
    // Update is called once per frame
    public void MoveLeft()
    {

        transform.Translate(Vector3.Lerp(Vector3.left * transform.position.x, Vector3.left * m_move_speed_ * Time.deltaTime, 0.8f));
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.Lerp(transform.position, -Vector3.left * m_move_speed_ * Time.deltaTime, 1));
    }

    public void ResetMove()
    {
        transform.Translate(Vector3.Lerp(Vector3.left * transform.position.x, Vector3.left * m_move_speed_ * Time.deltaTime, 0.8f)
    }
}