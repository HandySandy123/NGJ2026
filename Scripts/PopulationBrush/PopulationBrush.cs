using System;
using Godot;
using NGJ2026.Scripts.Order.Components.Population;

namespace NGJ2026.Scripts.PopulationBrush;

public partial class PopulationBrush : Node2D
{
    [Export] private float radius = 3;
    private float density = 0.3f;
    [Export] private int resolution = 10;
    private Vector2 center;
    private GameManager gameManager;
    [Export] private PackedScene _activePopulation;
    static readonly Random random = new Random();
    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("/root/GameManager");
        if(gameManager == null) GD.Print("Err: no GameManager");
        _activePopulation = GD.Load<PackedScene>("res://Scripts/Order/Components/Population/Frog.tscn");
    }

    // public void setPopulation(Node population)
    // {
    //     _activePopulation = population;
    // }

    public override void _Process(double delta)
    {
        gameManager = GetNode<GameManager>("/root/GameManager");
        center = gameManager.MousePosition;
        Position = center;
        if (Input.IsActionPressed("OnClick"))
        {
            //GD.Print("OnClick");
            int angle = random.Next(360); 
            var X = Mathf.FloorToInt(center.X + radius * Mathf.Cos(angle));
            var Y = Mathf.FloorToInt(center.Y + radius * Mathf.Sin(angle));
            var node = _activePopulation.Instantiate() as Population;
            switch (_activePopulation.GetType().FullName)
            {
                case "Frogs": 
                    node = (Frogs) node;
                    break;
                
            }
            
            AddSibling(node);
            if (node != null) node.Spawn(X, Y);
        }
        
    }
}