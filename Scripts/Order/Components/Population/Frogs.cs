using Godot;


namespace NGJ2026.Scripts.Order.Components.Population;

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

    private Timer timer = new Timer();
    [Export] RigidBody2D Body;
    

    public override void _Ready()
    {
        AddChild(timer);
        timer.Autostart = true;
        timer.OneShot = false;
        timer.WaitTime = hopTime;

    }

    public override void _Process(double delta)
    {
        if(timer.TimeLeft <= 0)
        {
            Hop();
            timer.Start();
        }
    }
    
    public override void Spawn(int X, int Y)
    {
        CreateTexture(ChooseColor());
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
        var X = GameManager.Instance.Random.NextDouble() * hopForce;
        var Y = GameManager.Instance.Random.NextDouble() * hopForce;
        var vector = new Vector2((float)X, (float)Y);
        GD.Print(vector);
        if(Body != null) Body.LinearVelocity = vector;
    }
}