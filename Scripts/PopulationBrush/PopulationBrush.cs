using System;
using Godot;
using NGJ2026.Scripts.Order.Components.Biome;
using NGJ2026.Scripts.Order.Components.Population;
using NGJ2026.Scripts.Order.Components.Population.Hot_Babes;
using NGJ2026.Scripts.Order.Components.Population.Robot;
using Frogs = NGJ2026.Scripts.Order.Components.Population.Frog.Frogs;

namespace NGJ2026.Scripts.PopulationBrush;

public partial class PopulationBrush : Node2D
{
    [Export] private float radius = 2;
    private float density = 0.3f;
    [Export] private int resolution = 10;
    private Vector2 center;
    [Export] private PackedScene[] _populations;
    private PackedScene _activePopulation;
    [Export] private PackedScene thoughtfulRocks;
    Timer timer;
    static readonly Random random = new Random();
    private bool canDraw = false;

    public void setPopulation(int population)
    {
        _activePopulation = GD.Load<PackedScene>(_populations[population].ResourcePath);
    }

    public override void _Ready()
    {
        timer = (Timer)GetNode("Timer");
        if(timer != null) GD.Print("Timer found");
    }

    public void CanDraw(bool val)
    {
        canDraw = val;
    }

    public override void _Process(double delta)
    {
        Position = GetGlobalMousePosition();
    }

    public void onTimerTimeout()
    {
        center = GameManager.Instance.MousePosition;
        Position = center;
        if (Input.IsActionPressed("OnClick") && _activePopulation != null && canDraw)
        {
            var pop = (Node2D)_activePopulation.Instantiate();
            // if (_activePopulation.ResourcePath == thoughtfulRocks.ResourcePath)
            // {
            //     timer.WaitTime = 10;
            // }
            // else
            // {
            //     timer.WaitTime = 0.1f;
            // }
            if (pop is Population population)
            {
                PlanetBuilder.Instance.addPopulation(population);
                AddSibling(population);
                var r = (float)radius * Mathf.Sqrt(GameManager.Instance.Random.NextDouble()) ;
                var theta = (float)GameManager.Instance.Random.NextDouble() * 2 * Mathf.Pi;
                population.Spawn((float)(Position.X + r * Mathf.Cos(theta)), 
                                 (float)(Position.Y + r * Mathf.Sin(theta)));
            }
            
        }
    }
}