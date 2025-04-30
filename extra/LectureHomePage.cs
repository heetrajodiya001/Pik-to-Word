using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureHomePage : MonoBehaviour
{
    public GameObject homepage, playing;

    public void clickContinue()
    {
        homepage.SetActive(false);
        playing.SetActive(true);
    }
}