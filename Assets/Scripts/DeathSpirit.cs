using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpirit : MonoBehaviour
{
    [SerializeField] float ReWindSpeed = 30;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip reWindSound;
    StartingPos startingPos;
    Vector3 target;
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = FindObjectOfType<StartingPos>();
        // Vector3 target = startingPos.transform.position;
        Vector3 target = new Vector3(5, 5, 2);
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.PlayOneShot(reWindSound);

    }

    // Update is called once per frame
    void Update()
    {
        if(startingPos.transform.position != transform.position)
        {
            var moveSpeed = ReWindSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, startingPos.transform.position, moveSpeed);
           
            

        }
        else
        {
            Instantiate(player, startingPos.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
