using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float speed;
    private int nextIndex = 1;

    private void Start()
    {
        transform.position = flyPath[0];
    }
    private void Update()
    {
        if (flyPath == null) return;
        if (nextIndex > flyPath.waypoints.Length) return;

        if (transform.position != flyPath[nextIndex])
        {
            FlyToNextWayPoint();
            LookAt(flyPath[nextIndex]);
        }
        else
        {
            nextIndex++;
        }
    }

    private void LookAt(Vector2 destination)
    {
        Vector2 position = transform.position;
        var lookDestination = destination - position;
        if (lookDestination.magnitude < 0.01f) return;
        var angle = Vector2.SignedAngle(Vector3.down, lookDestination);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void FlyToNextWayPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, flyPath[nextIndex], speed * Time.deltaTime);
    }
}
