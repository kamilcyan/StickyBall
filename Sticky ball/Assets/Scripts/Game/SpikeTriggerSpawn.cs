using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpikeTriggerSpawn : MonoBehaviour
{
    public GameObject[] spikeTrigger;
    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< 10; i++)
        {
            int PosX = random.Next(0, 190);
            GameObject spike = Instantiate(spikeTrigger[i]);
            spike.transform.position = new Vector2(PosX, 0);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
