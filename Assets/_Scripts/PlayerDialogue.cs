using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[System.Serializable]

public class PlayerDialogue : MonoBehaviour
{
    
    [SerializeField] protected SentenceAndColor[] doorLeftClickSentences;
    [SerializeField] protected SentenceAndColor[] doorRightClickSentences;
    
    [SerializeField] protected SentenceAndColor[] windowsLeftClickSentences;
    [SerializeField] protected SentenceAndColor[] windowRightClickSentences;
    
    [SerializeField] protected SentenceAndColor[] WCLeftClickSentences;
    [SerializeField] protected SentenceAndColor[] WCRightClickSentences;
    
    [SerializeField] protected SentenceAndColor[] bedLeftClickSentences;
    [SerializeField] protected SentenceAndColor[] bedRightClickSentences;
    
    
    private bool isInsideCollision;

    private string objectTag;
    
    [SerializeField] public TextMeshProUGUI interactionText;
    
    private int doorLeftClickIndex;
    private int doorRightClickIndex;
    private int windowLeftClickIndex;
    private int windowRightClickIndex;
    private int WCLeftClickIndex;
    private int WCRightClickIndex;
    private int bedLeftClickIndex;
    private int bedRightClickIndex;

        protected void NextSentence(SentenceAndColor[] sentences, ref int index,Color32 color)
    {   
        interactionText.text = sentences[index].Sentence;
        interactionText.color = sentences[index].color;
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
        interactionText.text = "";
    }

    protected void leftClickCheck()
    {
        switch (objectTag)
        {
            case "Door":
                NextSentence(doorLeftClickSentences, ref doorLeftClickIndex, doorLeftClickSentences[doorLeftClickIndex].color);
                break;
            case "WC":
                NextSentence(WCLeftClickSentences, ref WCLeftClickIndex, WCLeftClickSentences[doorLeftClickIndex].color);
                break;
            case "Window":
                NextSentence(windowsLeftClickSentences, ref windowLeftClickIndex,windowsLeftClickSentences[doorLeftClickIndex].color);
                break;
            case "Bed":
                NextSentence(bedLeftClickSentences, ref bedLeftClickIndex,bedLeftClickSentences[doorLeftClickIndex].color);
                break;
        }
    }

    void rightClickCheck()
    {
        switch (objectTag)
        {
            case "Door":
                NextSentence(doorRightClickSentences, ref doorRightClickIndex,doorRightClickSentences[doorLeftClickIndex].color);
                break;
            case "WC":
                NextSentence(WCRightClickSentences, ref WCRightClickIndex,WCRightClickSentences[doorLeftClickIndex].color);
                break;
            case "Window":
                NextSentence(windowRightClickSentences, ref windowRightClickIndex,windowRightClickSentences[doorLeftClickIndex].color);
                break;
            case "Bed":
                NextSentence(bedRightClickSentences, ref bedRightClickIndex,bedRightClickSentences[doorLeftClickIndex].color);
                break;
        }
    }
    
}
