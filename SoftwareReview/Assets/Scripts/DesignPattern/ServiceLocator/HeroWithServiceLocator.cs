using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityServiceLocator
{
    public class HeroWithServiceLocator : MonoBehaviour
    {
        private ILocalization _localization;
        private ISerializer _serializer;
        private IAudioService _audioService;
        private IGameService _gameService;

        [Title("Register Services")] 
        [SerializeField] List<Object> services;
        
        private void Awake()
        {
            ServiceLocator.Global.Register<ILocalization>(_localization = new MockLocalization());
            ServiceLocator.ForSceneOf(this).Register<IGameService>(_gameService = new MockGameService());
            ServiceLocator.For(this).Register<ISerializer>(_serializer = new MockSerializer());

            ServiceLocator sl = ServiceLocator.For(this);
            foreach (Object service in services)
            {
                sl.Register(service.GetType(), service);
            }
        }

        private void Start()
        {
            Debug.Log("*** Hero.Start ***");
            ServiceLocator.For(this)
                .Get(out _serializer)
                .Get(out _localization)
                .Get(out _gameService)
                .Get(out _audioService); // register from another object
            
            Debug.Log(_localization.GetLocalizedWord("dog"));
            _serializer.Serialize();
            _gameService.Start();
            _audioService.Play();
        }
    }
}