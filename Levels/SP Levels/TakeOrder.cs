using Godot;
using System;
using NGJ2026.Scripts;

public partial class TakeOrder : Node2D
{
	private God _activeGod;
	[Export]OrbArrow orbArrow;
	[Export] private Node2D godSpot;
	
	public void showGod()
	{
		_activeGod.Visible = true;
		_activeGod.ordering = true;
	}

	public void takeOrder()
	{
		_activeGod.ordering = true;
	}

	public override void _EnterTree()
	{
		orbArrow.showGod += showGod;
		_activeGod.doneOrdering += orbArrow.setArrow;
	}

	public override void _ExitTree()
	{
		orbArrow.showGod -= showGod;
		_activeGod.doneOrdering -= orbArrow.setArrow;

	}

	public override void _Process(double delta)
	{
		
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_activeGod = GameManager.Instance.activeGod;
		AddChild(_activeGod);
		_activeGod.Visible = false;
		_activeGod.Position = godSpot.Position;
	}
}
