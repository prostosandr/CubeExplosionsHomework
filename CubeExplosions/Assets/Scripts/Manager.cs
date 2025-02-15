using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private MouseKeyReader _mouseKeyReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _detonator;

    private void OnEnable()
    {
        _mouseKeyReader.Clicked += Work;
    }

    private void OnDisable()
    {
        _mouseKeyReader.Clicked -= Work;
    }

    private void Work(Cube cube)
    {
        int divisor = 2;

        if (GetSpawnChance(cube))
            _detonator.Explode(_spawner.Spawn(cube, GetNewCubeScale(cube, divisor), GetNewChanceTreshold(cube, divisor)), cube.transform.position);

        Destroy(cube.gameObject);
    }

    private float GetNewChanceTreshold(Cube cube, int divisor)
    {
        return cube.ChanceTreshold / divisor;
    }

    private Vector3 GetNewCubeScale(Cube cube, int divisor)
    {
        return cube.transform.localScale / divisor;
    }

    private bool GetSpawnChance(Cube cube)
    {
        int minNumberOfChance = 0;
        int maxNumberOfChance = 100;

        return Random.Range(minNumberOfChance, maxNumberOfChance) <= cube.ChanceTreshold;
    }
}