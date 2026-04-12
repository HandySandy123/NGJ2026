using Godot;
using System;
using System.Collections.Generic;
using NGJ2026.Scripts.Order.Components.Biome;
using NGJ2026.Scripts.Order.Components.Population;

public partial class PlanetBuilder : Node2D
{
	private Biome _biome;
	private List<GeographicalFeatures> _geographicalFeatures;
	private List<Population> _population;

	public Biome Biome
	{
		get => _biome;
		set => _biome = value;
	}

	public List<GeographicalFeatures> GeographicalFeatures
	{
		get => _geographicalFeatures; 
	}

	public void addGeographicalFeature(GeographicalFeatures geographicalFeatures)
	{
		_geographicalFeatures.Add(geographicalFeatures);
	}

	public List<Population> Population
	{
		get => _population;
	}

	public void addPopulation(Population population)
	{
		_population.Add(population);
	}
}
