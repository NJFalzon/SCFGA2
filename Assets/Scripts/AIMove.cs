using UnityEngine;
using Pathfinding;
using System.Collections.Generic;

public class AIMove : MonoBehaviour
{
    Seeker seeker;
    Path pathToFollow;
    GameObject target;
    List<Vector3> places;

    float timer = 0;
    readonly float maxTimer = 0.2f;

    private void Start()
    {
        places = new List<Vector3>();
    }

    void FindTargets()
    {
        target = ClosestFood();
        seeker = GetComponent<Seeker>();
    }

    public void FindTargets(GameObject target)
    {
        this.target = target;
        seeker = GetComponent<Seeker>();
    }

    public GameObject ClosestFood()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        int chosenOne = 0;

        for(int i=0; i<targets.Length; i++)
        {
            if(Vector3.Distance(targets[i].transform.position,transform.position) 
                < Vector3.Distance(targets[chosenOne].transform.position, transform.position))
            {
                chosenOne = i;
            }
        }

        GetComponent<AIBody>().setTarget(targets[chosenOne]);
        return targets[chosenOne];
    }

    void ReadyToMove(Path p)
    {
        pathToFollow = p;
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, pathToFollow.vectorPath[1]) >= 0.5f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, pathToFollow.vectorPath[1], 1f);
            ShowPath(pathToFollow.vectorPath);
            places.Add(this.transform.position);
            timer = maxTimer;
        }
    }

    private void ShowPath(List<Vector3> path)
    {
        GetComponent<LineRenderer>().positionCount = path.Count;
        GetComponent<LineRenderer>().SetPositions(path.ToArray());
    }

    private void Update()
    {
        if (target == null)
        {
            FindTargets();
        }

        else if ((timer -= Time.deltaTime) <= 0)
        {
            seeker.StartPath(transform.position, target.transform.position, ReadyToMove);
        }
    }

    public List<Vector3> GetPath()
    {
        return places;
    }
}
