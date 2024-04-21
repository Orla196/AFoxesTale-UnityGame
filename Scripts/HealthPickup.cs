/*using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 20; // Amount of health to restore

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Get the Health component from the player object
            Health playerHealth = other.GetComponent<Health>();

            // Check if the playerHealth is not null (i.e., if the Health script is attached to the player)
            if (playerHealth != null)
            {
                // Call the TakeDamage method on the playerHealth component to add health
                playerHealth.TakeDamage(-healthAmount); // Pass negative value to add health

                // Destroy the health pickup object
                Destroy(gameObject);

                // Add a console log for testing purposes
                Debug.Log($"Health pickup added {healthAmount} health to the player.");
            }
        }
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 20; // Amount of health to restore
    public AudioClip destroySound; // Sound to play when the health pickup is destroyed
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Get the Health component from the player object
            Health playerHealth = other.GetComponent<Health>();

            // Check if the playerHealth is not null (i.e., if the Health script is attached to the player)
            if (playerHealth != null)
            {
                // Call the TakeDamage method on the playerHealth component to add health
                playerHealth.TakeDamage(-healthAmount); // Pass negative value to add health

                // Play destroy sound if available
                if (destroySound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(destroySound);
                }

                // Destroy the health pickup object after a short delay to allow sound to play
                Destroy(gameObject, 0.1f);

                // Add a console log for testing purposes
                Debug.Log($"Health pickup added {healthAmount} health to the player.");
            }
        }
    }
}*/

using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 20; // Amount of health to restore
    public AudioClip destroySound; // Sound to play when the health pickup is destroyed
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Get the Health component from the player object
            Health playerHealth = other.GetComponent<Health>();

            // Check if the playerHealth is not null (i.e., if the Health script is attached to the player)
            if (playerHealth != null)
            {
                int healthToAdd = Mathf.Min(healthAmount, 99 - playerHealth.currentHealth); // Calculate health to add without exceeding 99

                // Call the TakeDamage method on the playerHealth component to add health
                playerHealth.TakeDamage(-healthToAdd); // Pass negative value to add health

                // Play destroy sound if available
                if (destroySound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(destroySound);
                }

                // Destroy the health pickup object after a short delay to allow sound to play
                Destroy(gameObject, 0.1f);

                // Add a console log for testing purposes
                Debug.Log($"Health pickup added {healthToAdd} health to the player.");
            }
        }
    }
}

