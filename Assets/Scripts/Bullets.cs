using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] GameObject blob;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") { }
        else if (other.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.tag=="block")
        {
            Instantiate(blob, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }       
}
