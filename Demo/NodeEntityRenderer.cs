using Godot;

namespace NodeDemo;

public partial class NodeEntityRenderer : Node2D
{
    // Path to the MovableEntity scene.
    public PackedScene MovableEntityScene = GD.Load<PackedScene>("res://MovableEntity.tscn");

    // Called once when the node is ready.
    public override void _Ready()
    {
        // Button setup.
		// This is likely considered bad practice in an actual Godot project, but this is done in the demo
		// to minimize the number of files and nodes in the project.
		GetNode<Button>("/root/Demo/MarginContainer/VBoxContainer/HBoxContainer/Add100Button").Pressed +=
			() => AddEntities(100);
		GetNode<Button>("/root/Demo/MarginContainer/VBoxContainer/HBoxContainer/Add500Button").Pressed +=
			() => AddEntities(500);
		GetNode<Button>("/root/Demo/MarginContainer/VBoxContainer/HBoxContainer/Add1000Button").Pressed +=
			() => AddEntities(1000);
		GetNode<Button>("/root/Demo/MarginContainer/VBoxContainer/ClearButton").Pressed +=
			ClearEntities;
		GetNode<SpinBox>("/root/Demo/MarginContainer/VBoxContainer/PhysicsTicksSpinBox").ValueChanged +=
			value => Engine.PhysicsTicksPerSecond = (int) value;
    }
    public void AddEntities(int amount)
    {
        GD.Print($"Adding {amount} entities");
        for (int i = 0; i < amount; i++)
        {
            var entity = MovableEntityScene.Instantiate<MovableEntity>();
            entity.Position = new Vector2(GD.Randf() * GetViewportRect().Size.X, GD.Randf() * GetViewportRect().Size.Y);
            entity.Velocity = new Vector2(GD.Randf() * 200f, GD.Randf() * 200f);

            entity.GetChild<Sprite2D>(0).Modulate = new Color(GD.Randf(), GD.Randf(), GD.Randf());
            AddChild(entity);
        }
    }

    public void AddEntities100()
    {
        AddEntities(100);
    }

    public void AddEntities500()
    {
        AddEntities(500);
    }

    public void AddEntities1000()
    {
        AddEntities(1000);
    }

    public void ClearEntities()
    {
        foreach (Node child in GetChildren())
        {
            if (child is MovableEntity)
            {
                child.QueueFree();
            }
        }
    }

    public void OnPhysicsTicksChanged(float value)
    {
        Engine.PhysicsTicksPerSecond = (int)value;
    }
}
