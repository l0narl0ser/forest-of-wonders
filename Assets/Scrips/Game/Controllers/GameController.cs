using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private AssetReference _scene;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        _restartButton.gameObject.SetActive(false);
        EnemyEvent.OnEnemyDead += OnEnemyDead;
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        _sceneLoader.LoadScene(_scene);
    }

    private void OnEnemyDead()
    {
        _restartButton.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EnemyEvent.OnEnemyDead -= OnEnemyDead;
        _restartButton.onClick.RemoveListener(RestartGame);
    }
}