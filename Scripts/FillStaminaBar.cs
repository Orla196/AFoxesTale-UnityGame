using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStaminaBar : MonoBehaviour
{
    public Stamina playerStamina;
    public Image FillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = playerStamina.currentStamina; // playerStamina.maxStamina;
        slider.value = fillValue;
    }
}
