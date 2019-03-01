using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard : MonoBehaviour {

    [SerializeField] private float m_jump_power;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * m_jump_power);
    }
}
