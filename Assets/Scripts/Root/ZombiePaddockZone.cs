using System;
using UnityEngine;
using Zenject;

public class ZombiePaddockZone : MonoBehaviour, IZone
{
    [Inject] private Transform _exitPoint;
    [Inject] private IFollowerFactory _zombieFacctory;

    public bool HasDoneZombie { get; internal set; }

    internal void Feed()
    {
        throw new NotImplementedException();
    }

    internal Follower Exctract()
    {
        Follower zombie = _zombieFacctory.Create(_exitPoint.position);

        return zombie;
    }

    public bool Contains(Vector3 position)
    {
        throw new NotImplementedException();
    }
}