using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] GameObject finalGround;
    public static GroundGenerator Instance { get; private set; }

    private Vector3 groundPosition;

    private float groundZ = 20; //her bir bast���m�z platforrmun uzunlu�u
    private int groundCount = 0;
    private int currentLevel;

    private const string LEVEL = "level";

    private void Awake()
    {
        Instance = this;
        groundPosition = new Vector3(0, 0, 0); //platformun Instantiate edilece�i yerin konumu
        currentLevel = PlayerPrefs.GetInt(LEVEL);
        SpawnGround();
    }

    public void SpawnGround()
    {
        //seviyeye g�re b�l�m uzunlu�unun artmas�
        GameObject go = groundCount == currentLevel * 5 ? Instantiate(finalGround) : Pool.Instance.GetRandomPrefabFromGroundPool();

        go.SetActive(true);
        go.transform.position += new Vector3(0, 0, groundZ * groundCount);
        go.transform.SetParent(transform);

        groundPosition.x = go.transform.position.x;
        groundPosition.z += groundZ;
        groundCount++;

    }
}
