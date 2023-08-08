using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    //The paths starting and ending nodes.
    public Node startNode;
    public Node endNode;

    public Edge(Node from, Node to)

    { 
    
        startNode = from;
        endNode = to;
    
    }


}
