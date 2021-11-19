using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private D_Cube data;

    private void Awake()
    {
        Init();
    }
 
    private void Init()
    {
        if (data.isRandom) data.isAlly = UnityEngine.Random.Range(0, 2) == 0 ? true : false;
        data.materialTintColor = data.isAlly ? Color.blue : Color.yellow;

        data.material = GetComponent<MeshRenderer>().material;
        data.material.SetColor(Strings.MAINCOLOR, data.materialTintColor);
    }

    public bool GetIsAlly()
    {
        return data.isAlly;
    }
    public int GetCubeDamage()
    {
        return data.damage;
    }
}
