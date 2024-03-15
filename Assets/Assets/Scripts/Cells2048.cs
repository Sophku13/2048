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
and moves an object up, left, down, or right, unless it's at the grid's edge. 
</summary>
*/
    {
        Debug.Log(sentContents);
        if (sentContents == "w") // shift all fill objects up
        {
            if (up != null)
                return;
                Cells2048 currentCell = this;
                SlideUp(currentCell);
        }
        if (sentContents == "a") // shift all fill objects left
        {
            if (left != null)
                return;
                Cells2048 currentCell = this;
                SlideLeft(currentCell);
        }
        if (sentContents == "s") // shift all fill objects down
        {
            if (down != null)
                return;
                Cells2048 currentCell = this;
                SlideDown(currentCell);
        }
        if (sentContents == "d") // shift all fill objects right
        {
            if (right != null)
                return;
                Cells2048 currentCell = this;
                SlideRight(currentCell);
        }
    }
/**
* <summary>
moves a cell (up, left, down, right) combining it with another cell if they have the same value,
or just moves it (up, left, down, right) if the next cell is empty, repeating this process until it can't move further.
</summary>
*/
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
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else //not the same value
                {
                    nextCell.fill.Doubled();
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
void SlideLeft(Cells2048 currentCell)
    {
        if(currentCell.right == null)
        return;

        Debug.Log(currentCell.gameObject);

        if(currentCell.fill != null)
        {
            Cells2048 nextCell = currentCell.right;
            while(nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }

            if(nextCell.fill != null)
            {
                if(currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else //not the same value
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.right.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.right.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextCell = currentCell.right;
            while(nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
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

        if (currentCell.right == null)
            return;
            SlideLeft(currentCell.right);
    }
    void SlideDown(Cells2048 currentCell)
    {
        if(currentCell.up == null)
        return;

        Debug.Log(currentCell.gameObject);

        if(currentCell.fill != null)
        {
            Cells2048 nextCell = currentCell.up;
            while(nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }

            if(nextCell.fill != null)
            {
                if(currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else //not the same value
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.up.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.up.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextCell = currentCell.up;
            while(nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
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

        if (currentCell.up == null)
            return;
            SlideDown(currentCell.up);
    }

    void SlideRight(Cells2048 currentCell) // work for right
    {
        if(currentCell.left == null)
        return;

        Debug.Log(currentCell.gameObject);

        if(currentCell.fill != null)
        {
            Cells2048 nextCell = currentCell.left;
            while(nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }

            if(nextCell.fill != null)
            {
                if(currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else 
                {
                    nextCell.fill.Doubled();
                    nextCell.fill.transform.parent = currentCell.left.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.left.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextCell = currentCell.left;
            while(nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
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

        if (currentCell.left == null)
            return;
            SlideRight(currentCell.left);
    }
}
