using Godot;
using NGJ2026.Scripts;

namespace NGJ2026;

public partial class UiMain : PanelContainer
{
	public void iceWorld()
	{
		
	}

	public void waterWorld()
	{
		
	}

	public void rockWorld()
	{
		
	}

	public void duckWorld()
	{
		
	}

	public void frogs()
	{
		GD.Print("Finding frogs");
		var frogs = GameManager.Instance._requestPopulation("Frog");
		if (frogs != null)
		{
			GameManager.Instance.setActivePopulation(frogs);
			GD.Print("Brush ready with frogs");
		}
	}

	public void hotBabes()
	{
		GD.Print("Finding hot babes");
		var babes = GameManager.Instance._requestPopulation("Hot Babe");
		if (babes != null)
		{
			GameManager.Instance.setActivePopulation(babes);
			GD.Print("Brush ready with hot babes");
		}
	}

	public void Robots()
	{
		GD.Print("Finding robots");
		var robot = GameManager.Instance._requestPopulation("Robot");
		if (robot != null)
		{
			GameManager.Instance.setActivePopulation(robot);
			GD.Print("Brush ready with robot");
		}
		else
		{
			GD.Print("Robot not found");
		}
	}

	public void thoughtfulRock()
	{
		
	}
}
