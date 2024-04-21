using UnityEngine;
using UnityEngine.SceneManagement;

public class BusInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollection coinCollection = other.GetComponent<CoinCollection>();
            if (coinCollection != null && coinCollection.Coin >= 3)
            {
                LoadNextLevel();
            }
        }
    }

    private void LoadNextLevel()
    {
        // You can add additional logic here if needed, such as saving player progress
        // or performing other actions before loading the next level.

        // Load the next level
        SceneManager.LoadScene(6);
    }
}
