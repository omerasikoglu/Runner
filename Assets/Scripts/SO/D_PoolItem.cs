using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PoolItem")]
public class D_PoolItem : ScriptableObject
{
    public GameObject prefab;
    public int amount;
}
