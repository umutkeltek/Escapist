using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable: MonoBehaviour {
    
    public InteractionType interactionType;
    public enum InteractionType {
        Use,
        Open,
        Talk,
        Pickup,
    }
    [SerializeField] 
    Texture2D cursor;
    Vector2 hotSpot = new Vector2(32,32);
    public abstract void Interact();
    public abstract string GetDescription();
    void OnMouseEnter()
    {
        Cursor.SetCursor (cursor, hotSpot, CursorMode.ForceSoftware);
    }
       
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
