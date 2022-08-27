using System;
using UnityEngine;
using Zenject;

public class ZombiePaddockActivatingByTimer : MonoBehaviour
{
    private ZombiePaddock _target;
    private float _timer;
    private float _tickCooldown = 1;

    public bool Active { get; private set; }
    public event Action<bool> Toogle;

    [Inject]
    private void Contrstructor(ZombiePaddock target)
    {
        _target = target;
    }

    private void Update()
    {
        if (Active)
        {
            _timer += Time.deltaTime;
            if(_timer > _tickCooldown)
            {
                Activate();
                _timer = 0;
            }
        }
    }

    public void OnEnter()
    {
        if (Active) 
            return;
        
        Active = true;
        Toogle?.Invoke(true);
    }

    public void OnExit()
    {
        if (Active == false)
            return;

        Active = false;
        Toogle?.Invoke(false);
    }

    private void Activate()
    {
        if (_target.ReadyToExtract)
            _target.Extract();

        _target.NextStep();
    }

}
