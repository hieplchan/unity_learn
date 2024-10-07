using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

public class CommandManager : SerializedMonoBehaviour
{
    public IEntity Entity;
    public ICommand SingleCommand;
    public List<ICommand> Commands;
 
    readonly CommandInvoker _commandInvoker = new ();

    private void Start()
    {
        Entity = GetComponent<IEntity>();
        SingleCommand = HeroCommand.Create<AttackCommand>(Entity);

        Commands = new List<ICommand>()
        {
            HeroCommand.Create<AttackCommand>(Entity),
            HeroCommand.Create<SpinCommand>(Entity),
            HeroCommand.Create<JumpCommand>(Entity)
        };
    }

    async UniTask ExecuteCommand(List<ICommand> commands)
    {
        await _commandInvoker.ExecuteCommand(commands);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ExecuteCommand(new List<ICommand> { SingleCommand });
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ExecuteCommand(Commands);
        }
    }
}

public class CommandInvoker
{
    public async UniTask ExecuteCommand(List<ICommand> commands)
    {
        foreach (var command in commands)
        {
            await command.Execute();
        }
    }
}