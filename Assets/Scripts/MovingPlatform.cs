using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float movingSpeed=1;
    public Transform pos, pos1,startingPos;
    Vector2 nextPos;
    

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startingPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos.position)
        {
            nextPos = pos1.position;
            Debug.Log("target changed from " + pos + " to " + pos1);
        }
        else if (transform.position == pos1.position)
        {
            nextPos = pos.position;
            Debug.Log("target changed from " + pos1 + " to " + pos);
        }
        transform.position = Vector2.MoveTowards(transform.position, nextPos, movingSpeed*Time.deltaTime);
        
        
    }
}
