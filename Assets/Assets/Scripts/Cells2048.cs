using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells2048 : MonoBehaviour
{
    public Cells2048 right;
    public Cells2048 left;
    public Cells2048 up;
    public Cells2048 down;

    public FillTiles fill;

    private void OnEnable() // Subscribe
    {
        GameController.slide += OnSlide;
    }

    private void OnDisable() // Unsubscribe
    {
        GameController.slide -= OnSlide;
    }
    private void OnSlide(string sentContents)
    {
        Debug.Log(sentContents);

        if (sentContents == "w") // shift all fill objects up
        {
            if (up != null)
                //check if the current cell is one of the top cells
                //if it is not null, it is not one of the top cells
                return;

                Cells2048 currentCell = this;
                SlideUp(currentCell);
        }
        if (sentContents == "a") // shift all fill objects left
        {

        }
        if (sentContents == "s") // shift all fill objects down
        {

        }
        if (sentContents == "d") // shift all fill objects right
        {

        }
    }
    void SlideUp(Cells2048 currentCell)
    {
        if(currentCell.down == null)
        return;

        Debug.Log(currentCell.gameObject);

        if(currentCell.fill != null)
        {
            Cells2048 nextCell = currentCell.down;
            while(nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }

            if(nextCell.fill != null)
            {
                if(currentCell.fill.value == nextCell.fill.value)
                {
                    Debug.Log("doubled");
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else //not the same value
                {
                    Debug.Log("not doubled");
                    nextCell.fill.transform.parent = currentCell.down.transform;
                     currentCell.fill = nextCell.fill;
                    nextCell.down.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }

        }
        else
        {
             Cells2048 nextCell = currentCell.down;
            while(nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }

            if(nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideUp(currentCell);
                Debug.Log("Slide to empty tile");
            }
        }

        if (currentCell.down == null)
            return;
            SlideUp(currentCell.down);
    }
}
