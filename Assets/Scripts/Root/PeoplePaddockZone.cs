using System;
using UnityEngine;

public class PeoplePaddockZone : IZone
{
    public bool HasHuman { get; internal set; }

    public bool Contains(Vector3 position)
    {
        throw new NotImplementedException();
    }

    internal Follower Exctract()
    {
        throw new NotImplementedException();
    }
}