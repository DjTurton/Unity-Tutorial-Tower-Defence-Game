using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class EditorSnap : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake() 
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {      
        SnapGrid(); 
        AddLabelDisplay();
    }

    //ensure the terrain only snaps to certain positions
    void SnapGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize);
    }

    //set coordinates to display on label
    void AddLabelDisplay()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = "Cube " + labelText;
    }
}
