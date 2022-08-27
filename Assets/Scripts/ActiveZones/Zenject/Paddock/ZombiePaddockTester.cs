using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombiePaddockTester : MonoBehaviour
{
    [Inject] private ZombiePaddock _paddock;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _paddock.NextStep();

        if (Input.GetKeyDown(KeyCode.E))
            _paddock.Extract();
    }
}
