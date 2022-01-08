using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable: MonoBehaviour {
    // minigame is for custom types, for example connect wires to interact with doors
    
    /*
    public enum InteractionType {
        Click,
        Hold,
        Minigame
    }

    float holdTime;

    public InteractionType interactionType;

    public abstract string GetDescription();
    

    public void IncreaseHoldTime() => holdTime += Time.deltaTime;
    public void ResetHoldTime() => holdTime = 0f;
    public float GetHoldTime() => holdTime;*/
        
    public abstract void Interact();

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            collision.GetComponentInChildren<PlayerMovement>().OpenInteractableIcon();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {    
            collision.GetComponentInChildren<PlayerMovement>().CloseInteractableIcon();
        }
    }
}
