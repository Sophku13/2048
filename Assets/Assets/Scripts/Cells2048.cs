using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells2048 : MonoBehaviour
{
    public Cells2048 Right;
    public Cells2048 Left;
    public Cells2048 Up;
    public Cells2048 Down;

    public FillTiles fill;

    private void OnEnable() // Subscribes to a slide event
    {
        GameController.Slide += OnSlide;
    }

    private void OnDisable() // Unsubscribes
    {
        GameController.Slide -= OnSlide;
    }

    private void OnSlide(string sentContents)
/**
* <summary>
reacts to direction inputs ('w', 'a', 's', 'd')
and moves an object Up, Left, Down, or Right, unless it's at the grid's edge. 
</summary>
*/
    {
        Debug.Log(sentContents);
        if (sentContents == "w") // shift all fill objects Up
        {
            if (Up != null)
                return;
                Cells2048 currentCell = this;
                SlideUp(currentCell);
        }
        if (sentContents == "a") // shift all fill objects Left
        {
            if (Left != null)
                return;
                Cells2048 currentCell = this;
                SlideLeft(currentCell);
        }
        if (sentContents == "s") // shift all fill objects Down
        {
            if (Down != null)
                return;
                Cells2048 currentCell = this;
                SlideDown(currentCell);
        }
        if (sentContents == "d") // shift all fill objects Right
        {
            if (Right != null)
                return;
                Cells2048 currentCell = this;
                SlideRight(currentCell);
        }
        GameController.ActionCounter++;
        if(GameController.ActionCounter == 4)
        {
            GameController.instance.SpawnCells();
        }
    }
/**
* <summary>
moves a cell (Up, Left, Down, Right) combining it with another cell if they have the same Value,
or just moves it (Up, Left, Down, Right) if the next cell is empty, repeating this process until it can't move further.
</summary>
*/
    void SlideUp(Cells2048 currentCell)
    {
        if(currentCell.Down == null)
        return;

        Debug.Log(currentCell.gameObject);

        if(currentCell.fill != null)
        {
            Cells2048 nextCell = currentCell.Down;
            while(nextCell.Down != null && nextCell.fill == null)
            {
                nextCell = nextCell.Down;
            }

            if(nextCell.fill != null)
            {
                if(currentCell.fill.Value == nextCell.fill.Value)
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same Value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if(currentCell.Down.fill != nextCell.fill)
                {
                    Debug.Log("not doubled");
                    nextCell.fill.transform.parent = currentCell.Down.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.Down.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextCell = currentCell.Down;
            while(nextCell.Down != null && nextCell.fill == null)
            {
                nextCell = nextCell.Down;
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

        if (currentCell.Down == null)
            return;
            SlideUp(currentCell.Down);
    }
void SlideLeft(Cells2048 currentCell)
    {
        if(currentCell.Right == null)
        return;

        Debug.Log(currentCell.gameObject);

        if(currentCell.fill != null)
        {
            Cells2048 nextCell = currentCell.Right;
            while(nextCell.Right != null && nextCell.fill == null)
            {
                nextCell = nextCell.Right;
            }

            if(nextCell.fill != null)
            {
                if(currentCell.fill.Value == nextCell.fill.Value)
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same Value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if(currentCell.Right.fill != nextCell.fill)
                {
                    Debug.Log("not doubled");
                    nextCell.fill.transform.parent = currentCell.Right.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.Right.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextCell = currentCell.Right;
            while(nextCell.Right != null && nextCell.fill == null)
            {
                nextCell = nextCell.Right;
            }

            if(nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideLeft(currentCell);
                Debug.Log("Slide to empty tile");
            }
        }

        if (currentCell.Right == null)
            return;
            SlideLeft(currentCell.Right);
    }
    void SlideDown(Cells2048 currentCell)
    {
        if(currentCell.Up == null)
        return;

        Debug.Log(currentCell.gameObject);

        if(currentCell.fill != null)
        {
            Cells2048 nextCell = currentCell.Up;
            while(nextCell.Up != null && nextCell.fill == null)
            {
                nextCell = nextCell.Up;
            }

            if(nextCell.fill != null)
            {
                if(currentCell.fill.Value == nextCell.fill.Value)
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same Value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if(currentCell.Up.fill != nextCell.fill)
                {
                    Debug.Log("not doubled");
                    nextCell.fill.transform.parent = currentCell.Up.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.Up.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextCell = currentCell.Up;
            while(nextCell.Up != null && nextCell.fill == null)
            {
                nextCell = nextCell.Up;
            }

            if(nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideDown(currentCell);
                Debug.Log("Slide to empty tile");
            }
        }

        if (currentCell.Up == null)
            return;
            SlideDown(currentCell.Up);
    }

    void SlideRight(Cells2048 currentCell) // work for Right
    {
        if(currentCell.Left == null)
        return;

        Debug.Log(currentCell.gameObject);

        if(currentCell.fill != null)
        {
            Cells2048 nextCell = currentCell.Left;
            while(nextCell.Left != null && nextCell.fill == null)
            {
                nextCell = nextCell.Left;
            }

            if(nextCell.fill != null)
            {
                if(currentCell.fill.Value == nextCell.fill.Value)
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.Left.fill != nextCell.fill)
                {
                    Debug.Log("not doubled");
                    nextCell.fill.transform.parent = currentCell.Left.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.Left.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextCell = currentCell.Left;
            while(nextCell.Left != null && nextCell.fill == null)
            {
                nextCell = nextCell.Left;
            }

            if(nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideRight(currentCell);
                Debug.Log("Slide to empty tile");
            }
        }

        if (currentCell.Left == null)
            return;
            SlideRight(currentCell.Left);
    }
}
