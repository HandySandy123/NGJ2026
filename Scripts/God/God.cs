using Godot;
using System;

public partial class God : Node2D
{
	private int orderIndex = 0;
	[Export]public bool ordering = false;
	[Export]Order order;
	[Export]SpeechBubble speechBubble;

	

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
	}
}
