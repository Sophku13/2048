using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] Cells;
    //^used to make the private variables accessible within the Unity editor without making them public
    public static Action<String> Slide;
    
    // Start is called before the first frame update
    void Start()
    {

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
            Slide("w"); // observer pattern! sending the message
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Slide("a");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Slide("s");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
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
}
