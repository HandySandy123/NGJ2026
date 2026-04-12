using Godot;
using System;
using NGJ2026.Scripts.Order.Components.Population;

public partial class PopulationManager : Node
{
	private PackedScene[] _populations;

	public PopulationManager(PackedScene[] populations)
	{
		_populations = new PackedScene[populations.Length];
		for (int i = 0; i < _populations.Length; i++)
		{
			var p = GD.Load<PackedScene>(populations[i].GetPath());
			var instP = p.Instantiate();
			if (instP is Population pop)
			{
				_populations[i] = p;
			}
		}

		foreach (var p in _populations)
		{
			var pop = p.Instantiate();
			GD.Print(pop.Name + " added");
		}
	}

	public Population getPopulation(string name)
	{
		for (int i = 0; i < _populations.Length; i++)
		{
			var pop = _populations[i].Instantiate();
			AddChild(pop);
			if (pop is Population popu)
			{
				if(popu.PopName == name) {
					GD.Print(popu.PopName + " added to population");
					return popu;
				}
			}
		}
		return null;
	}
}
