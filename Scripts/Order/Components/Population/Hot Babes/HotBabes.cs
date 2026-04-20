using System;
using Godot;

namespace NGJ2026.Scripts.Order.Components.Population.Hot_Babes;

public partial class HotBabes : Population
{
	[Export] private Color[] HotBabesTops;
	[Export] private Color[] HotBabesBottoms;
	[Export] private HotBabesBody body;
	private Image img;
	// Called when the node enters the scene tree for the first time.
	public override void Spawn(float X, float Y)
	{
		img = Image.CreateEmpty(1, 2, false, Image.Format.Rgb8);
		var ColA = GameManager.Instance.Random.Next(HotBabesTops.Length);
		var ColB = GameManager.Instance.Random.Next(HotBabesBottoms.Length);
		CreateTexture(HotBabesTops[ColA], 0, 0);
		CreateTexture(HotBabesBottoms[ColB], 0, 1);
		GlobalPosition = new Vector2(X, Y);
	}

	protected override void Hop()
	{
		var left = GameManager.Instance.Random.NextDouble();
		var yStrenght = -40f;
		if (left < 0.5)
		{
			body.Velocity += new Vector2(hopForce, yStrenght);
		}
		else
		{
			body.Velocity += new Vector2(-hopForce, yStrenght);
		}
		GD.Print("Babe Hop");
	}

	public override void _EnterTree()
	{
		//GD.Print("Hot babe added");
	}

	protected override void CreateTexture(Color color, int X, int Y)
	{
		img.SetPixel(X, Y, color);
		sprite.Texture = ImageTexture.CreateFromImage(img);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}