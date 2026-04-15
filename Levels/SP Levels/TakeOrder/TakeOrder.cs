using Godot;
using System;
using NGJ2026.Scripts;

public partial class TakeOrder : Node2D
{
	[Export]OrbArrow orbArrow;
	[Export] private Node2D godSpot;
	[Export] private PackedScene[] Gods;
	private God chosenGod;

	
	public void showGod()
	{
		chosenGod.Visible = true;
		chosenGod.ordering = true;
	}
	private void chooseGod()
	{
		var ind = GameManager.Instance.Random.Next(Gods.Length);
		GD.Print(ind);
		var instance = Gods[ind].Instantiate();
		GD.Print(instance.Name + " selected");
		chosenGod = (God)instance;
		AddChild(chosenGod);
	}

	public void takeOrder()
	{
		chosenGod.ordering = true;
	}

	public override void _EnterTree()
	{
		chooseGod();
		orbArrow.showGod += showGod;
		chosenGod.doneOrdering += orbArrow.setArrow;
	}

	public override void _ExitTree()
	{
		orbArrow.showGod -= showGod;
		chosenGod.doneOrdering -= orbArrow.setArrow;

	}

	public override void _Process(double delta)
	{
		
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		chosenGod.Visible = false;
		chosenGod.Position = godSpot.Position;
	}
}
