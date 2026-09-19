using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _sliderSpeed = 1.0f;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _maxValue = 100f;

    private Slider _slider;
    private Coroutine _smoothSliderCoroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (_wallet == null)
        {
            return;
        }

        SetWallet(_wallet);
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= ShowValue;
    }

    public void SetWallet(Wallet wallet)
    {
        if (_wallet != null)
        {
            _wallet.ValueChanged -= ShowValue;
        }

        if (_slider.gameObject.activeSelf == false)
        {
            _slider.gameObject.SetActive(true);
        }

        _wallet = wallet;

        _slider.maxValue = _maxValue;
        _slider.minValue = 0f;

        _slider.value = 0f;

        _wallet.ValueChanged += ShowValue;
        ShowValue(_wallet.Value);
    }

    private void ShowValue(int health)
    {
        if (_smoothSliderCoroutine != null)
        {
            StopCoroutine(_smoothSliderCoroutine);
            _smoothSliderCoroutine = null;
        }

        _smoothSliderCoroutine = StartCoroutine(ChangeSliderSmooth((float)health));
    }

    private IEnumerator ChangeSliderSmooth(float health)
    {
        while (Mathf.Approximately(_slider.value, health) == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _sliderSpeed * Time.deltaTime);

            yield return null;
        }

        _slider.value = health;
    }
}