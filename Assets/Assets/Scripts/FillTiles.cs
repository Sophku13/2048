using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillTiles : MonoBehaviour
{
    public int value;
    [SerializeField] Text displayedValue;
    
    public void FillValueUpdate(int valueIn)
{
    value = valueIn;
    displayedValue.text = value.ToString();
}

}