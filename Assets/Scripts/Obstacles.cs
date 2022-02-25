using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float count;
    public bool isActive = false;
    private void Awake()
    {
        count = 3;
        speed = -3;
    }
    
    void Movement()
    {
        if (isActive == true)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        }

    }
    void BoostVelocity()
    {
        count -= Time.deltaTime;
        if (count == 0)
        {
            speed = speed * 2;
            count = 3;
        }
    }
    void Update()
    {
        Movement();

    }
}
