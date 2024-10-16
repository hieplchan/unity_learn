using System;
using UnityEngine;

public class HeroWithEventBus : MonoBehaviour
{
    private HealthComponent _healthComponent;
    private ManaComponent _manaComponent;

    private EventBinding<TestEvent> _testEventBinding;
    private EventBinding<PlayerEvent> _playerEventBinding;

    private void OnEnable()
    {
        _testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
        EventBus<TestEvent>.Register(_testEventBinding);
        
        _playerEventBinding = new EventBinding<PlayerEvent>(HandleEventBinding);
        EventBus<PlayerEvent>.Register(_playerEventBinding);
    }

    private void OnDisable()
    {
        EventBus<TestEvent>.Deregister(_testEventBinding);
        EventBus<PlayerEvent>.Deregister(_playerEventBinding);
    }

    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _manaComponent = GetComponent<ManaComponent>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            EventBus<TestEvent>.Raise(new TestEvent());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            EventBus<PlayerEvent>.Raise(new PlayerEvent
            {
                Health = _healthComponent.health,
                Mana = _manaComponent.mana
            });
        }
    }

    private void HandleEventBinding(PlayerEvent playerEvent)
    {
        Debug.Log($"Player Event Receive - Health: {playerEvent.Health} - Mana: {playerEvent.Mana}");
    }

    private void HandleTestEvent(TestEvent testEvent)
    {
        Debug.Log("Test Event Receive");
    }
}