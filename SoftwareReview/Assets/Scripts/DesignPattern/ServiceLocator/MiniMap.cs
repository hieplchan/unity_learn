using System;
using UnityEngine;

namespace ServiceLocator
{
    public class MiniMap : MonoBehaviour
    {
        private IAudioService _audioService;
        private IGameService _gameService;

        private void Awake()
        {
            ServiceLocator.Global.Register<IAudioService>(_audioService = new MockAudioService());
            ServiceLocator.ForSceneOf(this).Register<IGameService>(_gameService = new MockGameService());
        }

        private void Start()
        {
            Debug.Log("*** MiniMap.Start ***");
            ServiceLocator.For(this)
                .Get(out _audioService)
                .Get(out _gameService);
            
            _audioService.Play();
            _gameService.Start();
        }
    }
}