using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool up;
    public float speed, bound;

    // Start is called before the first frame update
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
            if (transform.position.y > bound + 0.1f)
            {
                up = false;
            }
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y -= speed;
            transform.position = pos;
            if (transform.position.y < bound - 0.1f)
            {
                up = true;
            }
        }
    }
}
