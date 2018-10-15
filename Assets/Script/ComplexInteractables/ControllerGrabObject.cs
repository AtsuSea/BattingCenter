using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;

    private GameObject objectInHand;

    private bool isBatRelease;

    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        isBatRelease = false;
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bat" || other.tag == "ball")
        {
            SetCollidingObject(other);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "bat" || other.tag == "ball")
        {
            SetCollidingObject(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = device.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = device.angularVelocity;
        }

        objectInHand = null;
    }

    void Update()
    {
        if (device.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                if (!isBatRelease)
                {
                    GrabObject();
                }
            }
        }

        if (device.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                if (objectInHand.tag == "bat")
                {
                    if (isBatRelease)
                    {
                        ReleaseObject();
                        isBatRelease = false;
                    }
                    else
                    {
                        isBatRelease = true;
                    }
                }
                else
                {
                    ReleaseObject();
                }
            }
        }
    }
}
