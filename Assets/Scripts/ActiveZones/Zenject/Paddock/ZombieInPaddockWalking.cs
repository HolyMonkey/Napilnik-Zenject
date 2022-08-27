using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInPaddockWalking : MonoBehaviour
{
    [SerializeField] private ParticleSystem _leftFootStepEffect;
    [SerializeField] private ParticleSystem _rightFootStepEffect;

    private Vector3 _targetPoint;
    private float _speed = 0.3f;

    private void Update()
    {
        if (_targetPoint == transform.localPosition)
            _targetPoint = new Vector3(Random.Range(0f, 1.2f), transform.localPosition.y, Random.Range(0f, 1.2f));

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPoint, _speed * Time.deltaTime);

        transform.LookAt(_targetPoint);
    }

    public void LeftStep()
    {
        _leftFootStepEffect.Play();
    }

    public void RightStep()
    {
        _rightFootStepEffect.Play();
    }
}
