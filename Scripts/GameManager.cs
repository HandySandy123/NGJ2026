using System;
using Godot;
using NGJ2026.Scripts.Order.Components;
using NGJ2026.Scripts.Order.Components.Population;

namespace NGJ2026.Scripts;

public sealed partial class GameManager : Node2D
{
    public static GameManager Instance { get; private set; }
    PopulationManager _populationManager;
    [Export]PackedScene[] _populations;
    public Vector2 MousePosition;
    public Random Random;

    public override void _EnterTree()
    {
        Instance = this;
        _populationManager = new PopulationManager(_populations);
        AddChild(_populationManager);
        Random =  new Random();
    }

    public override void _Process(double delta)
    {
        MousePosition = GetGlobalMousePosition();
    }
}