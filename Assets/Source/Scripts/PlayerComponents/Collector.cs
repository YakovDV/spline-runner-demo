using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectable) == false)
            return;

        _wallet.Add(collectable.Value);
        collectable.Collect();
    }
}
