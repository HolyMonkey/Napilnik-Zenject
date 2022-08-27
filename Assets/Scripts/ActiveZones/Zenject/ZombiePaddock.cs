using System;
using UnityEngine;
using UnityEngine.UI;

namespace WithZenject
{
    public class ZombiePaddock : MonoBehaviour, IDonable
    {
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
        }

        private void OnMouseDown()
        {
            NextStep();
        }
    }
}