using UnityEngine;
using UnityEngine.UI;

public class InteractionPrompt : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(OnMouseButtonDown);
    }

    private void OnMouseButtonDown()
    {
        InputEvent.OnPlayerInteract?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnMouseButtonDown);
    }
}