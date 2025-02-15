using UnityEngine;

public class CubeManager : MonoBehaviour
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

        if (TryToSpawn(cube.ChanceTreshold))
            _detonator.Explode(_spawner.Spawn(cube, GetNewCubeScale(cube.transform.localScale, divisor), GetNewChanceTreshold(cube.ChanceTreshold, divisor)), cube.transform.position);

        Destroy(cube.gameObject);
    }

    private float GetNewChanceTreshold(float chanceTreshold, int divisor)
    {
        return chanceTreshold / divisor;
    }

    private Vector3 GetNewCubeScale(Vector3 oldCubeScale, int divisor)
    {
        return oldCubeScale / divisor;
    }

    private bool TryToSpawn(float chanceTreshold)
    {
        int minNumberOfChance = 0;
        int maxNumberOfChance = 100;

        return Random.Range(minNumberOfChance, maxNumberOfChance) <= chanceTreshold;
    }
}