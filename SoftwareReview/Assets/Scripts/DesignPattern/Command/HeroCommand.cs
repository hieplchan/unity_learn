using System;
using Cysharp.Threading.Tasks;

public abstract class HeroCommand : ICommand
{
    protected readonly IEntity Hero;

    protected HeroCommand(IEntity hero)
    {
        Hero = hero;
    }

    public abstract UniTask Execute();

    public static T Create<T>(IEntity hero) where T : HeroCommand
    {
        return (T) Activator.CreateInstance(typeof(T), hero);
    }
}

public class AttackCommand : HeroCommand
{
    public AttackCommand(IEntity hero) : base(hero)
    {
    }

    public override async UniTask Execute()
    {
        Hero.Attack();
        await UniTask.Delay(TimeSpan.FromSeconds(Hero.AnimationManager.Attack()));
        Hero.AnimationManager.Idle();
    }
}

public class SpinCommand : HeroCommand
{
    public SpinCommand(IEntity hero) : base(hero)
    {
    }

    public override async UniTask Execute()
    {
        Hero.Spin();
        await UniTask.Delay(TimeSpan.FromSeconds(Hero.AnimationManager.Spin()));
        Hero.AnimationManager.Idle();
    }
}

public class JumpCommand : HeroCommand
{
    public JumpCommand(IEntity hero) : base(hero)
    {
    }

    public override async UniTask Execute()
    {
        Hero.Jump();
        await UniTask.Delay(TimeSpan.FromSeconds(Hero.AnimationManager.Jump()));
        Hero.AnimationManager.Idle();
    }
}