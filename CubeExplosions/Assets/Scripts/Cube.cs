using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceTreshold;

    public float ChanceTreshold => _chanceTreshold;

    private void Awake()
    {
        ChangeColor();
    }

    public void SetChanceTreshold(float newChanceTreshold)
    {
        _chanceTreshold = newChanceTreshold;
    }

    private void ChangeColor()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}
