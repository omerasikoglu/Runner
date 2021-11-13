using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public static GroundGenerator Instance { get; private set; }
   
    [SerializeField] private bool isfullRandomGenerate = false;
    [SerializeField] private GameObject finalGround;
    [SerializeField] private List<GameObject> firstFiveLevel;

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
        if (!isfullRandomGenerate) isfullRandomGenerate = currentLevel > 5;
        if (isfullRandomGenerate) SpawnGround();
        else
        {
            Instantiate(firstFiveLevel[currentLevel - 1]);
        }
    }

    public void SpawnGround()
    {
        //seviyeye g�re b�l�m uzunlu�unun artmas�
        GameObject go = groundCount == currentLevel * 2 ? Instantiate(finalGround) : Pool.Instance.GetRandomPrefabFromGroundPool();

        go.SetActive(true);
        go.transform.position += new Vector3(0, 0, groundZ * groundCount);
        go.transform.SetParent(transform);

        groundPosition.x = go.transform.position.x;
        groundPosition.z += groundZ;
        groundCount++;

    }
    public bool GetIsFullRandomGenerating()
    {
        return isfullRandomGenerate;
    }
}
