using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{
    List<Edge> edges = new List<Edge>();
    List<Node> nodes = new List<Node>();
    List<Node> pathList = new List<Node>();

    public Graph() { }

    public void AddNode(GameObject id)

    {
        Node node = new Node(id);
        nodes.Add(node);
    }

    public void AddEdge(GameObject fromNode, GameObject toNode)

    {

        Node from = FindNode(fromNode);
        Node to = FindNode(toNode);

        if(from != null && to != null) 
        
        {

            Edge e = new Edge(from, to);
            edges.Add(e);
            from.edgeList.Add(e);


        }

    }

    Node FindNode(GameObject id)
    {
        foreach (Node n in nodes)
            {
            if (n.getId() == id)
                return n;

        }

        return null;
    }

    //AStar Algorhithm without Linq. 

    public bool AStar(GameObject startId, GameObject endId)

    {
        Node start = FindNode(startId);
        Node end = FindNode(endId);


        //Error checking first in case it doesn't find anything.
        if(start == null || end == null)

        {
            return false;
        }

        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();

        //G is distance gone or cost so far.
        float tentative_g_score = 0;
        // If g score is better than what's on the node it'll take a better one.
        bool tentative_is_better;

        start.g = 0;
        start.h = distance(start, end);
        start.f = start.h;

        open.Add(start);
        while(open.Count > 0) 
        
        {

            int i = lowestF(open);
            Node thisNode = open[i];
            //This will mean it's found a path if == end.
            if(thisNode.getId() == endId)

            {
                return true;
            }

            //Time to do some algo to figure out which way to go and when to go there!
            open.RemoveAt(i);
            closed.Add(thisNode);
            Node neighbor;

            foreach (Edge e in thisNode.edgeList)
            {
                neighbor = e.endNode;

                if (closed.IndexOf(neighbor) > -1)
                    continue;

                tentative_g_score = thisNode.g + distance(thisNode, neighbor);
                if (open.IndexOf(neighbor) == -1)
                {
                    open.Add(neighbor);
                    tentative_is_better = true;

                }

                else if (tentative_g_score < neighbor.g)

                {

                    tentative_is_better = true;

                }

                else

                    tentative_is_better = false;

                if (tentative_is_better)

                {

                    neighbor.cameFrom = thisNode;
                    neighbor.g = tentative_g_score;
                    neighbor.h = distance(thisNode, end);
                    neighbor.f = neighbor.g + neighbor.h;

                }
            }
        }

        return false;

    }


    //Heuristic determinations. Goals and costs - determining the best way forward.
    float distance(Node a, Node b)

    {
        return(Vector3.SqrMagnitude(a.getId().transform.position - b.getId().transform.position));
    }

    int lowestF(List<Node> l)
    {
        float lowestf = 0;
        int count = 0;
        int interatorCount = 0;

        lowestf = l[0].f;

        for(int i = 1; i < l.Count; i++)
        {
            if (l[i].f < lowestf)
            {
                lowestf = l[i].f;
                interatorCount = count;
            }

            count++;
        }
        return interatorCount;
    }
}
