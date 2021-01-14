using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem deathParticles;


    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    //print all our waypoints in the assigned path
    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position + new Vector3(0, 10, 0);
            yield return new WaitForSeconds(movementPeriod);
        }
        //deal damage to player here ? 
        var vfx = Instantiate(deathParticles, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
