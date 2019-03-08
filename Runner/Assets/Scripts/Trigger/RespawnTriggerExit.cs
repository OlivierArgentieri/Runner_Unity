using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTriggerExit : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            LevelManager.GetInstance().RestartLevel();
        else
            Destroy(other.gameObject);
    }
}
