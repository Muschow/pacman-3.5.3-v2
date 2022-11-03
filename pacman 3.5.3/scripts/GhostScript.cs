using Godot;
using System;
using System.Collections.Generic;

public class GhostScript : CharacterScript
{

    protected override void MoveAnimManager(Vector2 masVector)
    {
        AnimatedSprite ghostEyes = GetNode<AnimatedSprite>("GhostEyes"); //not sure whether to put it in here for readabillity or in each ready so theres less calls

        masVector = masVector.Normalized();
        if (masVector == Vector2.Up)
        {
            ghostEyes.Play("up");
        }
        else if (masVector == Vector2.Down)
        {
            ghostEyes.Play("down");
        }
        else if (masVector == Vector2.Right)
        {
            ghostEyes.Play("right");
        }
        else if (masVector == Vector2.Left)
        {
            ghostEyes.Play("left");
        }
    }
    //As GhostScript is a base class, it will not be in the scene tree so ready and process are not needed
    // Called when the node enters the scene tree for the first time.

    public override void _Ready()
    {
        Position = new Vector2(48, 48); //temp starting pos
        TileMap mazeTm = GetNode<TileMap>("/root/Game/MazeContainer/Maze/MazeTilemap");

        Vector2[] nodeListList = (Vector2[])mazeTm.Get("nodeList"); //godot does not have lists or 2d arrays so you must create a jagged array or convert list to array
        GD.Print("nodeListList len " + nodeListList.Length);
        // int[,] adjMatrix = new int[,];
        // int[,] adjMatrix = (int[,])mazeTm.Call("GenerateAdjMatrix");

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
