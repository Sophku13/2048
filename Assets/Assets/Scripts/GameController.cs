using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] Cells;
    //^used to make the private variables accessible within the Unity editor without making them public
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnCells();
        }
    }
    public void spawnCells()
    //instantiate fill cells, either spawn a 2 or a 4
    {
        float percentage = Random.Range(0f, 1f);
        Debug.Log(percentage);
        if(percentage <0.2f)
        {
            return;
        }
        else if(percentage < 0.8f)
        {
            int spawnChoice = Random.Range(0,Cells.Length);
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(2);
        }
        else
        {
            int spawnChoice = Random.Range(0, Cells.Length);
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(4);
        }
    }
}
