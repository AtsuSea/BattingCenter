using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPoint : MonoBehaviour
{

    public AudioSource fanfare;
    public Text point;
    public int pointInt;

    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            fanfare.Play();
            point.text = (int.Parse(point.text) + pointInt).ToString();

        }
    }
}
