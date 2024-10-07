public interface IEntity
{
    void Attack();
    void Spin();
    void Jump();

    AnimationManager AnimationManager { get; }
}