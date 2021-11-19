using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private D_PlatformGenerator data;

    private void Awake()
    {
        DataInit();
    }

    private void DataInit()
    {
        if (!PlayerPrefs.HasKey(Strings.LEVEL) || PlayerPrefs.GetInt(Strings.LEVEL) == 0)
        {
            PlayerPrefs.SetInt(Strings.LEVEL, 1);
        }

        data.currentLevel = PlayerPrefs.GetInt(Strings.LEVEL);
        data.platformPosition = Vector3.zero;

        //first 5 level constant then all random
        if (data.currentLevel <= 5)
        {
            Instantiate(data.levelList[data.currentLevel - 1]);
        }
        else
        {
            SpawnPlatforms();
        }
    }

    private void SpawnPlatforms()
    {
        //seviyeye göre bölüm uzunluðunun artmasý

        Spawn(data.first);

        for (int i = 0; i < data.currentLevel * 2; i++)
        {
            Spawn(data.platform);
        }

        Spawn(data.final);
    }

    private void Spawn(GameObject platformType)
    {
        GameObject go = Instantiate(platformType);
        go.transform.position += data.platformPosition;
        data.platformPosition.z += data.groundZ;
    }
}
