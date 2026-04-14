using System;
using Godot;
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
    private Population _activePopulation;
    static readonly Random random = new Random();

    public override void _EnterTree()
    {
        GameManager.Instance._populationBrush = this;
    }

    public void setPopulation(Population population)
    {
        _activePopulation = population;
    }

    public void onTimerTimeout()
    {
        center = GameManager.Instance.MousePosition;
        Position = center;
        if (Input.IsActionPressed("OnClick") && _activePopulation != null)
        {
            //GD.Print("OnClick");
            // int angle = random.Next(360); 
            // var X = Mathf.FloorToInt(center.X + radius * Mathf.Cos(angle));
            // var Y = Mathf.FloorToInt(center.Y + radius * Mathf.Sin(angle));
            var node = (Population)_activePopulation.Duplicate();
            // switch (_activePopulation.PopName)
            // {
            //     case "Frogs": 
            //         node = (Frogs) node;
            //         break;
            //     case "Hot Babes":
            //         node = (HotBabes) node;
            //         break;
            //     case "Robot":
            //         node = (Robot)node;
            //         break;
            // }
            //
            AddSibling(node);
            GD.Print("Added " + node.PopName);
            node.Spawn(Mathf.CeilToInt(Position.X), Mathf.CeilToInt(Position.Y));
        }
    }

    public override void _Process(double delta)
    {
        
        
    }
}