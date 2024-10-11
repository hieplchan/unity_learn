using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DesignPattern.Memento
{
    public class LoadoutManager : MonoBehaviour
    {
        [SerializeField, Required] private HotBar _hotBar;
        [SerializeField] private Button[] _loadoutButtons;
        [SerializeField] private Button _saveButton;

        private readonly HotBar.Memento[] _loadoutMementoes = new HotBar.Memento[3];
        private int selectedLoadout = 0;

        private void Start()
        {
            for (int i = 0; i < _loadoutMementoes.Length; i++)
            {
                _loadoutMementoes[i] = _hotBar.CreateMemento();
                var index = i;
                _loadoutButtons[i].onClick.AddListener(() => SelecteLoadout(index));
            }
            
            _saveButton.onClick.AddListener(SaveLoadout);

            AdjustButtonColor();
        }
        
        private void SelecteLoadout(int index)
        {
            SaveLoadout();
            
            selectedLoadout = index;
            _hotBar.SetMemento(_loadoutMementoes[index]);

            AdjustButtonColor();
        }

        private void SaveLoadout()
        {
            _loadoutMementoes[selectedLoadout] = _hotBar.CreateMemento();
        }

        void AdjustButtonColor()
        {
            for (int i = 0; i < _loadoutButtons.Length; i++)
            {
                _loadoutButtons[i].interactable = selectedLoadout != i;
            }
        }
    }
}