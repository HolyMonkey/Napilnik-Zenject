using System;
using UnityEngine;
using Zenject;

public class ZombiePaddock : MonoBehaviour
{
    private int _currentStep = 0;
    private int _maxStep = 3;

    public bool ReadyToExtract => _currentStep == _maxStep;

    public event Action<float> ProgressNormalized;

    public void NextStep()
    {
        if (ReadyToExtract)
            throw new InvalidOperationException("Paddock is fully");

        _currentStep++;

        ProgressNormalized?.Invoke((float)_currentStep / _maxStep);
    }

    public void Extract()
    {
        if(ReadyToExtract == false)
            throw new InvalidOperationException("Paddock is not ready");

        _currentStep = 0;

        ProgressNormalized?.Invoke((float)_currentStep / _maxStep);
    }

    public class Factory : PlaceholderFactory<ZombiePaddock>
    {
    }
}
