using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;


[RequireComponent(typeof(AudioSource))]
public class TypeWriter : MonoBehaviour
{
    public AudioClip TypeSound;
    AudioSource audSrc;
    
    [Multiline]
    public string paragraph;
    TMP_Text thisText;
    public float delay;
    [SerializeField] GameObject nextSceneButton;

    private void Awake()
    {
        nextSceneButton.GetComponent<NextScene>();
    }

    private void Start()
    {
        
        audSrc = GetComponent<AudioSource>();
        thisText = GetComponent<TMP_Text>();

        InvokeMyCoroutine();
    }
    
    public IEnumerator TypeWrite()
    {
        
        foreach (char i in paragraph)
        {   
            if (i.ToString() == " ")
            {
                thisText.text += i.ToString();
                yield return new WaitForSeconds(0f);
            }
            else
            {
                thisText.text += i.ToString();
                audSrc.pitch = Random.Range(0.85f, 1.05f);
                audSrc.PlayOneShot(TypeSound);
                if (i.ToString() == ".")
                {
                    yield return new WaitForSeconds(0.2f);
                }
                else
                {
                    yield return new WaitForSeconds(delay);
                }
            }
        }

        nextSceneButton.GetComponent<NextScene>().OpenButton();

    } 
    void InvokeMyCoroutine()
    {
        StartCoroutine(TypeWrite());
    }
    
}
