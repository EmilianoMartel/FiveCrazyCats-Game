using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelector : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private ShootLogic _shoot;
    [SerializeField] private FireLogic _fire;

    private void OnEnable()
    {
        _inputReader.onSkillSelected += HandleSkill;    
    }

    private void OnDisable()
    {
        _inputReader.onSkillSelected -= HandleSkill;
    }

    private void Awake()
    {
        NullReferrenceController();
    }

    private void HandleSkill(SkillType type)
    {
        switch (type)
        {
            case SkillType.Q:
                _shoot.enabled = true;
                _fire.gameObject.SetActive(false);
                break;
            case SkillType.W:
                _shoot.enabled = false;
                _fire.gameObject.SetActive(true);
                break;
            case SkillType.E:
                break;
            case SkillType.R:
                break;
            default:
                break;
        }
    }

    private void NullReferrenceController()
    {
        if (!_shoot)
        {
            Debug.LogError($"{name}: Shoot is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (!_inputReader)
        {
            Debug.LogError($"{name}: Input reader is null-\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (!_fire)
        {
            Debug.LogError($"{name}: Fire is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
    }
}