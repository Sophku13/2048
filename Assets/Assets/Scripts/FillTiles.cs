using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillTiles : MonoBehaviour
{
    public int Value;
    [SerializeField] Text displayedValue;
    [SerializeField] float speed;
    bool hasCombined;
    [SerializeField] private Image tileImage; 
    public void FillValueUpdate(int ValueIn)
    {
        Value = ValueIn;
        displayedValue.text = Value.ToString();
        int colorIndex = GetColorIndex(Value);
        tileImage = GetComponent<Image>();
        tileImage.color = GameController.instance.fillColor[colorIndex];
    }
    int GetColorIndex(int ValueIn)
    {
        int index = 0;
        while(ValueIn != 1)
        {
            index++;
            ValueIn /= 2;
        }
        index--;
        return index;
    }

    private void Update()
    {
        ///<summary>
        ///Change speed at which variables move, combine and double the Value on the tiles
        ///</summary>
        if(transform.localPosition != Vector3.zero)
        {
            hasCombined = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if(hasCombined == false)
        {
            if(transform.parent.GetChild(0) != this.transform)
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            hasCombined = true;
        }
    }
    public void Doubled()
    {
        Value *= 2;
        GameController.instance.ScoreUpdate(Value);
        displayedValue.text = Value.ToString();
        
        int colorIndex = GetColorIndex(Value);
        tileImage.color = GameController.instance.fillColor[colorIndex];
    }
}