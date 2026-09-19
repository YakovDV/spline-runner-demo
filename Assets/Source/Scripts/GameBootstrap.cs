using SplineMesh;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private CameraMover _cameraMover;

    [Header("Level")]
    [SerializeField] private PointerHorizontalInput _horizontalInput;
    [SerializeField] private Spline _spline;
    [SerializeField] private LevelEnd _levelEnd;
    [SerializeField] private int _winPoints = 100;

    [Header("UI")]
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private WalletView _walletView;

    private Player _player;
    private Wallet _wallet;

    private bool _started;
    private bool _finished;

    private void Start()
    {
        CreatePlayer();

        _startPanel.SetActive(true);
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);

        _levelEnd.FinishReached += OnFinishReached;
    }

    private void Update()
    {
        if (_started || _finished)
            return;

        if (Input.GetMouseButtonDown(0))
            StartGame();
    }

    private void OnDestroy()
    {
        _levelEnd.FinishReached -= OnFinishReached;
    }

    private void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation);
        _player.Initialize(_horizontalInput ,_spline);

        _wallet = _player.Wallet;

        _walletView.SetWallet(_wallet);
        _cameraMover.SetTrackingPoint(_player.transform);
    }

    private void StartGame()
    {
        _started = true;

        _startPanel.SetActive(false);
        _player.StartMoving();
    }

    private void OnFinishReached()
    {
        if (_finished)
            return;

        _finished = true;

        if (_wallet.Value >= _winPoints)
        {
            _player.Win();
            _winPanel.SetActive(true);
        }
        else
        {
            _player.Lose();
            _losePanel.SetActive(true);
        }
    }
}