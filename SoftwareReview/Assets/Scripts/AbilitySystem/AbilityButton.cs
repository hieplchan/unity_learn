using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace AbilitySystem
{
    public class AbilityButton : MonoBehaviour
    {
        public Image radialImage;
        public Image abitityIcon;
        public int index;
        public Key key;

        public event Action<int> OnButtonPressed = delegate { };

        public void Initialize(int index, Key key)
        {
            this.index = index;
            this.key = key;
        }
        
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => OnButtonPressed(index));
        }

        private void Update()
        {
            if (Keyboard.current[key].wasPressedThisFrame)
            {
                OnButtonPressed(index);
            }
        }

        public void RegisterListener(Action<int> listener)
        {
            OnButtonPressed += listener;
        }

        public void UpdateButtonSprite(Sprite newIcon)
        {
            abitityIcon.sprite = newIcon;
        }

        public void UpdateRadialFill(float progress)
        {
            if (radialImage) 
                radialImage.fillAmount = progress;
        }
    }
}