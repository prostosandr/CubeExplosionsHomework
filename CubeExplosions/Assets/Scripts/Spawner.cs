using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minNumberOfCube;
    [SerializeField] private int _maxNumberOfCube;

    public List<Rigidbody> Spawn(Cube oldCube, Vector3 cubeScale, float chanceTreshold)
    {
        List<Rigidbody> spawnList = new List<Rigidbody>();

        for (int i = 0; i < Random.Range(_minNumberOfCube, _maxNumberOfCube); i++)
        {
            Cube newCube = Instantiate(oldCube, oldCube.transform.position, oldCube.transform.rotation);
            newCube.transform.localScale = cubeScale;
            newCube.SetChanceTreshold(chanceTreshold);

            if (newCube.TryGetComponent(out Rigidbody rigidbody))
            {
                spawnList.Add(rigidbody);
            }
        }

        return spawnList;
    }
}