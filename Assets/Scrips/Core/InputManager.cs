using UnityEngine;
public class InputManager : MonoBehaviour
{
    private void Update()
    {
        DetectClick();
    }

    private void DetectClick()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            InputEvent.OnPlayerMove?.Invoke();
        }
        else
        {
            InputEvent.OnPlayerStop?.Invoke();
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            InputEvent.OnPlayerSprint?.Invoke();
        }

        if (Input.GetKey(KeyCode.Space)) InputEvent.OnPlayerJump?.Invoke();
        if (Input.GetKey(KeyCode.E)) InputEvent.OnPlayerAttack?.Invoke();
       
    }
}