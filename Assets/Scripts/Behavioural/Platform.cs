using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private D_Platform data;

    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        SpawnObject(data.collectibleCube, data.collectibleCubeCount, data.collectibleCubeMaxX, data.collectibleCubeMaxZ);

        for (int i = 0; i < data.obstacleCount; i++)
        {
            int j = UnityEngine.Random.Range(0, data.obstacleList.Count);

            SpawnObject(data.obstacleList[j],data.obstacleCount, data.obstacleMaxX, data.obstacleMaxZ);

        }
        SpawnObject(data.collectibleCoin, data.coinCount, data.coinMaxX, data.coinMaxZ);
    }

    private void SpawnObject(GameObject prefab, int amount, float maxX, float maxZ)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject go = Instantiate(prefab);
            go.transform.SetParent(transform);
            Vector3 pos = UtilsClass.GetRandomVector3(maxX, maxZ);
            go.transform.localPosition = pos;
            if (Physics.CheckSphere(go.transform.position, 0.3f))
            {
                Destroy(go);
            }
            else
            {
                continue;
            }
        }
    }
}
