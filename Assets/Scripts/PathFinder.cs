using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>(); //our grid of blocks
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint; // our start and end points

    bool isRunning = true; // used to check if while loop running 
    Waypoint searchCenter;

    List<Waypoint> path = new List<Waypoint>();

    // a list of vectors specifying four directions around the block on the grid
    // note that up == (0,1), down == (0, -1) etc 
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.left,
        Vector2Int.right,
        Vector2Int.down
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count != 0)
        {
            return path;
        }

        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        FormPath();
        return path;
    }

    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (var waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else 
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                waypoint.SetTopColor(Color.black);
            }
        }
        print("Loaded " + grid.Count + " blocks!");
    }

    //colour the start and end points of the grid
    void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    //find the path
    void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }

        print("PathFind finished");
    }

    //end pathfind search if end == start
    void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
            {
                print("searching from end node so we stop lol");
                isRunning = false;
            }
    }

    void ExploreNeighbours()
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates)) 
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            return;
        }
        queue.Enqueue(neighbour);
        neighbour.exploredFrom = searchCenter;
    }

    void FormPath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
