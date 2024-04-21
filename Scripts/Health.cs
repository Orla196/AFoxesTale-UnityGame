using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
   // public int maxHealth = 10;
    public int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 99;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            SceneManager.LoadScene(8);
        }
    }
}
