using Godot;

namespace NodeDemo;
public partial class MovableEntity : Node2D
{
    public Vector2 Velocity;
    private Rect2 _viewport;

    public override void _Ready()
    {
        base._Ready();
        _viewport  = GetViewportRect();
    }

    public override void _Process(double delta)
    {
        // Movement
        Position += Velocity * (float)delta;

        // Bounce
        if (Position.X > _viewport.Position.X + _viewport.Size.X || Position.X < _viewport.Position.X)
            Velocity.X = -Velocity.X;

        if (Position.Y > _viewport.Position.Y + _viewport.Size.Y || Position.Y < _viewport.Position.Y)
            Velocity.Y = -Velocity.Y;
    }
}
