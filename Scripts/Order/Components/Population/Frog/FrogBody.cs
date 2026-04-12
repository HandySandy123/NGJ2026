using Godot;

namespace NGJ2026.Scripts.Order.Components.Population;

public partial class FrogBody : CharacterBody2D
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