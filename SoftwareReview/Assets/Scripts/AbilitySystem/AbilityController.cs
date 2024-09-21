using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Utils;

namespace AbilitySystem
{
    public class AbilityController
    {
        private readonly AbilityModel model;
        private readonly AbilityView view;
        private readonly Queue<AbilityCommand> abilityQueue = new ();
        private readonly CountdownTimer timer = new CountdownTimer(0);

        public AbilityController(AbilityModel model, AbilityView view)
        {
            this.model = model;
            this.view = view;

            ConnectModel();
            ConnectView();
        }

        public void Update(float deltaTime)
        {
            timer.Tick(deltaTime);
            view.UpdateRadial(timer.Progress);

            if (!timer.IsRunning && abilityQueue.TryDequeue(out AbilityCommand command))
            {
                command.Execute();
                timer.Reset(command.duration);
                timer.Start();
            }
        }
        
        private void ConnectView()
        {
            for (int i = 0; i < view.buttons.Length; i++)
            {
                view.buttons[i].RegisterListener(OnAbilityButtonPressed);
            }
            view.UpdateButtonSprites(model.abilities);
        }

        private void OnAbilityButtonPressed(int index)
        {
            if (timer.Progress < 0.25f || !timer.IsRunning)
            {
                if (model.abilities[index] != null)
                {
                    abilityQueue.Enqueue(model.abilities[index].CreateAbilityCommand());
                }
            }
            
            EventSystem.current.SetSelectedGameObject(null);
        }

        private void ConnectModel()
        {
            model.abilities.AnyValueChanged += UpdateButtons;
        }

        private void UpdateButtons(IList<Ability> updatedAbilities) => view.UpdateButtonSprites(updatedAbilities);

        public class Builder
        {
            private readonly AbilityModel model = new AbilityModel();

            public Builder WithAbility(AbilityData[] datas)
            {
                foreach (var data in datas)
                {
                    model.Add(new Ability(data));
                }

                return this;
            }

            public AbilityController Build(AbilityView view)
            {
                Preconditions.CheckNotNull(view);
                return new AbilityController(model, view);
            }
        }
    }
}