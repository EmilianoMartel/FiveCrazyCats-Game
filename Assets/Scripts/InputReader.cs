using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action<SkillType> onSkillSelected = delegate { };
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

    public void SetQState(InputAction.CallbackContext inputContext)
    {
        onSkillSelected?.Invoke(SkillType.Q);
    }

    public void SetWStatate(InputAction.CallbackContext inputContext)
    {
        onSkillSelected?.Invoke(SkillType.W);
    }
}