using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float lostime = 8f;
    private float sumtime;
    // Use this for initialization
    void Start()
    {
        sumtime = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (sumtime > lostime)
        {
            Destroy(gameObject);
        }
        else
        {
            sumtime += Time.deltaTime;
        }
    }
}
