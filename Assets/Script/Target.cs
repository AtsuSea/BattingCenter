using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

    public AudioSource fanfare;
    public GameObject explosionParticle;
    public Transform explosionTransform;
    public RedBallController redBallController;
    public Text point;


    // Use this for initialization
    void Start () {
        redBallController = RedBallController.Instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            redBallController.ShotBall(this.name);
            fanfare.Play();
    
            GameObject expl = Instantiate(explosionParticle, explosionTransform.position, transform.rotation) as GameObject;

            Destroy(expl, 5f);
            point.text = (int.Parse(point.text) + 20).ToString();

        }
    }
}
