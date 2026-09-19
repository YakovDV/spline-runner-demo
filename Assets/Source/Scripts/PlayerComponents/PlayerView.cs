using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject[] _states;

    public void SetState(PlayerState state)
    {
        int index = (int)state;

        for (int i = 0; i < _states.Length; i++)
            _states[i].SetActive(i == index);
    }
}