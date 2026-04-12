using Godot;
using System;

public partial class HotBabesBody : CharacterBody2D
{
	public Vector2 velocity;
	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
