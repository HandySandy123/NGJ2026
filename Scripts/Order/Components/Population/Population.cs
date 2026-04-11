using Godot;

namespace NGJ2026.Scripts.Order.Components.Population;

public abstract partial class Population : Component
{
    public abstract void Spawn(int X, int Y);
    protected abstract void Hop();
    [Export]protected Sprite2D sprite;
    [Export]protected float hopTime = 0.5f;
    [Export] protected float hopForce = 5;

    public override void _Ready()
    {
        
    }

    protected void CreateTexture(Color color)
    {
        var img = Image.CreateEmpty(1, 1, false, Image.Format.Rgb8);
        img.Fill(color);
        sprite.Texture = ImageTexture.CreateFromImage(img);
    }
    
    
}