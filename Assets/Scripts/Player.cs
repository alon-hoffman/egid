using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    [SerializeField] float playerChangeSpeed = 1f;
    [SerializeField] GameObject deathSprite;
    [SerializeField] AudioClip bumpSound;
    AudioSource myAudioSource;
    public LvlPar lvlPar;
    
    
    Vector2 dirOfShoot;
    float angle;
    Rigidbody2D rb;
    Animation myAnimation;
    Gun gun;
    Vector2 targetPos;
    Death death;
    SpawnBullets spawnBullets;
    
    /*
    private void Awake()
    {
        spawnBullets = FindObjectOfType<SpawnBullets>();
        spawnBullets.DestroyToBuild();
    }
    */
    void Start()
    {
        
        death = FindObjectOfType<Death>();
        gun = FindObjectOfType<Gun>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        gun.Recharge();
        List<Vector2> bpPos = FindObjectOfType<StartingPos>().GetBpPos();
        if (bpPos.Count > 0)
        {
            spawnBullets = FindObjectOfType<SpawnBullets>();
            spawnBullets.DestroyToBuild();
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Death();
        }
    }

    public void Acclerate(Vector2 addedVelocity)
    {
        
       
       rb.velocity += addedVelocity * playerChangeSpeed;
      
    }
    
    public float GetPlayerChangeSpeed()
    {
        return playerChangeSpeed;
    }
    public void FlipSprite()
    {
        transform.localScale = new Vector2(-1, 1);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Death();
        }
        if (other.gameObject.tag == "block")
        {
            myAudioSource.PlayOneShot(bumpSound);
        }
    }
    private void Death()
    {
        gun.Recharge();
        Instantiate(deathSprite, transform.position, Quaternion.identity);
        Destroy(gameObject);


    }
    
}
    

