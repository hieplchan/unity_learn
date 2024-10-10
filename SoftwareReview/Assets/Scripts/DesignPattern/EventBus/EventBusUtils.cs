using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class EventBusUtils
{
    public static IReadOnlyList<Type> EventTypes { get; set; }
    public static IReadOnlyList<Type> EventBusTypes { get; set; }
    
    #if UNITY_EDITOR
    public static PlayModeStateChange PlayModeState { get; set; }

    [InitializeOnLoadMethod]
    public static void InitializeEditor()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        PlayModeState = state;
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            ClearAllBus();
        }
    }
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        EventTypes = PredefinedAssemblyUtils.GetTypes(typeof(IEvent));
        EventBusTypes = InitializeAllBus();
    }

    private static List<Type> InitializeAllBus()
    {
        List<Type> eventBusTypes = new List<Type>();

        var typedef = typeof(EventBus<>);
        foreach (var eventType in EventTypes)
        {
            var busType = typedef.MakeGenericType(eventType);
            eventBusTypes.Add(busType);
            Debug.Log($"Initialized EventBus<{eventType.Name}>");
        }

        return eventBusTypes;
    }

    public static void ClearAllBus()
    {
        Debug.Log("Clearing all bus...");
        for (int i = 0; i < EventBusTypes.Count; i++)
        {
            var busType = EventBusTypes[i];
            var clearMethod = busType.GetMethod("Clear",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            clearMethod.Invoke(null, null);
        }
    }
}