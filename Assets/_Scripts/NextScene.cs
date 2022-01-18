using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject button;
    private void Start()
    {
        button.SetActive(false);
    }
    
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Mouse0)&& button.activeInHierarchy == true)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OpenButton()
    {
        button.SetActive(true);
    }
}
