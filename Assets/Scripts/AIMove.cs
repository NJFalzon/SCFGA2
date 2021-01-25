using UnityEngine;
using Pathfinding;
using System.Collections.Generic;

public class AIMove : MonoBehaviour
{
    Seeker seeker;
    Path pathToFollow;
    GameObject target;

    List<Vector3> places;
    bool lineEnabled = false;

    float timer = 0;
    readonly float maxTimer = 0.2f;

    private void Start()
    {
        places = new List<Vector3>();
    }

    public void FindTargets(GameObject target)
    {
        this.target = target;
        seeker = GetComponent<Seeker>();
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
            places.Add(this.transform.position);
            timer = maxTimer;
        }
    }

    private void ShowPath(List<Vector3> path)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lineEnabled = !lineEnabled;
            GetComponent<LineRenderer>().enabled = lineEnabled;
        }

        if (lineEnabled)
        {
            GetComponent<LineRenderer>().positionCount = path.Count;
            GetComponent<LineRenderer>().SetPositions(path.ToArray());
        }
    }

    private void Update()
    {
        if ((timer -= Time.deltaTime) <= 0)
        {
            seeker.StartPath(transform.position, target.transform.position, ReadyToMove);
        }

        ShowPath(pathToFollow.vectorPath);
    }

    public List<Vector3> GetPath()
    {
        return places;
    }
}
