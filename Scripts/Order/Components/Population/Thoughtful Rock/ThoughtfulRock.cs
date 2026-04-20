using Godot;
using System;
using NGJ2026.Scripts;
using NGJ2026.Scripts.Order.Components.Population;

public partial class ThoughtfulRock : Population
{
    [Export] private Color rockColor;
    [Export] private RockBody Body;
    private Image img;
    // Called when the node enters the scene tree for the first time.
    public override void Spawn(float X, float Y)
    {
        img = Image.CreateEmpty(2, 2, false, Image.Format.Rgb8);

        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                CreateTexture(rockColor, x, y);
            }
        }
        

        sprite.Texture = ImageTexture.CreateFromImage(img);
        GlobalPosition = new Vector2(X, Y);
    }

    protected override void Hop()
    {
        return;
    }

    public override void _EnterTree()
    {
    }

    protected override void CreateTexture(Color color, int X, int Y)
    {
        img.SetPixel(X, Y, color);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
