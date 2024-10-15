using System;
using UnityEngine;
using UnityEngine.Rendering;
using Utils;

namespace DesignPattern.Facade
{
    public class PostFxFacade : MonoSingleton<PostFxFacade>
    {
        private Volume _postFxVolume;

        private void Start()
        {
            InitPostProcessing();
        }

        public void SetupHorror()
        {
            _postFxVolume.LoadVolumeProfile("VolumeProfiles/PostFxHorror");
        }

        public void SetupCinematic()
        {
            _postFxVolume.LoadVolumeProfile("VolumeProfiles/PostFxCinematic");
        }

        public void SetupArtistic()
        {
            _postFxVolume.LoadVolumeProfile("VolumeProfiles/PostFxArtistic");
        }
        
        private void InitPostProcessing()
        {
            var go = new GameObject("PostFxVolume");
            _postFxVolume = go.AddComponent<Volume>();
        }
    }
}