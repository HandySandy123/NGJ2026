using Godot;
using System;

public partial class UiMain : PanelContainer
{
	[Export]public TextureButton icePlanet;
	[Export]public TextureButton waterPlanet;
	[Export]public TextureButton RockPlanet;
	[Export]public TextureButton duckPlanet;
	[Export]public TextureButton frogButt;
	[Export]public TextureButton hotBabesButt;
	[Export]public TextureButton robButt;
	[Export]public TextureButton ThoughtsRockButt;

	private TextureButton[] planets;
	private TextureButton[] PopulationButts;

	public override void _EnterTree()
	{
		planets = new TextureButton[4] {icePlanet,waterPlanet,RockPlanet,duckPlanet};
		PopulationButts = new TextureButton[4] {frogButt,hotBabesButt,robButt,ThoughtsRockButt};
	}
	
	public void ButtonPressed()
	{
		foreach(var pop in PopulationButts)
		{
			if (pop.ButtonPressed)
			{
				
			}
		}	
	}
}
