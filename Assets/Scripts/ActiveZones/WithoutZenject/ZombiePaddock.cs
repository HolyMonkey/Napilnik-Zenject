using System;
using UnityEngine;
using UnityEngine.UI;

public class ZombiePaddock : MonoBehaviour, IDonable
{
    [SerializeField] private Slider _progressView;

    private int _currentStep = 0;
    private int _maxStep = 3;

    public event Action Done; 

    public void NextStep()
    {
        _currentStep++;

        if (_currentStep > _maxStep)
        {
            _currentStep = 0;
            Done?.Invoke();
        }

        _progressView.value = (float)_currentStep / _maxStep;
    }
}
