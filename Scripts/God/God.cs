using Godot;
using System;

public partial class God : Node2D
{
	private int orderIndex = 0;
	public bool ordering = false;
	public Action<bool> doneOrdering;
	public AnimationPlayer animationPlayer;
	[Export]Order order;
	[Export]SpeechBubble speechBubble;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public void setOrdering(StringName name, bool value)
	{
		ordering = value;
		GD.Print("ordering " + order);
		if (ordering)
		{
			speechBubble.Visible = true;
			GD.Print("Showing bubs");
		}
	}
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("OnClick") && ordering && orderIndex < order.GetOrderLength())
		{
			var line = order.getLine(orderIndex);
			if (!speechBubble.Visible)
			{
				speechBubble.Show();
			}
			orderIndex++;
			speechBubble.setLabelText(line);
		}

		if (orderIndex >= order.GetOrderLength())
		{
			doneOrdering.Invoke(true);
		}
	}

	public void revealGod()
	{
		animationPlayer.Play("Universaria/GodDecending");
		
	}
}