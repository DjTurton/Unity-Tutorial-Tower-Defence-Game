﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    Vector2Int gridPos;
    const int gridSize = 10;

    public bool isExplored = false; 
    public Waypoint exploredFrom;

    // Start is called before the first frame update
    void Start()
    {

    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    // Set the colour of the cube
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isExplored)
        {
            MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
            if (!(topMeshRenderer.material.color == Color.red) && !(topMeshRenderer.material.color == Color.green))
            {
                SetTopColor(Color.blue);
            }
        }
    }
}
