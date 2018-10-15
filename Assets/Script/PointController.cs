using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController: MonoBehaviour
{

    public AudioSource fanfare;
    public Text point;
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            fanfare.Play();
            point.text = (int.Parse(point.text) + 100).ToString();
        }
    }
}
