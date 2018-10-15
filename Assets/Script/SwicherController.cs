using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwicherController : MonoBehaviour
{
    public battingcenter Gun;
    

    void Awake()
    {
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller")
        {
            Gun.Swicher();
        }
    }
    

}
