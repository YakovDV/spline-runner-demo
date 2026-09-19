using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LevelEnd : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    private Collider _finishZone;

    public event Action FinishReached;

    private void Awake()
    {
        _finishZone = GetComponent<Collider>();
        _finishZone.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            FinishReached?.Invoke();
            _animation.Play();
        }
    }
}