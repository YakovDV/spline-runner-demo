using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] private int _value;
    [SerializeField] private AudioClip _collectSound;

    public int Value => _value;

    public void Collect()
    {
        AudioSource.PlayClipAtPoint(_collectSound, transform.position);
        gameObject.SetActive(false);
    }
}
