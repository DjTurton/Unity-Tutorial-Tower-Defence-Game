using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;

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
            MoveTower();
        }

    }

    public void InstantiateNewTower(Waypoint basePoint)
    {
        var newTower = Instantiate(tower, basePoint.transform.position, Quaternion.identity);

        queue.Enqueue(newTower);
    }

    private void MoveTower()
    {
        var oldTower = queue.Dequeue();


        queue.Enqueue(oldTower);
    }
}
