using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

[RequireComponent(typeof(HealthComponent), typeof(ManaComponent))]
public class HeroWithVisitor : MonoBehaviour, IVisitable
{
    [ShowInInspector] private List<IVisitable> _visitableComponents = new List<IVisitable>();

    private void Start()
    {
        _visitableComponents.Add(GetComponent<HealthComponent>());
        _visitableComponents.Add(GetComponent<ManaComponent>());
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var component in _visitableComponents)
        {
            component.Accept(visitor);
        }
    }
}