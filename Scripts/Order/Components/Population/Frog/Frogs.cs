using Godot;

namespace NGJ2026.Scripts.Order.Components.Population.Frog;

public partial class Frogs : Population
{
    private Color[] frogColor = { 
        new Color(0, 0.98039f, 0.60392f), 
        new Color(0.52941f,  1.00000f,  0.16471f),
        new Color(0.00000f,  0.97647f,  0.00000f),
        new Color(0.65490f,  0.98824f,  0.00000f),
        new Color(0.82745f,  1.00000f,  0.00000f),
        new Color(0.00000f,  1.00000f,  0.48627f),
    };

    [Export] private Timer timer = new Timer();
    [Export] FrogBody Body;
    

    public override void _Ready()
    {
        timer.WaitTime = hopTime;
        //GD.Print("Frog added");
    }

    protected override void CreateTexture(Color color, int X, int Y)
    {
        var img = Image.CreateEmpty(1, 1, false, Image.Format.Rgb8);
        img.Fill(color);
        sprite.Texture = ImageTexture.CreateFromImage(img);
    }

    public override void _Process(double delta)
    {
        if (!(timer.TimeLeft <= 0))
        {
            Hop();
            timer.Start(hopTime);
        }
        
    }
    
    public override void Spawn(int X, int Y)
    {
        CreateTexture(ChooseColor(), 0, 0);
        Position = new Vector2(X, Y);
    }

    private Color ChooseColor()
    {
        var val = GameManager.Instance.Random.Next(frogColor.Length);
        return frogColor[val];
    }

    public override void _ExitTree()
    {
        GD.Print("Frog dead");
    }


    protected override void Hop()
    {
        var X = (float)GameManager.Instance.Random.Next(-10, 10)/10 * hopForce;
        var Y =(float) -GameManager.Instance.Random.NextDouble() * hopForce;
        var vector = new Vector2(X, Y);
        //GD.Print(vector);
        if(Body != null)
        {
            //GD.Print("hopping");
            Body.velocity += vector;
        }
    }
}