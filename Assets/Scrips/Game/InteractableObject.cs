using UnityEngine;

public class InteractableObject: MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _interactionPromptUI;
    
    private void Start()
    {
        _interactionPromptUI.SetActive(false);
    }

    public bool Interact(Interactor interactor)
    {
        Destroy(gameObject);
        return true;
    }

    public void ShowInteractionPrompt(bool show)
    {
        if (_interactionPromptUI==null) return;
        _interactionPromptUI.SetActive(show);
    }
}
