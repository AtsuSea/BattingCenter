using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batController : MonoBehaviour
{

    public AudioSource gunAudioSource;
    public Text point;
    public int pointInt;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        print("syoutotu");
        if (collision.gameObject.tag == "ball")
        {
            gunAudioSource.Play();
            point.text = (int.Parse(point.text) + pointInt).ToString();

            print("natteru");
        }
    }
}
