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
    [Export] private PackedScene _activePopulation;
    static readonly Random random = new Random();
    public override void _Ready()
    {
        
    }

    public void requestPopulation(string name)
    {
        
    }

    // public void setPopulation(Node population)
    // {
    //     _activePopulation = population;
    // }

    public override void _Process(double delta)
    {
        center = GameManager.Instance.MousePosition;
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
                case "HotBabes":
                    node = (HotBabes) node;
                    break;
            }
            
            AddSibling(node);
            if (node != null) node.Spawn(X, Y);
        }
        
    }
}