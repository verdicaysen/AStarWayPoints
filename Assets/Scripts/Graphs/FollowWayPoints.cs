using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowWayPoints : MonoBehaviour
{

    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotationSpeed = 2.0f;

    public GameObject wayPointManager;
    GameObject[]wayPoints;
    GameObject currentNode;
    int currentWayPoint = 0;
    Graph g;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        wayPoints = wayPointManager.GetComponent<WayPointManager>().wayPoints;
        g = wayPointManager.GetComponent<WayPointManager>().graph;
        currentNode = wayPoints[0];
    }

    public void GoToHelipad()

    {
        g.AStar(currentNode, wayPoints[0]);
        currentWayPoint = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
