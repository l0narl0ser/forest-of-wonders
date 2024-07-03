using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private AssetReference _scene;

    private void Start()
    {
        if (_startButton != null) _startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        if (_sceneLoader != null) _sceneLoader.LoadScene(_scene);
    }
}