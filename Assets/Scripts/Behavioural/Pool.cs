using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance { get; private set; }

    public List<D_PoolItem> platformList;
    public List<D_PoolItem> obstacleList;
    public List<D_PoolItem> cubeList;

    public List<GameObject> pooledGroundList;
    public List<GameObject> pooledObstacleList;
    public List<GameObject> pooledCubeList;

    private void Awake()
    {
        Instance = this;
        InitPools();
    }

    private void InitPools()
    {
        pooledGroundList = new List<GameObject>();
        pooledObstacleList = new List<GameObject>();
        pooledCubeList = new List<GameObject>();

        foreach (D_PoolItem item in platformList)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject go = Instantiate(item.prefab,transform);
                go.SetActive(false);
                pooledGroundList.Add(go);
            }
        }
        foreach (D_PoolItem item in obstacleList)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject go = Instantiate(item.prefab, transform);
                go.SetActive(false);
                pooledObstacleList.Add(go);
            }
        }
        foreach (D_PoolItem item in cubeList)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject go = Instantiate(item.prefab, transform);
                go.SetActive(false);
                pooledCubeList.Add(go);
            }
        }
    }

    public GameObject GetRandomPrefabFromGroundPool()
    {
        UtilsClass.Shuffle(pooledGroundList);
        for (int i = 0; i < pooledGroundList.Count; i++)
        {
            if (!pooledGroundList[i].activeInHierarchy)
            {
                return pooledGroundList[i];
            }
        }
        foreach (D_PoolItem item in platformList)
        {
            GameObject go = Instantiate(item.prefab);
            go.SetActive(false);
            pooledGroundList.Add(go);
            return go;
        }
        return null;
    }
    public GameObject GetRandomPrefabFromObstaclePool()
    {
        UtilsClass.Shuffle(pooledObstacleList);
        for (int i = 0; i < pooledObstacleList.Count; i++)
        {
            if (!pooledObstacleList[i].activeInHierarchy)
            {
                return pooledObstacleList[i];
            }
        }
        foreach (D_PoolItem item in obstacleList)
        {
            GameObject go = Instantiate(item.prefab);
            go.SetActive(false);
            pooledObstacleList.Add(go);
            return go;
        }
        return null;
    }
    public GameObject GetRandomPrefabFromCubePool()
    {
        UtilsClass.Shuffle(pooledCubeList);
        for (int i = 0; i < pooledCubeList.Count; i++)
        {
            if (!pooledCubeList[i].activeInHierarchy)
            {
                return pooledCubeList[i];
            }
        }
        foreach (D_PoolItem item in cubeList)
        {
            GameObject go = Instantiate(item.prefab);
            go.SetActive(false);
            pooledCubeList.Add(go);
            return go;
        }
        return null;
    }
}
