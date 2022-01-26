using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerDialogue : MonoBehaviour
{   
    
    [TextArea(3,10)]
    [SerializeField] private string[] doorLeftClickSentences;
    [TextArea(3,10)]
    [SerializeField] private string[] doorRightClickSentences;
    [TextArea(3,10)]
    [SerializeField] private string[] windowsLeftClickSentences;
    [TextArea(3,10)]
    [SerializeField] private string[] windowRightClickSentences;
    [TextArea(3,10)]
    [SerializeField] private string[] WCLeftClickSentences;
    [TextArea(3,10)]
    
    [SerializeField] private string[] WCRightClickSentences;
    [TextArea(3,10)]
    [SerializeField] private string[] bedLeftClickSentences;
    [TextArea(3,10)]
    [SerializeField] private string[] bedRightClickSentences;
    
    private int doorLeftClickIndex;
    
    private int doorRightClickIndex;
    
    
    private int windowLeftClickIndex;
    
    private int windowRightClickIndex;
    
    
    private int WCLeftClickIndex;
    
    private int WCRightClickIndex;
    
    
    private int bedLeftClickIndex;
    
    private int bedRightClickIndex;

    private string objectTag;
    [SerializeField] public TMPro.TextMeshProUGUI interactionText;
    private bool isInsideCollision;
    
    
    protected void NextSentence(string[] sentences, ref int index)
    {
        interactionText.text = sentences[index];
        if (index < sentences.Length - 1)
        {   
            index++;
        }

        else
        {
            index = index;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInsideCollision)
        {
            leftClickCheck();

        }

        if (Input.GetMouseButtonDown(1)&& isInsideCollision)
        {   
            rightClickCheck();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        objectTag = col.tag;
        isInsideCollision = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        objectTag = "";
        isInsideCollision = false;
    }

    protected void leftClickCheck()
    {
        switch (objectTag)
        {
            case "Door":
                NextSentence(doorLeftClickSentences, ref doorLeftClickIndex);
                break;
            case "WC":
                NextSentence(WCLeftClickSentences, ref WCLeftClickIndex);
                break;
            case "Window":
                NextSentence(windowsLeftClickSentences, ref windowLeftClickIndex);
                break;
            case "Bed":
                NextSentence(bedLeftClickSentences, ref bedLeftClickIndex);
                break;
        }
    }

    void rightClickCheck()
    {
        switch (objectTag)
        {
            case "Door":
                NextSentence(doorRightClickSentences, ref doorRightClickIndex);
                break;
            case "WC":
                NextSentence(WCRightClickSentences, ref WCRightClickIndex);
                break;
            case "Window":
                NextSentence(windowRightClickSentences, ref windowRightClickIndex);
                break;
            case "Bed":
                NextSentence(bedRightClickSentences, ref bedRightClickIndex);
                break;
        }
    }
    
}
