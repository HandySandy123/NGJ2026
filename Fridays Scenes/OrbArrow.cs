using System;
using Godot;
using NGJ2026.Scripts;

namespace NGJ2026.Fridays_Scenes;

public partial class OrbArrow : PanelContainer
{
	[Export] private TextureButton orb, arrow;
	//public Action showGod;
	public Action<int> switchingLevels;
	public bool showingGod = false;

	public override void _Ready()
	{
		//arrow.Visible = false;
	}

	public void setOrb(bool on)
	{
		orb.Visible = on;
	}

	// public void activateGod()
	// {
	// 	showGod.Invoke();
	// }

	private void nextLevel(int index)
	{
		GameManager.Instance.setScene(index);
	}

	public void setArrow(bool on)
	{
		arrow.Visible = on;
	}
}