using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="lvlPar",menuName ="aLvl")]
public class LvlPar : ScriptableObject
{
   [SerializeField] public int numOfBullets;
   [SerializeField] public  List <Vector2> bulletPlusPos ;
}
