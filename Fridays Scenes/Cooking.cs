using Godot;
using System;

public partial class Cooking : AnimatedSprite2D
{
	[Export]private Timer CookingTimer;  
	private void StartTimer() {
		CookingTimer.Start();
	}
	 public void CookingUniverse (bool val){
		Visible = val;
		Play("Microwave Cooking");
	}
	private void UniverseCooked(bool val){
		Visible = val;
	}
}
