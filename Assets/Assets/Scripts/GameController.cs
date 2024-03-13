using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] Cells;
    //^used to make the private variables accessible within the Unity editor without making them public
    public static Action<String> slide;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCells();
        }
        //Inputs for all directions with WASD
        if(Input.GetKeyDown(KeyCode.W))
        {
            slide("w"); // observer pattern! sending the message
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            slide("a");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            slide("s");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            slide("d");
        }
    }
    public void SpawnCells()
    //instantiate fill cells
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
        if(chance < 0.2f) // do nothing
        {
            return;
        }
        else if(chance < 0.8f) // instantiate a  fill object with value 2
        {
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(2);
            FillTiles tempFillComp = tempFill.GetComponent<FillTiles>();
            Cells[spawnChoice].GetComponent<Cells2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
        }
            else // instantiate a  fill object with value 4
        {
       
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(4);
            FillTiles tempFillComp = tempFill.GetComponent<FillTiles>();
            Cells[spawnChoice].GetComponent<Cells2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(4);
        }
    }
}
