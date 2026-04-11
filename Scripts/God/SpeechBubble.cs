using Godot;
using System;

public partial class SpeechBubble : Sprite2D
{
	[Export] private Label label;

	public void setLabelText(string text)
	{
		label.Text = text;
	}
}
