using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Rigidbody> explodableObjects, Vector3 OldCubePosition)
    {
        foreach (Rigidbody explodableObject in explodableObjects)
        {
            explodableObject.AddExplosionForce(_explosionForce, OldCubePosition, _explosionForce);
        }
    }
}
