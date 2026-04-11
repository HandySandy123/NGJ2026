using Godot;
using System;
using NGJ2026.Scripts.Order.Components;

public abstract partial class GeographicalFeatures : Component
{
    public abstract void Spawn();
    protected abstract void Spread();
}
