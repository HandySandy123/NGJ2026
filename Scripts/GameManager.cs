using System;
using System.IO;
using Godot;
using NGJ2026.Scripts.Order.Components.Biome;
using NGJ2026.Scripts.Order.Components.Population;

namespace NGJ2026.Scripts;

public sealed partial class GameManager : Node2D
{
    public static GameManager Instance { get; private set; }
    
    public Vector2 MousePosition;
    public Random Random;
    [Export] PackedScene[] Scenes;
    public Node2D _activeScene;
    string[] SceneNames;
    public God activeGod { get; set; }
    public PlanetBuilder _planetBuilder;
    public int levelIdx;
    
    public override void _EnterTree()
    {
        
        Instance = this;
        
        Random =  new Random();
        
    }

    public override void _Ready()
    {
        _planetBuilder = PlanetBuilder.Instance;
        SceneNames = new string[Scenes.Length];
        for (int i = 0; i < Scenes.Length; i++)
        {
            SceneNames[i] = Scenes[i].ResourcePath;
            GD.Print("Scene Name: " + Scenes[i].ResourcePath);
        }
        //_activeScene = setScene(0);
    }

    public void AddBiome(Biome biome)
    {
        _planetBuilder.Biome = biome;
    }

    public void AddPopulation(Population population)
    {
        _planetBuilder.addPopulation(population);
    }

    public void AddGeographicalFeatures(GeographicalFeatures geographicalFeatures)
    {
        _planetBuilder.addGeographicalFeature(geographicalFeatures);
    }

    public Node2D setScene(int inx, bool delete = true, bool keepRunning = false)
    {
        if (inx < 0 || inx >= SceneNames.Length)
        {
            GD.Print("inx is out of range");
            return null;
        }
        if (delete)
        {
            _activeScene.QueueFree();
        } else if (keepRunning)
        {
            _activeScene.Visible = false;
        }
        else
        {
            RemoveChild(_activeScene);
        }
        var newScene = GD.Load<PackedScene>(SceneNames[inx]).Instantiate();
        AddChild(newScene);
        _activeScene = (Node2D)newScene;
        return _activeScene;
    }

    public override void _Process(double delta)
    {
        MousePosition = GetGlobalMousePosition();
    }

    
}