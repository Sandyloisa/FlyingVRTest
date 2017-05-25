﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

	public Transform head;

	public SteamVR_TrackedObject leftHand;
	public SteamVR_TrackedObject rightHand;

	private bool isFlying = false;
	
	// Update is called once per frame
	void Update () {

		var lDevice = SteamVR_Controller.Input ((int)leftHand.index);
		var rDevice = SteamVR_Controller.Input ((int)rightHand.index);

		if (lDevice.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger) || rDevice.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			isFlying = !isFlying;

		}

		if (isFlying) {
			Vector3 leftDir = leftHand.transform.position - head.transform.position;
			Vector3 rightDir = rightHand.transform.position - head.transform.position;

			Vector3 dir = leftDir + rightDir;
			transform.position += dir * .1f;
		}
		
	}
}
