using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static int ticker;
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] Cells;
    //^used to make the private variables accessible within the Unity editor without making them public
    public static Action<String> Slide;
    public int Score;
    [SerializeField] Text scoreDisplayed;

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
        ///<summary>
        ///Key Input handler: WASD
        ///</summary>
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCells();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            ticker = 0;
            Slide("w"); // observer pattern! sending the message
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            ticker = 0;
            Slide("a");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            ticker = 0;
            Slide("s");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            ticker = 0;
            Slide("d");
        }
    }
    public void SpawnCells()
    ///<summary>
    ///This method randomly creates and places new cells with values of 2 or 4 in empty spots
    ///</summary>
    {
        int spawnChoice = UnityEngine.Random.Range(0, Cells.Length);
        if(Cells[spawnChoice].childCount != 0)
        {
            Debug.Log(Cells[spawnChoice].name + "cell already filled");
            SpawnCells();
            return;
        }
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(chance);
        if(chance < 0.2f) // do nothing (20%)
        {
            return;
        }
        else if(chance < 0.8f) // instantiate a fill object with value 2 (60%)
        {
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(2);
            FillTiles tempFillComp = tempFill.GetComponent<FillTiles>();
            Cells[spawnChoice].GetComponent<Cells2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
        }
            else // instantiate a  fill object with value 4 (20%)
        {
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(4);
            FillTiles tempFillComp = tempFill.GetComponent<FillTiles>();
            Cells[spawnChoice].GetComponent<Cells2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(4);
        }
    }
    public void StartSpawnFill()
    ///<summary>
    ///Create starting tiles (only with value 2)
    ///</summary>
    {
        int spawnChoice = UnityEngine.Random.Range(0, Cells.Length);
        if (Cells[spawnChoice].childCount != 0)
        {
            Debug.Log(Cells[spawnChoice].name + "cell already filled");
            SpawnCells();
            return;
        }
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(2);
            FillTiles tempFillComp = tempFill.GetComponent<FillTiles>();
            Cells[spawnChoice].GetComponent<Cells2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
    }
    public void ScoreUpdate(int scoreIn)
    {
        Score += scoreIn;
        scoreDisplayed.text = Score.ToString();
    }
}
