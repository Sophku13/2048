using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static int ActionCounter;
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Cells2048[] Cells;
    //^used to make the private variables accessible within the Unity editor without making them public
    [SerializeField] Text scoreDisplayed;
    public static Action<String> Slide;
    public int Score;
    int isGameOver;
    [SerializeField] GameObject gameOverPanel;

    private void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartSpawnFill();
        StartSpawnFill();
    }

    // Update is called once per frame
    void Update()
    {
        //<summary>
        ///Key Input handler: WASD
        //</summary>
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCells();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            ActionCounter = 0;
            isGameOver = 0;
            Slide("w"); // observer pattern! sending the message
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            ActionCounter = 0;
            isGameOver = 0;
            Slide("a");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            ActionCounter = 0;
            isGameOver = 0;
            Slide("s");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            ActionCounter = 0;
            isGameOver = 0;
            Slide("d");
        }
    }
    public void SpawnCells()
    //<summary>
    ///This method randomly creates and places new cells with Values of 2 or 4 in empty spots
    ///</summary>
    {
        bool isFull = true;
        for(int i = 0; i < Cells.Length; i++)
        {
            if(Cells[i].fill == null)
            {
                isFull = false;
            }
        }
        if(isFull == true)
        {
            return;
        }
        int spawnChoice = UnityEngine.Random.Range(0, Cells.Length);
        if(Cells[spawnChoice].transform.childCount != 0)
        {
            Debug.Log(Cells[spawnChoice].transform.name + "cell already filled");
            SpawnCells();
            return;
        }
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(chance);
        if(chance < 0.2f) // do nothing (20%)
        {
            return;
        }
        else if(chance < 0.8f) // instantiate a fill object with Value 2 (60%)
        {
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice].transform);
            Debug.Log(2);
            FillTiles tempFillComp = tempFill.GetComponent<FillTiles>();
            Cells[spawnChoice].transform.GetComponent<Cells2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
        }
            else // instantiate a  fill object with Value 4 (20%)
        {
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice].transform);
            Debug.Log(4);
            FillTiles tempFillComp = tempFill.GetComponent<FillTiles>();
            Cells[spawnChoice].transform.GetComponent<Cells2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(4);
        }
    }
    public void StartSpawnFill()
    //<summary>
    ///Create starting tiles (only with Value 2)
    ///</summary>
    {
        int spawnChoice = UnityEngine.Random.Range(0, Cells.Length);
        if (Cells[spawnChoice].transform.childCount != 0)
        {
            Debug.Log(Cells[spawnChoice].transform.name + "cell already filled");
            SpawnCells();
            return;
        }
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice].transform);
            Debug.Log(2);
            FillTiles tempFillComp = tempFill.GetComponent<FillTiles>();
            Cells[spawnChoice].transform.GetComponent<Cells2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
    }
    public void ScoreUpdate(int scoreIn)
    {
        Score += scoreIn;
        scoreDisplayed.text = Score.ToString();
    }
    public void GameOverCheck()
    {
        isGameOver++;
        if(isGameOver >= 16)
        {
            gameOverPanel.SetActive(true);
        }
    }
    public void Restart()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);

    }
}
