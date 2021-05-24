using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject startingPosition;
    [SerializeField] float ReWindSpeed = 2;
    bool dead;
    Vector2 targetPosition;

    Collider2D m_ObjectCollider;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        m_ObjectCollider = GetComponent<Collider2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        targetPosition = startingPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            MoveVelocity();
            IsTrigger();
        }
    }

    private void move()
    {
        var targetPosition = startingPosition.transform.position;
        var moveSpeed = ReWindSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards
            (transform.position, targetPosition, moveSpeed);
        if (transform.position == targetPosition)
        {
            m_ObjectCollider.isTrigger = false;
            dead = false;
        }
    }
    private void IsTrigger()
    {
        m_ObjectCollider.isTrigger = true;
        
    }
    public void SetDead(bool deathState)
    {
        dead = deathState;
    }
    private void MoveVelocity()
    {
        var targetPosition = startingPosition.transform.position;
        var moveSpeed = ReWindSpeed * Time.deltaTime;
        var dirMove = targetPosition - transform.position;
        rb.velocity = dirMove.normalized * moveSpeed;
        if (transform.position == targetPosition)
        {
            m_ObjectCollider.isTrigger = false;
            dead = false;
        }
    }
}
