using UnityEngine;

[CreateAssetMenu]
public class ProjectileData : ScriptableObject
{
    public GameObject prefab;
    public int damage;
    public float speed;
    public LayerMask hitLayers;
    public float destroyTime = 2f;
}