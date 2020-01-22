using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    // In order for this script to work, you will need to make sure the player tag is "Player"

    // OnTriggerEnter function check if player enter the killzone and reset the scene accordingly
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }

}
