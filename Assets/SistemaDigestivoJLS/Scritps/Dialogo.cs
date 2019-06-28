﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI texPlay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if ( texPlay.text == sentences [index] )
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            texPlay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            texPlay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            texPlay.text = "";
            continueButton.SetActive(false);
        }

    }
}
