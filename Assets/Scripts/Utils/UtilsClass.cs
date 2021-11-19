using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsClass
{
    public static System.Random random = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    public static Vector3 GetRandomVector3(float maxX, float maxZ)
    {
        //Y is not exacly random
        float x = UnityEngine.Random.Range(maxX, -maxX);
        float z = UnityEngine.Random.Range(maxZ, -maxZ);
        return new Vector3(x, 1, z);
    }
}
