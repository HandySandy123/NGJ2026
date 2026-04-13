using Godot;
using System;

public partial class OrbArrow : PanelContainer
{
	[Export] private TextureButton orb, arrow;
	public Action showGod;
	public bool showingGod = false;

	public override void _Ready()
	{
		arrow.Visible = false;
	}

	public void setOrb(bool on)
	{
		orb.Visible = on;
	}

	public void activateGod()
	{
		showGod.Invoke();
	}

	public void setArrow(bool on)
	{
		arrow.Visible = on;
	}
}
