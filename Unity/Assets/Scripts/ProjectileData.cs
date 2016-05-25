using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileData : ScriptableObject
{
    public GameObject prefab;
    public int damage;
    public float speed;
    public LayerMask hitLayers;
}
