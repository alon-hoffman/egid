using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlus : MonoBehaviour
{
    
    
    Gun gun;
    private void Start()
    {
        
        gun = FindObjectOfType<Gun>();
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gun.BulletPlus();
            Destroy(gameObject);
        }
    }
}
