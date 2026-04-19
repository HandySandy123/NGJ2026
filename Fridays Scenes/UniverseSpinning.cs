using Godot;
using System;

public partial class UniverseSpinning : AnimatedSprite2D
{
	private void RevealUniverse(bool val){
		Visible = val;
		Play("Universe Spinning");
	}
	
}
