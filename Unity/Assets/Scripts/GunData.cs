using UnityEngine;

[CreateAssetMenu]
public class GunData : ScriptableObject
{
    public ProjectileData projectile;
    public float rateOfFire = .5f;
}