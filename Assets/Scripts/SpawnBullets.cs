using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject bulletPlus;
    GameObject[] bps;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Debug.Log("destroy to build on");
            DestroyToBuild();
        }
    }
    public void DestroyToBuild()
    {

        bps = GameObject.FindGameObjectsWithTag("bulletPlus");
        
            for (var i = 0; i < bps.Length; i++)
            {
                Destroy(bps[i]);
            }
           
        Build();
    
    }
    private void Build()
    {
        
        List<Vector2> bpPos = FindObjectOfType<StartingPos>().GetBpPos();
        foreach (Vector2 pos in bpPos) {
           
            Instantiate(bulletPlus, pos, Quaternion.identity);
        }
    }
}
