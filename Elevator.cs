using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform floor0;
    public Transform floor1;
    public Transform floor2;
    public Transform floor3;

    public float speed = 2f;

    private float targetY;
    private bool moving = false;

    void Start()
    {
        targetY = transform.position.y;
    }

    void Update()
    {
        if (!moving) return;

        float newY = Mathf.MoveTowards(
            transform.position.y,
            targetY,
            speed * Time.deltaTime
        );

        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z
        );

        // Stop condition
        if (Mathf.Approximately(transform.position.y, targetY))
        {
            transform.position = new Vector3(
                transform.position.x,
                targetY,
                transform.position.z
            );

            moving = false;
        }
    }

    void MoveToFloor(Transform floor)
    {
        targetY = floor.position.y;
        moving = true;
    }

    public void GoToFloor0()
    {
        MoveToFloor(floor0);
    }

    public void GoToFloor1()
    {
        MoveToFloor(floor1);
    }

    public void GoToFloor2()
    {
        MoveToFloor(floor2);
    }

    public void GoToFloor3()
    {
        MoveToFloor(floor3);
    }
}