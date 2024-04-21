/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask terrainLayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                // Check if the collider does not belong to the terrain layer
               // if (terrainLayer != (terrainLayer | (1 << collider.gameObject.layer)))
                //{
                    if (collider.TryGetComponent(out NPCInteractable npcInteractable)) {
                        npcInteractable.Interact();
                    }
               // }
            }
        }
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask terrainLayer;
    public string npcTag = "NPC"; // Set this to the tag of your NPC GameObject

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                // Check if the collider does not belong to the terrain layer and has the NPC tag
                if (terrainLayer != (terrainLayer | (1 << collider.gameObject.layer))
                    && collider.gameObject.CompareTag(npcTag))
                {
                    if (collider.TryGetComponent(out UI_Assistant uiAssistant)) {
                        // Show or interact with the UI_Assistant component
                        // For example: uiAssistant.ShowUI();
                    }
                }
            }
        }
    }
}



