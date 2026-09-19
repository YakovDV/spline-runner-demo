using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int State = Animator.StringToHash("State");
    private static readonly int Win = Animator.StringToHash("Win");
    private static readonly int Lose = Animator.StringToHash("Lose");

    [SerializeField] private Animator _animator;

    public void SetMoving(bool isMoving)
    {
        _animator.SetBool(IsMoving, isMoving);
    }

    public void SetState(PlayerState state)
    {
        _animator.SetInteger(State, (int)state);
    }

    public void PlayWin()
    {
        _animator.SetTrigger(Win);
    }

    public void PlayLose()
    {
        _animator.SetTrigger(Lose);
    }
}
