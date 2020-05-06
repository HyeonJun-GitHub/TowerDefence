﻿using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        //normalized 동일한 속도
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {

        if (wavePointIndex >= Waypoints.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }


    

}
