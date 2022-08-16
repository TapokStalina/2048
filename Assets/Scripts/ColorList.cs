using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorList : MonoBehaviour
{
    public static ColorList Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;  
    }

    public Color[] CellColors;

    public Color DarkColor;

    public Color LightColor;



}
