using Godot;
using System;
using NGJ2026.Scripts;

public partial class Title : Node2D
{
	[Export] AnimationPlayer TitleAnimationPlayer, TitleBackdropAnimationPlayer;
	[Export] int sceneIndex = 0;
	public override void _Ready()
	{
		
	}

	public override void _EnterTree()
	{
		GameManager.Instance._activeScene = this;
	}

	public void StartGame()
	{
		GameManager.Instance.setScene(sceneIndex+1);
	}
}
