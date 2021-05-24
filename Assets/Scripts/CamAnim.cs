using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnim : MonoBehaviour
{
    [SerializeField] Animator camAnim;
    public void Shake()
    {
        camAnim.SetTrigger("shake");
    }
}
