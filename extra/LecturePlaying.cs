using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lecture : MonoBehaviour
{
    int levelIndex = 1;
    public GameObject homepage, playing;
    public Image levelImage;
    public Text levelText;
    public Sprite[] lvlImg;
    string[] rightAnswer = { "1" };
    private void OnEnable()
    {
        levelText.text = "" + (levelIndex + 1);
        levelImage.sprite = lvlImg[levelIndex];
    }  
/* Local Storage
    -> cache -> Clear | Uninstall
    -> storage */
  //Prefereance
    // Start is called before the first frame update
    void Start()
    {
        //Key -> value
        PlayerPrefs.SetInt("highScore",100);
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        print("print ==> " + highScore);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("jvdsv");
    }
    // Update is called once per frame
    void Update()
    {

    }
}