using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine.SceneManagement;
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

    [SerializeField] protected SentenceAndColor[] windowsSuicideRightClick;
    [SerializeField] protected SentenceAndColor[] miceHoleLeftClick;
    [SerializeField] protected SentenceAndColor[] miceHoleRightClick;
    [SerializeField] protected SentenceAndColor[] crackLeftClick;
    [SerializeField] protected SentenceAndColor[] crackRightClick;
    [SerializeField] protected SentenceAndColor[] WC2LeftClick;
    [SerializeField] protected SentenceAndColor[] WC2RightClick;
    [SerializeField] protected SentenceAndColor[] crack2LeftClick;
    [SerializeField] protected SentenceAndColor[] crack2RightClick;
    [SerializeField] protected SentenceAndColor[] cellDoor2aLeftClick;
    [SerializeField] protected SentenceAndColor[] cellDoor2aRightClick;
    [SerializeField] protected SentenceAndColor[] cellDoor2bLeftClick;
    [SerializeField] protected SentenceAndColor[] cellDoor2bRightClick;
    private bool isInsideCollision;
    public bool interactedAll;
    public bool suicideAvailable;
    public bool miceHoleDone;
    public bool crackDone;
    public bool WC2Done;
    public bool cellDoor2aFinish;
    public bool crack2Done;
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
    private int windowsSuicideRightClickIndex;
    private int miceHoleLeftIndex;
    private int miceHoleRightIndex;
    private int crackLeftIndex;
    private int crackRightIndex;
    private int WC2LeftIndex;
    private int WC2RightIndex;
    private int crack2LeftIndex;
    private int crack2RightIndex;
    private int cellDoor2aLeftIndex;
    private int cellDoor2aRightIndex;
    private int cellDoor2bLeftIndex;
    private int cellDoor2bRightIndex;


    protected void NextSentence(SentenceAndColor[] sentences, ref int index,Color32 color)
    {   
        
        interactionText.text = sentences[index].Sentence;
        interactionText.color = sentences[index].color;
        if (index < sentences.Length - 1)
        {   
            index++;
        }
        if (!suicideAvailable)
        {
            suicideTrigger();
        }

        if (!miceHoleDone)
        {
            mouseHole2Trigger();
        }
        if (!interactedAll)
        {
            mouseHole1Trigger();
        }
        if (!crackDone)
        {
            crack1Trigger();
        }

        if (!WC2Done)
        {
            WCTrigger();
        }

        if (!cellDoor2aFinish)
        {
            CellDoor2ATrigger();
        }

        if (!crack2Done)
        {
            WallCrack2Trigger();
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
        checkRestart();
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        string collidedTag = col.tag.ToString();
        switch (collidedTag )
        { 
            case "Window":
                if (suicideAvailable)
                {
                    objectTag = "Suicide";
                    isInsideCollision = true;
                }
                else
                {
                    objectTag = col.tag;
                    isInsideCollision = true;
                    
                }
                break;
            case "MouseHole":
                if (interactedAll)
                {
                    objectTag = "MiceHole";
                    isInsideCollision = true;
                }
                

                break;
            case "Crack":
            {   if (WC2Done)
                {
                    objectTag = "WallCrack2";
                    isInsideCollision = true;
                }
                else if (miceHoleDone)
                {
                    objectTag = "Crack1";
                    isInsideCollision = true;
                }
                

                

                break;
            }
            case "WC":
                if (crackDone)
                {
                    objectTag = "WC2";
                    isInsideCollision = true;
                }
                else
                {
                    objectTag = col.tag;
                    isInsideCollision = true;
                    
                }

                break;
            case "Door":
                if (!cellDoor2aFinish && crack2Done)
                {
                    objectTag = "CellDoor2b";
                    isInsideCollision = true;
                }
                else if (WC2Done)
                {
                    objectTag = "CellDoor2a";
                    isInsideCollision = true;
                }
                else
                {
                    objectTag = col.tag;
                    isInsideCollision = true;
                    
                }
                break;
            
            default:
                objectTag = col.tag;
                isInsideCollision = true;
                break;
        }
        /*if (suicideAvailable && col.CompareTag("Window"))
        {
            objectTag = "Suicide";
            isInsideCollision = true;
        }

        if (interactedAll && col.CompareTag("MouseHole"))
        {
            objectTag = "MiceHole";
            isInsideCollision = true;
        }
        if (miceHoleDone && col.CompareTag("Crack"))
        {
            objectTag = "Crack1";
            isInsideCollision = true;
        }
        if (crackDone && col.CompareTag("WC"))
        {
            objectTag = "WC2";
            isInsideCollision = true;
        }
        if (WC2Done && col.CompareTag("Door"))
        {
            objectTag = "CellDoor2A";
            isInsideCollision = true;
        }
        if (WC2Done && col.CompareTag("Crack"))
        {
            objectTag = "WallCrack2";
            isInsideCollision = true;
        }
        if (!cellDoor2aFinish && crack2Done && col.CompareTag("Door"))
        {
            objectTag = "CellDoor2b";
            isInsideCollision = true;
        }
        else
        {
            objectTag = col.tag;
            isInsideCollision = true;
        }*/
        print(objectTag);
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
                NextSentence(WCLeftClickSentences, ref WCLeftClickIndex, WCLeftClickSentences[WCLeftClickIndex].color);
                break;
            case "Window":
                NextSentence(windowsLeftClickSentences, ref windowLeftClickIndex,windowsLeftClickSentences[windowLeftClickIndex].color);
                break;
            case "Bed":
                NextSentence(bedLeftClickSentences, ref bedLeftClickIndex,bedLeftClickSentences[doorLeftClickIndex].color);
                break;
            case "Suicide":
                NextSentence(windowsLeftClickSentences, ref windowLeftClickIndex,windowsLeftClickSentences[windowLeftClickIndex].color);
                break;
            case "MiceHole":
                NextSentence(miceHoleLeftClick, ref miceHoleLeftIndex,miceHoleLeftClick[miceHoleLeftIndex].color);
                break;
            case "Crack1":
                NextSentence(crackLeftClick, ref crackLeftIndex,crackLeftClick[crackLeftIndex].color);
                break;
            case "WC2":
                NextSentence(WC2LeftClick, ref WC2LeftIndex,WC2LeftClick[WC2LeftIndex].color);
                break;
            case "CellDoor2a":
                NextSentence(cellDoor2aLeftClick, ref cellDoor2aLeftIndex,cellDoor2aLeftClick[cellDoor2aLeftIndex].color);
                break;
            case "WallCrack2":
                NextSentence(crack2LeftClick, ref crack2LeftIndex,crack2LeftClick[crack2LeftIndex].color);
                break;
            case "CellDoor2b":
                NextSentence(cellDoor2bLeftClick, ref cellDoor2bLeftIndex,cellDoor2bLeftClick[cellDoor2bLeftIndex].color);
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
                NextSentence(WCRightClickSentences, ref WCRightClickIndex,WCRightClickSentences[WCRightClickIndex].color);
                break;
            case "Window":
                NextSentence(windowRightClickSentences, ref windowRightClickIndex,windowRightClickSentences[windowRightClickIndex].color);
                break;
            case "Bed":
                NextSentence(bedRightClickSentences, ref bedRightClickIndex,bedRightClickSentences[bedRightClickIndex].color);
                break;
            case "Suicide":
                NextSentence(windowsSuicideRightClick, ref windowsSuicideRightClickIndex,windowsSuicideRightClick[windowsSuicideRightClickIndex].color);
                break;
            case "MiceHole":
                NextSentence(miceHoleRightClick, ref miceHoleRightIndex,miceHoleRightClick[miceHoleRightIndex].color);
                break;
            case "Crack1":
                NextSentence(crackRightClick, ref crackRightIndex,crackRightClick[crackRightIndex].color);
                break;
            case "WC2":
                NextSentence(WC2RightClick, ref WC2RightIndex,WC2RightClick[WC2RightIndex].color);
                break;
            case "CellDoor2a":
                NextSentence(cellDoor2aRightClick, ref cellDoor2aRightIndex,cellDoor2aRightClick[cellDoor2aRightIndex].color);
                break;
            case "WallCrack2":
                NextSentence(crack2RightClick, ref crack2RightIndex,crack2RightClick[crack2RightIndex].color);
                break;
            case "CellDoor2b":
                NextSentence(cellDoor2bRightClick, ref cellDoor2bRightIndex,cellDoor2bRightClick[cellDoor2bRightIndex].color);
                break;
        }
    }
    protected void suicideTrigger()
    {
        if (windowsLeftClickSentences.Length-1  == windowLeftClickIndex && windowRightClickSentences.Length-1 == windowRightClickIndex)
        {
            if (bedLeftClickSentences.Length-1 == bedLeftClickIndex && bedRightClickSentences.Length-1 == bedRightClickIndex)
            {
                suicideAvailable = true;
            }
        }
    }

    protected void mouseHole1Trigger()
    {
        if (windowsLeftClickSentences.Length-1 == windowLeftClickIndex && WCRightClickSentences.Length - 1 == WCRightClickIndex)
        {
            if (bedLeftClickSentences.Length-1 == bedLeftClickIndex &&
                windowRightClickSentences.Length-1 == windowRightClickIndex)
            {
                if (doorLeftClickSentences.Length-1 == doorLeftClickIndex && bedRightClickSentences.Length-1 == bedRightClickIndex)
                {
                    if (doorRightClickSentences.Length - 1 == doorRightClickIndex &&
                        WCLeftClickSentences.Length - 1 == WCLeftClickIndex)
                    {   
                        interactedAll = true;
                        interactionText.text = "You spot a mouse hole on the wall...";
                        interactionText.color = Color.white;
                        
                    }
                }
            }
        }
    }

    protected void mouseHole2Trigger()
    {
        if (miceHoleLeftClick.Length-1 == miceHoleLeftIndex && miceHoleRightClick.Length -1 ==miceHoleRightIndex)
        {
            miceHoleDone = true;
        }
    }

    protected void crack1Trigger()
    {
        if (crackLeftClick.Length - 1 == crackLeftIndex && crackRightClick.Length - 1 == crackRightIndex)
        {
            crackDone = true;
        }
    }

    protected void WCTrigger()
    {
        if (WC2LeftClick.Length - 1 == WC2LeftIndex && WC2RightClick.Length -1 == WC2RightIndex)
        {
            WC2Done = true;
        }
    }

    protected void CellDoor2ATrigger()
    {
        if (cellDoor2aLeftClick.Length - 1 == cellDoor2aLeftIndex && cellDoor2aRightClick.Length -1 == cellDoor2aRightIndex)
        {
            cellDoor2aFinish = true;
        }
    }

    protected void WallCrack2Trigger()
    {
        if (crack2LeftClick.Length - 1 == crack2LeftIndex && crack2RightClick.Length -1 == crack2RightIndex)
        {
            crack2Done = true;
        }
    }

    protected void checkRestart()
    {
        if (interactionText.text=="Restart")
        {
            SceneManager.LoadScene(0);
        }
    }
    
}
