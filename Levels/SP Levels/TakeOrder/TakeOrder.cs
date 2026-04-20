using Godot;
using System;
using NGJ2026.Scripts;

public partial class TakeOrder : Node2D
{
	[Export]NGJ2026.Fridays_Scenes.OrbArrow orbArrow;
	[Export] private Node2D godSpot;
	[Export] private PackedScene[] Gods;
	private God chosenGod;
	private int sceneIndex;

	
	public void showGod()
	{
		chosenGod.Visible = true;
		chosenGod.revealGod();
	}
	private void chooseGod()
	{
		var ind = GameManager.Instance.Random.Next(Gods.Length);
		var instance = Gods[ind].Instantiate();
		GD.Print(instance.Name + " selected");
		chosenGod = (God)instance;
		AddChild(chosenGod);
		chosenGod.Position = godSpot.Position;
	}

	public override void _EnterTree()
	{
		chooseGod();
		//orbArrow.showGod += showGod;
		chosenGod.doneOrdering += orbArrow.setArrow;
		sceneIndex = 1;
	}

	public override void _ExitTree()
	{
		//orbArrow.showGod -= showGod;
		chosenGod.doneOrdering -= orbArrow.setArrow;
	}
}
