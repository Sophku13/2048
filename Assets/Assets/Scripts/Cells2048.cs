using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells2048 : MonoBehaviour
{
    public Cells2048 right;
    public Cells2048 left;
    public Cells2048 up;
    public Cells2048 down;
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
    }
}
