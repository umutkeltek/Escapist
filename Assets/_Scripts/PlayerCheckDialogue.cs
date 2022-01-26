using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckDialogue : MonoBehaviour
{
    public bool isInsideCollision = false;
    

    // Update is called once per frame
    private void Start()
    {
        isInsideCollision = false;
    }

    

    public bool isItInside()
    {
        return isInsideCollision;
    }
}
