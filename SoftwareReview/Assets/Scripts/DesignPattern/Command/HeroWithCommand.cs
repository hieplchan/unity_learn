using UnityEngine;

[RequireComponent(typeof(AnimationManager))]
public class HeroWithCommand : MonoBehaviour, IEntity
{
    private AnimationManager _animationManager;
    public AnimationManager AnimationManager => _animationManager ??= GetComponent<AnimationManager>();

    public void Attack()
    {
        Debug.Log("Attacking");
    }

    public void Spin()
    {
        Debug.Log("Spining");
    }

    public void Jump()
    {
        Debug.Log("Jumping");
    }
}