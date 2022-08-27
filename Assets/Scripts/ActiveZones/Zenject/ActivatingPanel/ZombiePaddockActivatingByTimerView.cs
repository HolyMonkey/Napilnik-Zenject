using UnityEngine;
using Zenject;

public class ZombiePaddockActivatingByTimerView : MonoBehaviour
{
    private Material _material;
    private ZombiePaddockActivatingByTimer _activator;

    [Inject]
    private void Constructor(ZombiePaddockActivatingByTimer activator)
    {
        _activator = activator;
    }

    private void Awake()
    {
        _material = Instantiate(gameObject.GetComponent<Renderer>().material);
        gameObject.GetComponent<Renderer>().material = _material;
    }

    private void OnEnable()
    {
        _activator.Toogle += OnToggle;
    }

    private void OnDisable()
    {
        _activator.Toogle -= OnToggle;
    }

    private void OnToggle(bool active)
    {
        _material.color = active ? Color.blue : Color.yellow;
    }
}
