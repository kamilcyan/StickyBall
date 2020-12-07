using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float speed, bound;
    private bool up;

    void Start()
    {
        bound = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (up)
        {
            Vector3 pos = transform.position;
            pos.y += speed;
            transform.position = pos;
            if(transform.position.y > bound + 0.5f)
            {
                up = false;
            }
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y -= speed;
            transform.position = pos;
            if (transform.position.y < bound - 0.5f)
            {
                up = true;
            }
        }
    }
}
