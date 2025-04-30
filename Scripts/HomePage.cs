using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HomePage : MonoBehaviour
{
    public GameObject Homepage, Startgame, Endpage;
    public Text lvltxt;
    public Image lvlimg;
    public Sprite[] levlimg;
    private void OnEnable()
    {
        int level = PlayerPrefs.GetInt("currentLevel", 0); 
        lvltxt.text = "" + (level + 1);  
        lvlimg.sprite = levlimg[level];  
    }
    public void MoveToStartgame()
    {
        Homepage.SetActive(false);
        Startgame.SetActive(true);
    }
}