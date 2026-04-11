using Godot;
using System;
using NGJ2026.Scripts.Order.Components;

public partial class DeathArea : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void on_body_entered(Node2D body)
	{
		if (body.GetTree().Root.GetType() == typeof(Component))
		{
			GD.Print(body.Name + "Is dead");
			body.QueueFree();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
