using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPos : MonoBehaviour
{
    [SerializeField] LvlPar lvlPar;
    List<Vector2> bpPos;
    // Start is called before the first frame update
    int numOfBullets;
    void Start()
    {
        numOfBullets = lvlPar.numOfBullets;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetBulletNum()
    {
    return lvlPar.numOfBullets;
    }
    public List<Vector2> GetBpPos()
    {
        bpPos = lvlPar.bulletPlusPos;
        
        return bpPos;
    }
}
