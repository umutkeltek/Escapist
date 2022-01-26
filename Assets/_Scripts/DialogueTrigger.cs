using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    private int leftClickActionLength;
    private int leftClickIndex = 0;
    private int rightClickActionLength;
    private int rightClickIndex = 0;
    [TextArea(3,10)]
    [SerializeField] private string[] leftClickSentences;
    [TextArea(3,10)]
    [SerializeField] private string[] rightClickSentences;
    [SerializeField] public TMPro.TextMeshProUGUI interactionText;
    private bool playerCheckDialogue;
    private void Start()
    {
        playerCheckDialogue = GameObject.Find("Player").GetComponent<PlayerCheckDialogue>().isInsideCollision;
        leftClickActionLength = leftClickSentences.Length;
        rightClickActionLength = rightClickSentences.Length;
        
    }

    private void Update()
    {   playerCheckDialogue = GameObject.Find("Player").GetComponent<PlayerCheckDialogue>().isInsideCollision;
        if (playerCheckDialogue)
        {  Debug.Log("work");
            NextSentence();
        }
    }

    void NextSentence()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            interactionText.text = leftClickSentences[leftClickIndex];
            if (leftClickIndex <= leftClickActionLength - 1)
            {
                leftClickIndex++;
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            interactionText.text = rightClickSentences[rightClickIndex];
            if (rightClickIndex <= rightClickActionLength - 1)
            {
                rightClickIndex++;
            }
        }
        
    }
}

