using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class PacmanScript : CharacterScript
{
    private Godot.Collections.Array rays;
    private Vector2 nextDir = Vector2.Zero;
    IDictionary<Vector2, RayCast2D[]> rayDict = new Dictionary<Vector2, RayCast2D[]>();

    // Called when the node enters the scene tree for the first time.
    public PacmanScript()
    {
        speed = 100; //originally 100 speed
        speed = speed * gameSpeed; //need to figure out a way to have this inside of the character class/globals or something
    }

    public void GetInput()
    {
        if (Input.IsActionJustPressed("move_up"))
        {
            nextDir = Vector2.Up;
        }
        else if (Input.IsActionJustPressed("move_down"))
        {
            nextDir = Vector2.Down;
        }
        else if (Input.IsActionJustPressed("move_right"))
        {
            nextDir = Vector2.Right;
        }
        else if (Input.IsActionJustPressed("move_left"))
        {
            nextDir = Vector2.Left;
        }

        checkCollision(); //merge checkCollision code with GetInput
        //moveVelocity = moveDir * speed;



    }

    private void checkCollision()
    {
        if (nextDir == Vector2.Zero)
        {
            return;
        }

        int noCollision = 0;
        for (int i = 0; i < rayDict[nextDir].Length; i++)
        {

            if ((rayDict[nextDir])[i].IsColliding())
                return;
            else
                noCollision++;

        }

        if (noCollision == 2)
        {
            moveDir = nextDir;
        }
    }

    private void addRaystoDict()
    {
        RayCast2D[] upRays = new RayCast2D[2];
        RayCast2D[] downRays = new RayCast2D[2];
        RayCast2D[] rightRays = new RayCast2D[2];
        RayCast2D[] leftRays = new RayCast2D[2];

        int dictItem = -1;
        for (int i = 0; i < rays.Count; i++)
        {

            if (i % 2 == 0)
                dictItem++;

            if (dictItem == 0)
                upRays[i % 2] = (RayCast2D)rays[i];
            else if (dictItem == 1)
                downRays[i % 2] = (RayCast2D)rays[i];
            else if (dictItem == 2)
                rightRays[i % 2] = (RayCast2D)rays[i];
            else if (dictItem == 3)
                leftRays[i % 2] = (RayCast2D)rays[i];
        }

        rayDict.Add(Vector2.Up, upRays);
        rayDict.Add(Vector2.Down, downRays);
        rayDict.Add(Vector2.Right, rightRays);
        rayDict.Add(Vector2.Left, leftRays);
    }
    public override void _Ready()
    {

        mazeTm = GetNode<TileMap>("/root/Game/MazeContainer/Maze/MazeTilemap"); //maybe have a pacmanInit method with all this crap in
        Position = (Vector2)mazeTm.Call("SetSpawn", true); //SetSpawn function should probably be in the Character class now that i think about it

        //I feel like setting the spawn of pacman should be done in the main script so that pacman can be ran independantly of other nodes, or even in the character script instead

        rays = GetTree().GetNodesInGroup("pacmanRays");
        addRaystoDict();


    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        Vector2 masVector = Move();
        //var masVector = MoveAndSlide(moveVelocity, Vector2.Up); //potentially could put this in the character class somwehere
        //GD.Print(masVector);
        MoveAnimManager(masVector);
    }
}
