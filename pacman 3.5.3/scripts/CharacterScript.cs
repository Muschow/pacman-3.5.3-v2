using Godot;
using System;
using System.Collections.Generic;

public abstract class CharacterScript : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    protected float speed;
    protected float gameSpeed = 2.5f; //maybe change this back to gameSpeed if the ghost maze wall also inherits from character
    protected int health;
    protected Vector2 moveDir = new Vector2(0, 0);
    protected Vector2 moveVelocity; //maybe remove this from characterscript?
    protected TileMap mazeTm;
    protected AnimatedSprite animatedSprite;

    protected void PlayAndPauseAnim(Vector2 masVector) //requires AnimatedSprite reference
    {
        AnimatedSprite animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        //animatedSprite.SpeedScale = gameSpeed; not sure whether to get rid of this, it looks kind of weird.

        if (masVector == Vector2.Zero)
        {
            animatedSprite.Stop();
        }
        else if (masVector != Vector2.Zero)
        {
            animatedSprite.Play();
        }
    }

    protected Vector2 Move() //change moveDir and speed
    {
        moveVelocity = moveDir * speed;

        Vector2 masVector = MoveAndSlide(moveVelocity, Vector2.Up);

        PlayAndPauseAnim(masVector);

        return masVector;
    }
    protected virtual void MoveAnimManager(Vector2 masVector) //override this with swapping eye animation for ghosts
    {
        AnimatedSprite animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite"); //not sure whether to put it in here for readabillity or in each ready so theres less calls
        masVector = masVector.Normalized();
        if (masVector == Vector2.Up)
        {
            animatedSprite.RotationDegrees = -90;
        }
        else if (masVector == Vector2.Down)
        {
            animatedSprite.RotationDegrees = 90;
        }
        else if (masVector == Vector2.Right)
        {
            animatedSprite.RotationDegrees = 0; //this takes facing right as the default animation frame
        }
        else if (masVector == Vector2.Left)
        {
            animatedSprite.RotationDegrees = 180;
        }
    }

    //ready and process functions are useless here as Character Scene will never show up in the scene tree.
    // public override void _Ready()
    // {

    // }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
