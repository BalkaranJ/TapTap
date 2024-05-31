using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBarrier : MonoBehaviour
{

    public Transform player;
    public float expansionRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.position.x)
        {
            transform.position = new Vector2(player.position.x + expansionRate, transform.position.y);
        }
    }
}
