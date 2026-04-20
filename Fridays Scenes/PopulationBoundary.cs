using Godot;

namespace NGJ2026.Fridays_Scenes;

public partial class PopulationBoundary : Area2D
{
	private void enterBody(Node body)
	{
		GD.Print("Killing Body");
		body.QueueFree();
	}
}