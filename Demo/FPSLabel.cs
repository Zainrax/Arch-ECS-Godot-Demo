using Godot;

namespace NodeDemo;

/// <summary>
/// A simple label that updates every frame with some information, mainly the FPS.
/// </summary>
public partial class FPSLabel : Label
{
	public override void _Process(double delta)
	{
		        int entityCount = 0;
        Node2D renderer = GetNode<Node2D>("/root/Demo/NodeEntityRenderer");
        
        foreach (Node child in renderer.GetChildren())
        {
            if (child is MovableEntity)
            {
                entityCount++;
            }
        }

        Text = $@"FPS: {Performance.GetMonitor(Performance.Monitor.TimeFps)}
Entities: {entityCount}";
	}
	
}
