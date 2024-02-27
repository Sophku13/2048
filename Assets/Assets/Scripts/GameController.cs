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
    //instantiate fill cells
    {
        int spawnChoice = Random.Range(0, Cells.Length);
        if(Cells[spawnChoice].childCount != 0)
        
        {
            spawnCells();
            Debug.Log(Cells[spawnChoice].name + "cell already filled");
            return;
        }
        float chance = Random.Range(0f, 1f);
        Debug.Log(chance);

        if(chance < 0.2f) // do nothing
        {
            return;
        }
        else if(chance < 0.8f) // instantiate a  fill object with value 2
        {
            
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(2);
        }
            else // instantiate a  fill object with value 4
        {
       
            GameObject tempFill = Instantiate(fillPrefab, Cells[spawnChoice]);
            Debug.Log(4);
        }
    }
}
