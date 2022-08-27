using System;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    event Action<Vector3> Moved;

    IEnumerable<Follower> Followers { get; }
    bool HasOnlyZombiesOrNothing { get; }
    Vector3 Position { get; }

    public void AddFollower(Follower follower);
    bool TryPullHuman();
}

public class Follower
{
}