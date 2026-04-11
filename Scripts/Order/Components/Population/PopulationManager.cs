using Godot;
using System;
using NGJ2026.Scripts.Order.Components.Population;

public partial class PopulationManager : Node
{
	[Export] private PackedScene[] _populations;

	public PopulationManager(PackedScene[] populations)
	{
		_populations = populations;
		foreach (var population in populations) GD.Print(population.GetPath());
	}

	public Population getPopulation(string name)
	{
		for (int i = 0; i < _populations.Length; i++)
		{
			PackedScene pop = GD.Load<PackedScene>(_populations[i].GetPath());
			if (pop.CanInstantiate())
			{
				var population = pop.Instantiate();
				if(population.GetType() == typeof(Population))
				{
					var popu = population as Population;
					if(popu != null && popu.PopName.Equals(name))
					{
						return popu;
					}
				}

				if (population.Name == name) return (Population)population;
				else
				{
					population.QueueFree();
				}
			}
			pop.Free();
		}
		return null;
	}
}
