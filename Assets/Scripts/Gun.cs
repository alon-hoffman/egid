using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour

{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject target;
    [SerializeField] float angleMatch;
    [SerializeField] TextMeshProUGUI bulletNumText;
   
    [SerializeField] AudioClip lazerSound;
    [SerializeField] AudioClip rechargeSound;
    Player player;
    Rigidbody2D rb;
    CamAnim cam;
    AudioSource myAudioSource;
    int initialBullets;
    int numOfBullets;



    void Start()
    {
        initialBullets = FindObjectOfType<StartingPos>().GetBulletNum();
        
        numOfBullets = initialBullets;
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        float playerChangeSpeed= player.GetPlayerChangeSpeed();
        cam = FindObjectOfType<CamAnim>();
        myAudioSource = GetComponent<AudioSource>();
        ShowCount();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos =
            new Vector2(Input.mousePosition.x / Screen.width * 16f,
            Input.mousePosition.y / Screen.height * 12f);
        Vector2 playerPos = transform.position;
        Vector2 dirOfShoot = mousePos - playerPos;
        RotateGun(dirOfShoot);
      
        if (Input.GetButtonDown("Fire1"))
        {
             Shoot(dirOfShoot.normalized);
           
        }
    }
    private void RotateGun(Vector2 dirOfShoot)
    {
        
        float angle = Mathf.Atan2(dirOfShoot.x, dirOfShoot.y) * Mathf.Rad2Deg * -1;
        FlipGun(angle + angleMatch);
        //rb.rotation = angle + angleMatch;
        transform.rotation = Quaternion.Euler(0f,0f,angle + angleMatch);

    }
    private void FlipGun(float trueAngle)
    {
        Vector3 theScale = transform.localScale;
        if (trueAngle > 90 || trueAngle < -90)
        {

            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }
      //  rb.rotation = (angle + angleMatch);

        //transform.localScale = theScale;
    }

    private void Shoot(Vector2 angle)
    {
        if (numOfBullets > 0)
        {
            
            GameObject myBullet = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            Rigidbody2D bulletBody = myBullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = angle * bulletForce;
            cam.Shake();
            myAudioSource.PlayOneShot(lazerSound);
            numOfBullets--;
            player.Acclerate(bulletBody.velocity * -1);
            ShowCount();
           
        }

    }
    public void Recharge()
    {
        numOfBullets = initialBullets;
        ShowCount();
    }
    private void ShowCount()
    {
         bulletNumText.text = numOfBullets.ToString();
        // bulletNumText.text = 52.ToString();
        
    }
    public void BulletPlus()
    {
        myAudioSource.PlayOneShot(rechargeSound);
        numOfBullets++;
        ShowCount();
    }
    
}
