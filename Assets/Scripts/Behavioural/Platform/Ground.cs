using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Platforms have 4 different cube spawn point and 1 obstacle point
 * Cubes and obstacles spawns randomly
 */
public class Ground : MonoBehaviour
{
    private Transform obstaclePoint;
    private Transform cubePoint1;
    private Transform cubePoint2;
    private Transform cubePoint3;
    private Transform cubePoint4;

    private const string OBSTACLE = "ObstaclePoint";
    private const string POINT1 = "CubePoint1";
    private const string POINT2 = "CubePoint2";
    private const string POINT3 = "CubePoint3";
    private const string POINT4 = "CubePoint4";

    private void Start()
    {
        InitObstacleAndCubes();
    }

    private void InitObstacleAndCubes()
    {
        obstaclePoint = transform.Find(OBSTACLE);
        cubePoint1 = transform.Find(POINT1);
        cubePoint2 = transform.Find(POINT2);
        cubePoint3 = transform.Find(POINT3);
        cubePoint4 = transform.Find(POINT4);

        GameObject pfObstacle = Pool.Instance.GetRandomPrefabFromObstaclePool();
        GameObject pfCubePoint1 = Pool.Instance.GetRandomPrefabFromCubePool();
        GameObject pfCubePoint2 = Pool.Instance.GetRandomPrefabFromCubePool();
        GameObject pfCubePoint3 = Pool.Instance.GetRandomPrefabFromCubePool();
        GameObject pfCubePoint4 = Pool.Instance.GetRandomPrefabFromCubePool();

        pfObstacle.SetActive(true);
        pfObstacle.transform.position = obstaclePoint.transform.position;

        pfCubePoint1.SetActive(true);
        pfCubePoint1.transform.position = cubePoint1.transform.position;

        pfCubePoint2.SetActive(true);
        pfCubePoint2.transform.position = cubePoint2.transform.position;

        pfCubePoint3.SetActive(true);
        pfCubePoint3.transform.position = cubePoint3.transform.position;

        pfCubePoint4.SetActive(true);
        pfCubePoint4.transform.position = cubePoint4.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.transform.GetComponent<PlayerController>();
        if (player != null)
        {
            Invoke(nameof(ReleaseLastGround), 4f);
        }
    }
    public void ReleaseLastGround() //get back to pool
    {
        gameObject.SetActive(false);
        obstaclePoint.gameObject.SetActive(false);
        cubePoint1.gameObject.SetActive(false);
        cubePoint2.gameObject.SetActive(false);
        cubePoint3.gameObject.SetActive(false);
        cubePoint4.gameObject.SetActive(false);
    }

}
