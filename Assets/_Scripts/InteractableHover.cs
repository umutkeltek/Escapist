using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHover : MonoBehaviour
{
 
    //if you want it private do:
    [SerializeField] 
    Texture2D cursor;
    Vector2 hotSpot = new Vector2(32,32);
    //Otherwise you can do it publicly.  


    void OnMouseEnter()
    {
        Cursor.SetCursor (cursor, hotSpot, CursorMode.ForceSoftware);
    }
       
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
   
}
