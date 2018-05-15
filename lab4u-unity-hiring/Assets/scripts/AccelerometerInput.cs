using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour {

	public GameObject PnlVariables;
	public GameObject prefabPnlData;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// We use the accelerometer input tutorial from unity see link
		// https://unity3d.com/es/learn/tutorials/topics/mobile-touch/accelerometer-inputv
		float x = Input.acceleration.x;
		float y = Input.acceleration.y;
		float z = Input.acceleration.z;
		// https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
		GameObject PnlData = Instantiate(prefabPnlData) as GameObject;
		PnlDataController pnlDataController = PnlData.GetComponent<PnlDataController>();
		pnlDataController.setValues (x, y, z, 0);
		PnlData.transform.SetParent(PnlVariables.transform, false);
	}
}
