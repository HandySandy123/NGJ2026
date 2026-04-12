using System;
using Godot;

namespace NGJ2026.Scripts.Order.Components.Population.Hot_Babes;

public partial class HotBabes : Population
{
	[Export] private Color[] HotBabesTops;
	[Export] private Color[] HotBabesBottoms;

	private Image img;
	// Called when the node enters the scene tree for the first time.
	public override void Spawn(int X, int Y)
	{
		img = Image.CreateEmpty(1, 2, false, Image.Format.Rgb8);
		var ColA = GameManager.Instance.Random.Next(HotBabesTops.Length);
		var ColB = GameManager.Instance.Random.Next(HotBabesBottoms.Length);
		CreateTexture(HotBabesTops[ColA], 0, 0);
		CreateTexture(HotBabesBottoms[ColB], 0, 1);
		Position = new Vector2(X, Y);
	}

	protected override void Hop()
	{
		throw new NotImplementedException();
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