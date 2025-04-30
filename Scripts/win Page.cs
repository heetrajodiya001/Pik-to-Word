using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winPage : MonoBehaviour
{
    public GameObject Homepage, Startgame, Endpage;
    public void Movetostartgame()
    {
        Endpage.SetActive(false);
        Startgame.SetActive(true);
    }
}
