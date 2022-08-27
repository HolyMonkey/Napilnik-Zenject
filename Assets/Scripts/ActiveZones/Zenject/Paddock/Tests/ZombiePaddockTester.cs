using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombiePaddockTester : MonoBehaviour
{
    [Inject] private ZombiePaddock _paddock;
    [Inject] private ZombiePaddockActivatingByTimer _activator;
    [Inject] private ZombiePaddock.Factory _factory;

    private void Awake()
    {
        Vector3 targetPosition = GameObject.Find("DynamicPaddock").transform.position;
        _factory.Create().transform.root.position = targetPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _paddock.NextStep();

        if (Input.GetKeyDown(KeyCode.E))
            _paddock.Extract();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (_activator.Active)
                _activator.OnExit();
            else
                _activator.OnEnter();
        }
    }
}
