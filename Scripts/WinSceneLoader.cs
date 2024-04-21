using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinSceneLoader : MonoBehaviour
{
 


    private void OnTriggerStay(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(7);
        }
    }


}
