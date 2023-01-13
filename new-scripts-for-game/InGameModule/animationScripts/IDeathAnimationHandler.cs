using System;

public interface IDeathAnimationHandler
{
    event Action OnDeathStartedEvent;
    string SetAnimationClip();
}
