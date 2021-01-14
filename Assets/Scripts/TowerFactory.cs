using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;
    [SerializeField] GameObject towerParent;

    Queue<Tower> queue = new Queue<Tower>();


    public void AddTower(Waypoint basePoint)
    {
        int numTowers = queue.Count;
        if (towerLimit > numTowers)
        {
            InstantiateNewTower(basePoint);
            numTowers += 1;
        }
        else
        {
            MoveTower(basePoint);
        }

    }

    public void InstantiateNewTower(Waypoint basePoint)
    {
        var newTower = Instantiate(tower, basePoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent.transform; 
        newTower.baseWaypoint = basePoint;

        queue.Enqueue(newTower);
    }

    private void MoveTower(Waypoint newBaseWaypoint)
    {
        var oldTower = queue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        queue.Enqueue(oldTower);
    }
}
