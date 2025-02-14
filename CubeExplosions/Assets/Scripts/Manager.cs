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
        if (GetSpawnChance(cube))
            _detonator.Explode(_spawner.Spawn(cube), cube.transform.position);

        Destroy(cube.gameObject);
    }

    private bool GetSpawnChance(Cube cube)
    {
        int minNumberOfChance = 0;
        int maxNumberOfChance = 100;

        return Random.Range(minNumberOfChance, maxNumberOfChance) <= cube.ChanceTreshold;
    }
}