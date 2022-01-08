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
    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        thisText = GetComponent<TMP_Text>();

        StartCoroutine(TypeWrite());
    }

    IEnumerator TypeWrite()
    {
        foreach (char i in paragraph)
        {   if (i.ToString() == " ")
            {
                thisText.text += i.ToString();
                yield return new WaitForSeconds(0.21f);
            }
            else
            {
                thisText.text += i.ToString();
                audSrc.pitch = Random.Range(0.85f, 1.05f);
                audSrc.PlayOneShot(TypeSound);
                if (i.ToString() == ".")
                {
                    yield return new WaitForSeconds(1);
                }
                else { }
                yield return new WaitForSeconds(delay);
            }
        }
            
    } 
}
