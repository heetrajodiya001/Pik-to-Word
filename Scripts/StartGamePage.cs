using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGamePage : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject Homepage, Startgame, Endpage;
    public Transform ansGrid, optionGrid;
    string[] answers = { "GIRL", "DOG", "FIRE", "LOLIPOP", "BOLL", "GARDEN", "JOCKER", "LEMON","LIF","RING","FAMILY","QRCODE","WORLD","TEA","RACE","HAER","CAR","PLAY","DPRETION","BLOCK","WATER","BATMAN","BOW" };
    Button[] answerButtons, questionButtons;
    Dictionary<string, int> move = new Dictionary<string, int>();
    int level ;
    public Image lvlimg;
    public Text lvltxt;
    public Sprite[] levlimg;
    private void OnEnable()
    {
        level = PlayerPrefs.GetInt("currentLevel", 0);
        lvltxt.text = "" + (level + 1);
        lvlimg.sprite = levlimg[level];
        move.Clear();
        GenerateAnswerButtons();
        GenerateQuestionButtons();
    }
    public string Rndomans()
    {
        string a = answers[level];        
        string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for(int i = a.Length;i < 12; i++)
        {
            int ran = Random.Range(0,s.Length);
            a += s[ran];
        }
       char[] temp = a.ToCharArray();
        for(int i = 0;i < a.Length;i++)
        {
            int ran = Random.Range(0,temp.Length);
            char c = temp[ran];
            temp[ran] = temp[i];
            temp[i] = c;
        }       
        string ss = new string(temp);
        return ss;      
    }
    private void GenerateQuestionButtons()
    {
        Button[] oldBtn = optionGrid.GetComponentsInChildren<Button>();
        foreach (Button item in oldBtn)
        {
            item.transform.parent = null;
            Destroy(item.gameObject);
        }
        print("Test ===>  " + optionGrid.GetComponentsInChildren<Button>().Length);
        string ans = Rndomans();
        for (int i = 0; i < 12; i++)
        {
            Button b = Instantiate(buttonPrefab, optionGrid).GetComponent<Button>();
            Text t = b.GetComponentInChildren<Text>();
            t.text = ans[i].ToString();
            int index = i;
            b.onClick.RemoveAllListeners();
            b.onClick.AddListener(() => clickQuestionButton(index));            
        }
        questionButtons = optionGrid.GetComponentsInChildren<Button>();
        print("h ==== >"+h());
    }
    private void clickQuestionButton(int questionButtonIndex)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        { 
            Text t = answerButtons[i].GetComponentInChildren<Text>();
            if (t.text == "")
            {
                Text qText = questionButtons[questionButtonIndex].GetComponentInChildren<Text>();
                t.text = qText.text;
                qText.text = "";
                Movetostartgame();
                move.Add("" + i, questionButtonIndex);
                break;
            }
        }
    }
    private void GenerateAnswerButtons()
    {
        Button[] oldBtn = ansGrid.GetComponentsInChildren<Button>();
        foreach (Button item in oldBtn)
        {
            item.transform.parent = null;
            Destroy(item.gameObject);
        }
        int answerLength = answers[level].Length;
        for (int i = 0; i < answerLength; i++)
        {
            Button b = Instantiate(buttonPrefab, ansGrid).GetComponent<Button>();
            Text t = b.GetComponentInChildren<Text>();
            t.text = "";
            int index = i;
            b.onClick.RemoveAllListeners();
            b.onClick.AddListener(() => clickAnswerButton(index));
        }
        answerButtons = ansGrid.GetComponentsInChildren<Button>();
    }
    void clickAnswerButton(int answerButtonIndex)
    {
        int questionIndex = move["" + answerButtonIndex];
        Text ansText = answerButtons[answerButtonIndex].GetComponentInChildren<Text>();
        Text queText = questionButtons[questionIndex].GetComponentInChildren<Text>();
        queText.text = ansText.text;
        ansText.text = "";
        move.Remove("" + answerButtonIndex);
    }
    public void Movetostartgame()
    {
        var rightAnswer = answers[level];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            var text = answerButtons[i].GetComponentInChildren<Text>();
            if (text.text != "" + rightAnswer[i])
            {
                return;
            }
        }
        PlayerPrefs.SetInt("currentLevel", level + 1);
        Endpage.SetActive(true);
        Startgame.SetActive(false);
    }
    public void ReplayLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 0) - 1;
        if (currentLevel < 0) currentLevel = 0;
        LoadLevel(currentLevel);
    }


    public void NextLevel()
    {
        int nextLevel = PlayerPrefs.GetInt("currentLevel", 0);
        LoadLevel(nextLevel);
    }

    private void LoadLevel(int levelIndex)
    {
        level = levelIndex;
        lvltxt.text = "" + (level + 1);
        lvlimg.sprite = levlimg[level];
        move.Clear();
        GenerateAnswerButtons();
        GenerateQuestionButtons();
        Startgame.SetActive(true);
        Endpage.SetActive(false);
    }

    public void MoveToHomepage()
    {
        Homepage.SetActive(true);
        Startgame.SetActive(false);
    }
    string h()
    {
        string s = "hello wirld";
        return s;
    }
}