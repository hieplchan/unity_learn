using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace ServiceLocator
{
    public interface ILocalization
    {
        string GetLocalizedWord(string key);
    }

    public class MockLocalization : ILocalization
    {
        private readonly List<string> _words = new List<string> {"One", "Two", "Three", "Four", "Five"};
        private readonly Random _random = new Random();
        
        public string GetLocalizedWord(string key)
        {
            return _words[_random.Next(_words.Count)];
        }
    }

    public interface ISerializer
    {
        void Serialize();
    }
    
    public class MockSerializer : ISerializer
    {
        public void Serialize()
        {
            Debug.Log("MockSerializer.Serialize");
        }
    }

    public interface IAudioService
    {
        void Play();
    }

    public class MockAudioService : IAudioService
    {
        public void Play()
        {
            Debug.Log("MockAudioService.Play");
        }
    }

    public interface IGameService
    {
        void Start();
    }

    public class MockGameService : IGameService
    {
        public void Start()
        {
            Debug.Log("MockGameService.Play");
        }
    }
}