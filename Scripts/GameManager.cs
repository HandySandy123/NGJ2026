using System;
using Godot;
using NGJ2026.Scripts.Order.Components;

namespace NGJ2026.Scripts;

public sealed partial class GameManager : Node2D
{
    public static GameManager Instance { get; private set; }
    public Vector2 MousePosition;
    public Random Random;
    [Export] public Grid.Grid Grid;

    public override void _EnterTree()
    {
        Instance = this;
        Random =  new Random();
    }

    public override void _Process(double delta)
    {
        MousePosition = GetGlobalMousePosition();
    }
}