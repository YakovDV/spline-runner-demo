using SplineMesh;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int FirstStateMoney = 70;
    private const int SecondStateMoney = 100;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private SplineFollower _follower;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private PlayerView _view;

    public PlayerState CurrentState { get; private set; }
    public Wallet Wallet => _wallet;

    public event Action<PlayerState> StateChanged;

    private void OnEnable()
    {
        _wallet.ValueChanged += OnWalletValueChanged;
        OnWalletValueChanged(_wallet.Value);
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= OnWalletValueChanged;
    }

    public void Initialize(PointerHorizontalInput horizontalInput, Spline spline)
    {
        _follower.Initialize(horizontalInput, spline);
    }

    public void StartMoving()
    {
        _follower.Enable();
        _animator.SetMoving(true);
    }

    public void Win()
    {
        _follower.Disable();
        _animator.SetMoving(false);
        _animator.PlayWin();
    }

    public void Lose()
    {
        _follower.Disable();
        _animator.SetMoving(false);
        _animator.PlayLose();
    }

    private void OnWalletValueChanged(int value)
    {
        PlayerState state = ResolveState(value);

        if (state == CurrentState)
            return;

        CurrentState = state;

        _view.SetState(CurrentState);
        _animator.SetState(CurrentState);

        StateChanged?.Invoke(CurrentState);
    }

    private PlayerState ResolveState(int value)
    {
        switch (value)
        {
            case < FirstStateMoney:
                return PlayerState.poor;
            case < SecondStateMoney:
                return PlayerState.normal;
            case >= SecondStateMoney:
                return PlayerState.rich;
        }
    }
}
