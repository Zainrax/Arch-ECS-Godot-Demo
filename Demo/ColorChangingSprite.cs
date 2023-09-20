using Godot;
public partial class ColorChangingSprite : Sprite2D
{
    public override void _Process(double delta)
    {
        var color = Modulate;
        color.H = (color.H + (float)delta) % 1;
        Modulate = color;
    }
}
