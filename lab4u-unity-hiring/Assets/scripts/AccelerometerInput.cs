using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour {

	public GameObject PnlVariables;
	public GameObject prefabPnlData;
    // Use this for initialization
    private bool startAccelerometer = false;//nos permitirá detener o comenzar el ciclo de obtención de datos del acelerometro,tambíen podremos saber en que estado esta en funcion de activar o desactivar los botones

    public void StartAccelerometer()
    {
        startAccelerometer = true;
    }
    public void StopAccelerometer()
    {
        startAccelerometer = false;
    }
    public bool isAccelerometerActive()
    {
        return startAccelerometer;
    }
	
	// Update is called once per frame
	void Update () {
		// We use the accelerometer input tutorial from unity see link
		// https://unity3d.com/es/learn/tutorials/topics/mobile-touch/accelerometer-inputv
		
        // https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
        if (startAccelerometer)
        {
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;
            float z = Input.acceleration.z;

            //todo este bloque se ejecuta cada cuadri cuando es probable que no sea necesario
            GameObject PnlData = Instantiate(prefabPnlData) as GameObject;//esta creando un nuevo objeto a pesar que ya hay uno en la escena
            PnlDataController pnlDataController = PnlData.GetComponent<PnlDataController>();// getcomponent es una operaciión muy costosa por lo que no suele ser buena idea ocuparlo en un update
            pnlDataController.setValues(x, y, z, 0);
            PnlData.transform.SetParent(PnlVariables.transform, false);
        }
       
		
	}
}
