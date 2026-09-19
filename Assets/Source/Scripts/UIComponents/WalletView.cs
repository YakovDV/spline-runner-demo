using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Wallet _wallet;

    private void Start()
    {
        _text.text = "0";
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= OnValueChanged;
    }

    public void SetWallet(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _text.text = value.ToString();
    }
}