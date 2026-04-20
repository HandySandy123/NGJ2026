using Godot;
using System;

public partial class Bell : AnimatedSprite2D
{
	private bool ringing = true;
	private Timer timer;

	public void ring()
	{
		if (ringing) Play("Bell Ringing");
	}

	public void setRinging(bool value)
	{
		ringing = value;
	}
}
