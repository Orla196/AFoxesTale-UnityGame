/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public int Coin = 0;
    public TextMeshProUGUI coinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            Coin++;
            coinText.text = "Acorns: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public int Coin = 0;
    public TextMeshProUGUI coinText;
    public AudioSource coinSound; // AudioSource for the coin sound

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) // Check if it's a coin
        {
            Coin++;
            coinText.text = ": " + Coin.ToString();
            Debug.Log("Coins: " + Coin);
            coinSound.Play(); // Play the coin sound
            Destroy(other.gameObject); // Destroy the collected coin
        }
    }

    // Add this function to ensure the audio doesn't play on awake
    void Start()
    {
        coinSound.playOnAwake = false;
    }
}

