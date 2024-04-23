using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> onLookAt = delegate { };
    public event Action onMove = delegate { };

    public void SetMovement(InputAction.CallbackContext inputContext)
    {
        onMove?.Invoke();
    }

    public void SetLookAt(InputAction.CallbackContext inputContext)
    {
        onLookAt?.Invoke(inputContext.ReadValue<Vector2>());
    }
}
