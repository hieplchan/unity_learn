using System;
using Cysharp.Threading.Tasks;

public interface ICommand
{
    UniTask Execute();
}