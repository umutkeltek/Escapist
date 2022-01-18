using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerInteraction: MonoBehaviour 
{

    public TMPro.TextMeshProUGUI interactionText;
    public GameObject interactionHoldGO; // the ui parent to disable when not interacting
    public UnityEngine.UI.Image interactionHoldProgress; // the progress bar for hold interaction type
    Camera cam;
    private Vector2 _boxSize = new Vector2(0.3f, 0.3f);

    private void Update()
    {
        
            CheckInteraction();
        
    }

    public void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, _boxSize,0,Vector2.zero);
        if (hits.Length > 0)
        {   
            foreach (RaycastHit2D rc in hits)
            {
                Interactable interactable = rc.transform.GetComponent<Interactable>();

                if (interactable != null)
                {
                    HandleInteraction(interactable);
                    interactionText.text = interactable.GetDescription();
                }
                
                else
                {
                    interactionText.text = "";
                }
                /*if (rc.transform.GetComponent<Interactable>())
                {   
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }*/
            }
        }
        
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Use:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Open:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Talk:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Pickup:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            default:
                throw new SystemException("Unsupported type of interactable.");
        }
    }
}