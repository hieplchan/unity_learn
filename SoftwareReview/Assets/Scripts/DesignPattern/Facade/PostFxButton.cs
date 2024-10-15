using Sirenix.OdinInspector;
using UnityEngine;

namespace DesignPattern.Facade
{
    public class PostFxButton : MonoBehaviour
    {
        private readonly Color green = new Color(0.2f, 1f, 0f);

        [Button(ButtonSizes.Large), GUIColor("green")]
        void SetupHorror()
        {
            PostFxFacade.instance.SetupHorror();
        }
        
        [Button(ButtonSizes.Large), GUIColor("green")]
        void SetupCinematic()
        {
            PostFxFacade.instance.SetupCinematic();
        }
        
        [Button(ButtonSizes.Large), GUIColor("green")]
        void SetupArtistic()
        {
            PostFxFacade.instance.SetupArtistic();
        }
    }
}