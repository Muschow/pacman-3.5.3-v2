using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Movement : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public Vector2[] nodeList;
    //public int[,] adjMatrix; //have a method to get this as well? idk how it works tbh maybe a constructor
    public List<Vector2> pathList = new List<Vector2>();

    // public List<Vector2> InitNodeList()
    // {
    //     TileMap mazeTm = GetNode<TileMap>("/root/Game/MazeContainer/Maze/MazeTilemap");
    //     return nodeList = (List<Vector2>)mazeTm.Get("nodeList");
    // }

    //make a function to convert the source vector from a float to a actual vector by doing MapToWorld and WorldToMap etc
    public int ConvertVecToInt(Vector2 vector)
    {
        if (vector.x == 0)
        {
            return (int)vector.y;
        }
        else if (vector.y == 0)
        {
            return (int)vector.x;
        }
        else if (vector.x == 0 && vector.y == 0)
        {
            return 0;
        }
        else
        {
            return -1; //bascially error
        }
    }
    // public List<Vector2> Dijkstras(Vector2 source, Vector2 target) //takes in graph (adjMatrix) and source (Pos) Ghost MUST spawn on node
    // {
    //     //Have a method here that makes sure source and target are nice round Vectors and not decimals or something like that
    //     //Im thinking WorldToMap and then MapToWorld again

    //     if (source == target)
    //     {
    //         pathList.Add(source);
    //         return pathList;
    //     }

    //     List<Vector2> unvisited = new List<Vector2>();

    //     // Previous nodes in optimal path from source
    //     Dictionary<Vector2, Vector2> previous = new Dictionary<Vector2, Vector2>();

    //     // The calculated distances, set all to Infinity at start, except the start Node
    //     Dictionary<Vector2, int> distances = new Dictionary<Vector2, int>();

    //     for (int i = 0; i < nodeList.Length; i++)
    //     {
    //         unvisited.Add(nodeList[i]);

    //         // Setting the node distance to Infinity (or in this case 9999 lol)
    //         distances.Add(nodeList[i], 9999);
    //     }

    //     distances[source] = 0;

    //     while (unvisited.Count != 0)
    //     {
    //         //order unvisted list by distance.
    //         unvisited = (from vertex in distances
    //                      orderby vertex.Value ascending
    //                      select vertex.Key).ToList();
    //         //had to learn linq just for this smh

    //         Vector2 current = new Vector2(unvisited[0]); //get node with smallest distance
    //         unvisited.Remove(current); //remove

    //         if (current == target)
    //         {
    //             while (previous.ContainsKey(current))
    //             {
    //                 //insert the node onto the final result
    //                 pathList.Insert(0, current);

    //                 current = previous[current];
    //             }
    //             //insert the source onto the final result
    //             pathList.Insert(0, current);
    //             break;
    //         }

    //         for (int i = 0; i < nodeList.Length; i++)
    //         {
    //             int neighbourVal = adjMatrix[Array.IndexOf(nodeList, current), i];

    //             if (neighbourVal != 0)
    //             {
    //                 int alt = distances[current] + neighbourVal;
    //                 Vector2 neighbourNode = new Vector2(current + nodeList[i]);

    //                 if (alt < distances[neighbourNode])
    //                 {
    //                     distances[neighbourNode] = alt;
    //                     previous[neighbourNode] = current;
    //                 }
    //             }
    //         }
    //     }
    //     //path.bake() got no idea what this is supposed to do not going to lie
    //     return pathList;
    // }



    //Called when the node enters the scene tree for the first time.
    // public override void _Ready()
    // {
    //     


    // }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
