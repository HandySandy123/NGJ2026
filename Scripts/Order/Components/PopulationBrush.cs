using Godot;
using NGJ2026.Scripts;

namespace NGJ2026.Scripts.Order.Components;

public partial class ComponentsBrush : Node2D
{
    private float radius = 3;
    private float density = 0.3f;
    [Export] private int resolution = 10;
    private Vector2 center;
    private GameManager gameManager;
    private Component _activeComponent;

    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("/root/GameManager");
    }

    public override void _Process(double delta)
    {
        gameManager = GetNode<GameManager>("/root/GameManager");
        center = gameManager.MousePosition;
        if (Input.IsActionPressed("OnClick"))
        {
            GD.Print("OnClick");
        }
        
    }
}