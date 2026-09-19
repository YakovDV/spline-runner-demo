using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _text.text = _player.CurrentState.ToString();
    }

    private void OnEnable()
    {
        _player.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        _player.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(PlayerState state)
    {
        _text.text = state.ToString();
    }
}