using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTwords : MonoBehaviour
{
    [SerializeField] GameObject startingPosition;
    [SerializeField] float ReWindSpeed = 2;
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
         dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            move();
        }
    }
    private void move()
    {
        var targetPosition = startingPosition.transform.position;
        var moveSpeed = ReWindSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards
            (transform.position, targetPosition, moveSpeed);

    }
    public void SetDead(bool deathState)
    {
        dead = deathState;  
    }
}
