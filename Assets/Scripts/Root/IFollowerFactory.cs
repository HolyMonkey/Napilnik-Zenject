using UnityEngine;

internal interface IFollowerFactory
{
    Follower Create(Vector3 position);
}