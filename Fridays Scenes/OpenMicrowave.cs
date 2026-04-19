using Godot;
using System;

public partial class OpenMicrowave : Sprite2D
{
	public void closeMicrowave(bool val){
		Visible = val; 
	}
private void openMicrowave(bool val){
	Visible = val; 
	}
}
