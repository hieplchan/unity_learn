using System;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPattern.Strategy
{
    public class CastSpellView : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;

        public delegate void ButtonPressedEvent(int index);

        public static event ButtonPressedEvent OnButtonPressed;

        private void Awake()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                int index = i;
                _buttons[i].onClick.AddListener(() => HandleButtonPress(index));
            }
        }

        private void HandleButtonPress(int index) => OnButtonPressed?.Invoke(index);
    }
}