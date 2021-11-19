using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlatformGenerator")]
public class D_PlatformGenerator : ScriptableObject
{
    public GameObject first;
    public GameObject final;
    public GameObject platform;
    public List<GameObject> levelList;

    public Vector3 platformPosition;
    private bool _randomLevelGenerate;
    public bool RandomLevelGenerate { get { return _randomLevelGenerate; } }

    public float groundZ = 20; //her bir bast���m�z platforrmun uzunlu�u
    public int platformCount = 0;
    public int currentLevel = 1;
}
