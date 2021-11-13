using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Cube")]
public class D_Cube : ScriptableObject
{
    public bool isAlly = true;
    public bool isRandom;

    public Color materialTintColor;
    public Material material;
}
