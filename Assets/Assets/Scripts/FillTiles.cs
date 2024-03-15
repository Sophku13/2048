using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillTiles : MonoBehaviour
{
    public int value;
    [SerializeField] Text displayedValue;
    [SerializeField] float speed;
    bool hasCombined;
    public void FillValueUpdate(int valueIn)
{
    value = valueIn;
    displayedValue.text = value.ToString();
}
    private void Update()
    {
        ///<summary>
        ///Change speed at which variables move, combine and double the value on the tiles
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
        value *= 2;
        displayedValue.text = value.ToString();
    }
}