using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallController : MonoBehaviour
{

    private static RedBallController instance = null;
    public GameObject redBallC;
    public GameObject redBallR;
    public GameObject redBallL;

    public static RedBallController Instance
    {
        get { return RedBallController.instance; }
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
            case "RedBallC":
                StartCoroutine("Dispear", redBallC);
                break;
            case "RedBallR":
                StartCoroutine("Dispear", redBallR);
                break;
            case "RedBallL":
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
