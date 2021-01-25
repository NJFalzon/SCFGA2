using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public List <Vector3> positions;

    [SerializeField] KeyCode up;
    [SerializeField] KeyCode upAlt;
    bool isUp = false;

    [SerializeField] KeyCode down;
    [SerializeField] KeyCode downAlt;
    bool isDown = false;

    [SerializeField] KeyCode left;
    [SerializeField] KeyCode leftAlt;
    bool isLeft = false;

    [SerializeField] KeyCode right;
    [SerializeField] KeyCode rightAlt;
    bool isRight = false;

    bool isCommand = false;

    [SerializeField] GameObject playerBody;
    public int snakeSize = 3;

    float timer = 0;
    readonly float timerMax = 0.2f;

    void Start()
    {
        positions = new List<Vector3>();
        snakeSize = GameManager.Instance.snakesize;
        isUp = false;
        isDown = false;
        isLeft = true;
        isRight = false;
    }

    void Update()
    {
        Control();
        SpawnBody();
    }

    void Control()
    {
        if (!isCommand)
        {
            if (isUp || isDown)
            {
                if (Input.GetKeyDown(left) || Input.GetKeyDown(leftAlt))
                {
                    isUp = false;
                    isDown = false;
                    isLeft = true;
                    isRight = false;
                    isCommand = true;
                }

                if (Input.GetKeyDown(right) || Input.GetKeyDown(rightAlt))
                {
                    isUp = false;
                    isDown = false;
                    isLeft = false;
                    isRight = true;
                    isCommand = true;
                }
            }

            if (isLeft || isRight)
            {
                if (Input.GetKeyDown(up) || Input.GetKeyDown(upAlt))
                {
                    isUp = true;
                    isDown = false;
                    isLeft = false;
                    isRight = false;
                    isCommand = true;
                }

                if (Input.GetKeyDown(down) || Input.GetKeyDown(downAlt))
                {
                    isUp = false;
                    isDown = true;
                    isLeft = false;
                    isRight = false;
                    isCommand = true;
                }
            }
        }

        if ((timer -= Time.deltaTime) <= 0)
        {
            Move();
            isCommand = false;
            timer = timerMax;
        }
    }

    void Move()
    {
        if (isUp)
        {
            Move(transform.position + Vector3.up);
        }
        if (isDown)
        {
            Move(transform.position + Vector3.down);
        }
        if (isLeft)
        {
            Move(transform.position + Vector3.left);
        }
        if (isRight)
        {
            Move(transform.position + Vector3.right);
        }
    }

    void Move(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, 1f);
        positions.Add(transform.position);
    }

    void SpawnBody()
    {
        if (snakeSize > transform.parent.childCount)
        {
            Instantiate(playerBody, new Vector3(100,100,0), Quaternion.identity).transform.parent = transform.parent;

            if(snakeSize >= 6)
            {
                GameObject.Find("EndTarget").GetComponent<NextLevel>().TurnOn();
            }
        }
    }
}
