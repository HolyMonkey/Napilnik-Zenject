using UnityEngine;
using Zenject;

public class ZombiePaddockActivatingByTimer : MonoBehaviour
{
    private ZombiePaddock _target;
    private float _timer;
    private float _tickCooldown;

    public bool Active { get; private set; }

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
        Active = false;
    }

    public void OnExit()
    {
        Active = false;
    }

    private void Activate()
    {
        if (_target.ReadyToExtract)
            _target.Extract();

        _target.NextStep();
    }

}
