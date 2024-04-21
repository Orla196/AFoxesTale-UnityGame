using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    //public int maxStamina= 10; 
    public int currentStamina;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = 10; //maxStamina;
    }

    public void UseStamina(int amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }
}
