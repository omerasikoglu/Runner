using UnityEngine;

[CreateAssetMenu(menuName = "Data/Cube")]
public class D_Cube : ScriptableObject
{
    [SerializeField] private bool _isCollected = false;

    public Color materialTintColor;
    public Material material;

    public int damage = 1;
    public bool isAlly = true;
    public bool isRandom;
    public bool IsCollected { get { return _isCollected; } }

}
