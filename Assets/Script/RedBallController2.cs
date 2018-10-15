using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallController2 : MonoBehaviour
{

    private static RedBallController2 instance = null;
    public GameObject redBallC;
    public GameObject redBallR;
    public GameObject redBallL;

    public static RedBallController2 Instance
    {
        get { return RedBallController2.instance; }
    }



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ShotBall(string name)
    {
        switch (name)
        {
            case "RedBallC1":
                StartCoroutine("Dispear", redBallC);
                break;
            case "RedBallR1":
                StartCoroutine("Dispear", redBallR);
                break;
            case "RedBallL1":
                StartCoroutine("Dispear", redBallL);
                break;
        }
    }

    private IEnumerator Dispear(GameObject g)
    {
        g.SetActive(false);
        yield return new WaitForSeconds(5f);
        g.SetActive(true);
        yield break;
    }


}
