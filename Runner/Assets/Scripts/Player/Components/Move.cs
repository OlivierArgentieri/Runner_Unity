using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float m_move_speed_;
    [SerializeField] private float m_move_forward_speed_;
    
    private float m_start_time_;

    
    public float Move_forward_speed_
    {
        get { return m_move_forward_speed_; }
        set
        {
            if (value > 0)
                m_move_forward_speed_ = value;
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public void MoveLeft()
    {
        transform.Translate(Vector3.left * m_move_speed_ * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.Lerp(transform.position, -Vector3.left * m_move_speed_ * Time.deltaTime, 1));
    }

    public void ResetMove()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, 0, 0.050f), transform.position.y, transform.position.z);
        //transform.Translate(Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z) * m_move_speed_ * Time.deltaTime, 1));
    }

    public void MoveForward()
    {
        transform.Translate(Vector3.forward * m_move_speed_ * Time.deltaTime);
    }
}