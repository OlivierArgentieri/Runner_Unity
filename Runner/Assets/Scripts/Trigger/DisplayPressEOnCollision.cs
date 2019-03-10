using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPressEOnCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            LevelManager.GetInstance().SetActiveDisplayPressE(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            LevelManager.GetInstance().SetActiveDisplayPressE(false);
    }
}
