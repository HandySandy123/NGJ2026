using System;
using Godot;

namespace NGJ2026.Scripts.Order.Components.Population.Robot;

public partial class Robot : Population
{
	[Export] private Color[] robotColors;
	[Export] private RobotBody Body;
	private Image img;
	// Called when the node enters the scene tree for the first time.
	public override void Spawn(float X, float Y)
	{
		img = Image.CreateEmpty(1, 2, false, Image.Format.Rgb8);
		var Col = robotColors[GameManager.Instance.Random.Next(robotColors.Length)];
		for (int i = 0; i < img.GetWidth() * img.GetHeight(); i++)
		{
			CreateTexture(Col, 0, i);
		}

		sprite.Texture = ImageTexture.CreateFromImage(img);
		GlobalPosition = new Vector2(X, Y);
	}

	protected override void Hop()
	{
		var X = (float)GameManager.Instance.Random.Next(-10, 10)/10 * hopForce;
		var Y =(float) -GameManager.Instance.Random.NextDouble() * hopForce;
		var vector = new Vector2(X, Y);
		//GD.Print(vector);
		if(Body != null)
		{
			//GD.Print("hopping");
			Body.velocity += vector;
		}
	}

	public override void _EnterTree()
	{
	}

	protected override void CreateTexture(Color color, int X, int Y)
	{
		img.SetPixel(X, Y, color);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}