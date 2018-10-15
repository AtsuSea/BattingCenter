using UnityEngine;
using System.Collections;
using Valve.VR;

public class VRIO_Gun : VRInteractableObject
{
	public EVRButtonId fireButton = EVRButtonId.k_EButton_SteamVR_Trigger;
    

	public void Awake()
	{
		VRIO_Button.OnButtonPress += ToggleGunType;
	}

	public void Update()
	{
	}
   

	public void ToggleGunType()
	{
		//Swap gun type and set to matching material
		//Yeah I know. This code is pretty quick and dirty.
		//But this isn't the important part!
        
	}
}
