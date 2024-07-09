using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    private int _numFound;
    private readonly Collider[] _colliders = new Collider[3];
    private IInteractable _currentInteractable;

    private void Update()
    {
        CheckForInteractables();
    }

    private void CheckForInteractables()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
            _interactableMask);

        if (_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (_currentInteractable != interactable)
                {
                    _currentInteractable = interactable;
                    _currentInteractable.ShowInteractionPrompt(true);
                }
            }
        }
        else
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.ShowInteractionPrompt(false);
                _currentInteractable = null;
            }
        }
    }

    public void Interact()
    {
        if (_currentInteractable != null)
        {
            _currentInteractable.Interact(this);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}