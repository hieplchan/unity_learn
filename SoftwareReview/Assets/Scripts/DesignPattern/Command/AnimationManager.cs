using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    private Animator _animator;

    #region Animation Hash & Duration

    private static readonly int AttackHash = Animator.StringToHash("Attack01_SwordAndShiled");
    private static readonly int SpinHash = Animator.StringToHash("Attack04_Spinning_SwordAndShield");
    private static readonly int JumpHash = Animator.StringToHash("JumpFull_Spin_RM_SwordAndShield");
    private static readonly int IdleHash = Animator.StringToHash("Idle_Battle_SwordAndShiled");

    private readonly Dictionary<int, float> _animationDuration = new()
    {
        { AttackHash, 1f },
        { SpinHash, 1f },
        { JumpHash, 1f },
        { IdleHash, 0f }
    };

    #endregion
    
    private void Awake() => _animator = GetComponent<Animator>();

    public float Attack() => PlayAnimation(AttackHash);
    public float Spin() => PlayAnimation(SpinHash);
    public float Jump() => PlayAnimation(JumpHash);
    public void Idle() => PlayAnimation(IdleHash);
    
    private float PlayAnimation(int animationHash)
    {
        _animator.CrossFade(animationHash, 0.1f);
        return _animationDuration[animationHash];
    }
}