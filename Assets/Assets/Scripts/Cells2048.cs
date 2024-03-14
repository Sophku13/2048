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
                    Debug.Log("doubled");
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else //not the same value
                {
                    Debug.Log("not doubled");
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
                    Debug.Log("doubled");
                    nextCell.fill.transform.parent = currentCell.transform;
                    //2 fill objects with the same value that can be combined
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else //not the same value
                {
                    Debug.Log("not doubled");
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
                    Debug.Log("doubled");
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else 
                {
                    Debug.Log("not doubled");
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
