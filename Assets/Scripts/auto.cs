using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto : MonoBehaviour
{
    string color = "negro";

    public void cambiarcolor(string colorcito)
    {
        color = colorcito;
    }

    private void Update()
    {
        cambiarcolor("blanco");
    }
}
