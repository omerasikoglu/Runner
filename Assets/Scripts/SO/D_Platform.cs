using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Platform")]
public class D_Platform : ScriptableObject
{
    public GameObject collectibleCube;
    public GameObject collectibleCoin;
    public List<GameObject> obstacleList;

    public float collectibleCubeMaxX = 0.3f;
    public float collectibleCubeMaxZ = 0.5f;

    public float obstacleMaxX = 0.2f;
    public float obstacleMaxZ = 0.5f;

    public float coinMaxX = 0.4f;
    public float coinMaxZ = 0.5f;

    public int collectibleCubeCount = 2;
    public int coinCount = 1;
    public int obstacleCount = 1;
}
