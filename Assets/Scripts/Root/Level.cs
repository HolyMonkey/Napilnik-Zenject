using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [Inject] private List<IZone> _interectable;
    [Inject] private IPlayer _player;

    private IZone _stainInZone;
    private DelayedCall _delayedZoneCall;

    public event Action<Vector3> TryGetZombiesWithHumansInFollowers;

    private void Update()
    {
        if (_delayedZoneCall != null)
        {
            _delayedZoneCall.Update(Time.deltaTime);
        }
    }

    public void Composite()
    {


    }

    private void OnMoved(Vector3 position)
    {
        IZone activeZone = _interectable.FirstOrDefault(i => i.Contains(position));

        if (activeZone == null)
        {
            if(_stainInZone != null)
            {
                OnExitFromZone(_stainInZone);
                _stainInZone = null;
                return;
            }
        }    

        if (_stainInZone == activeZone)
            return;

        if(_stainInZone == null)
        {
            _stainInZone = activeZone;
            OnEnterInZone(activeZone);
        }
    }


    private void OnExitFromZone(IZone activeZone)
    {
        
    }

    private void OnEnterInZone(IZone activeZone)
    {
        if (activeZone is ZombiePaddockZone zombiePaddockZone)
        {
            _delayedZoneCall = new DelayedCall(10, () =>
            {
                if (_player.HasOnlyZombiesOrNothing == false)
                {
                    TryGetZombiesWithHumansInFollowers?.Invoke(_player.Position);
                    return;
                }

                if (zombiePaddockZone.HasDoneZombie)
                {
                    Follower zombie = zombiePaddockZone.Exctract();
                    _player.AddFollower(zombie);
                    return;
                }

                if (_player.TryPullHuman())
                    zombiePaddockZone.Feed();
            });
        }
        else if (activeZone is PeoplePaddockZone peoplePaddockZone)
        {
            if (peoplePaddockZone.HasHuman)
            {
                Follower zombie = peoplePaddockZone.Exctract();
            }
        }
        else if (activeZone is ZombieSellZone)
        {
            //
        }
        else if (activeZone is BuyZone)
        {
            //
        }
    }
}

public class DelayedCall
{
    private float _timeout;
    private Action _body;

    private bool _called;

    public DelayedCall(float timeout, Action body)
    {
        _timeout = timeout;
        _body = body;
    }

    internal void Update(float deltaTime)
    {
        _timeout -= deltaTime;

        if(_timeout <= 0)
        {
            _body?.Invoke();
            _called = true;
        }
    }
}