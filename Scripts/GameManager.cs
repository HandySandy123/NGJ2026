using System;
using System.IO;
using Godot;
using NGJ2026.Scripts.Order.Components.Population;

namespace NGJ2026.Scripts;

public sealed partial class GameManager : Node2D
{
    public static GameManager Instance { get; private set; }
    PopulationManager _populationManager;
    [Export]PackedScene[] _populations;
    [Export] public PopulationBrush.PopulationBrush _populationBrush;
    public Vector2 MousePosition;
    public Random Random;
    [Export] Node2D[] worlds;
    [Export] PackedScene[] Scenes;
    Node2D _activeScene;
    string[] SceneNames;
    public God activeGod { get; set; }

    public enum SceneInd
    {
        TakeOrder,
        ChooseWorld,
        Population,
        PhysicsObject,
        CookWorld,
        Review
    }
    
    public override void _EnterTree()
    {
        Instance = this;
        _populationManager = new PopulationManager(_populations);
        AddChild(_populationManager);
        Random =  new Random();
        makeWorldsInvisible();
        SceneNames = new string[Scenes.Length];
        for (int i = 0; i < Scenes.Length; i++)
        {
            SceneNames[i] = Scenes[i].ResourceName;
        }
    }

    private void makeWorldsInvisible()
    {
        foreach (var world in worlds)
        {
            world.Visible = false;
        }
    }

    public void setScene(int inx, bool delete = true, bool keepRunning = false)
    {
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
    }

    public void showWorld(int worldIndex)
    {
        makeWorldsInvisible();
        worlds[worldIndex].Visible = true;
    }

    public override void _Process(double delta)
    {
        MousePosition = GetGlobalMousePosition();
    }

    public void setActivePopulation(Population population)
    {
        _populationBrush.setPopulation(population);
    }

    public Population _requestPopulation(string name)
    {
        if (_populationManager.getPopulation(name) != null)
        {
            GD.Print("Population of " + name + " found");
            return _populationManager.getPopulation(name);
        }
        else
        {
            GD.Print("No population found");
            return null;
        }
    }
}