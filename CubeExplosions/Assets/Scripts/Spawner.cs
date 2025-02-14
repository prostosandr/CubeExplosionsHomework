using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int minNumberOfCube;
    [SerializeField] int maxNumberOfCube;

    public List<Rigidbody> Spawn(Cube oldCube)
    {
        List<Rigidbody> spawnList = new List<Rigidbody>();

        for (int i = 0; i < Random.Range(minNumberOfCube, maxNumberOfCube); i++)
        {
            GameObject newGameObjectCube = Instantiate(oldCube.gameObject, oldCube.gameObject.transform.position, oldCube.gameObject.transform.rotation);

            if (newGameObjectCube.TryGetComponent(out Rigidbody rigidbody) && newGameObjectCube.TryGetComponent(out Cube cube))
            {
                spawnList.Add(rigidbody);

                cube.DecreaseChanceAndScale();
            }
        }

        return spawnList;
    }
}