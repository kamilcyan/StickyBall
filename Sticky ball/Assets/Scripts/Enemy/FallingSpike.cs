using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    public GameObject fallingSpike;
    public GameObject player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpikeSpawn")
        {
            GameObject spike = Instantiate(fallingSpike);
            spike.transform.position = new Vector2(player.transform.position.x + 10, player.transform.position.y + 20);
            Destroy(spike, 3);
        }
    }

}
