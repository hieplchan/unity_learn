using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AbilitySystem
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] public AbilityButton[] buttons;
        
        private readonly Key[] keys = { Key.Digit1, Key.Digit2, Key.Digit3, Key.Digit4, Key.Digit5 };

        private void Awake()
        {
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].Initialize(i, keys[i]);
        }

        public void UpdateRadial(float progress)
        {
            Array.ForEach(buttons, button => button.UpdateRadialFill(progress));
        }

        public void UpdateButtonSprites(IList<Ability> abilities)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(i < abilities.Count);

                if (i < abilities.Count)
                    buttons[i].UpdateButtonSprite(abilities[i].data.icon);
            }
        }
    }
}