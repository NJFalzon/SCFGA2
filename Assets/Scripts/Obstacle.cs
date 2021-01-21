using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector3 posA;
    [SerializeField] Vector3 posB;

    bool isPosA = true;

    float timer = 0;
    readonly float maxTimer = 0.5f;


    private void Update()
    {
        if (isPosA)
        {
            Move(posB);
        }
        else
        {
            Move(posA);
        }
    }

    void Move(Vector3 pos)
    {
        if((timer-=Time.deltaTime) <= 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, pos, 1f);
            timer = maxTimer;
        }

        if(transform.position == pos)
        {
            isPosA = !isPosA;
        }
    }
}
