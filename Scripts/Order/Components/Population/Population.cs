using Godot;

namespace NGJ2026.Scripts.Order.Components.Population;

public abstract partial class Population : Component
{
   
    public abstract void Spawn(float X, float Y);
    protected abstract void Hop();
    [Export]protected Sprite2D sprite;
    [Export]protected float hopTime = 0.5f;
    [Export] protected float hopForce = 5;
    [Export] public string PopName;
    protected abstract void CreateTexture(Color color, int X, int Y);
}