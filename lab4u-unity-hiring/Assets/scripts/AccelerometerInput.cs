using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerometerInput : MonoBehaviour {

    //public PnlDataController pnlDataController;
   
	public GameObject scrollContent;
	public GameObject prefabPnlData;
    [Tooltip("Asignar el scroll rect donde se encuetra el objeto PnlVariables")]
    public ScrollRect scrollR;//si bien primero cree una clase para manejar los valores del scroll, despues pense que el manejo del scroll es tan básico que tal vez no justificaba un script propio.
    // Use this for initialization
    private static bool startAccelerometer = false;//nos permitirá detener o comenzar el ciclo de obtención de datos del acelerometro,tambíen podremos saber en que estado esta en funcion de activar o desactivar los botones
    private int frameWait=6;
    List<GameObject> datas = new List<GameObject>();
   // float startX;
   // float startZ;
    public void StartAccelerometer()
    {
        startAccelerometer = true;
    }
    public void StopAccelerometer()
    {
        startAccelerometer = false;
    }
    public static bool isAccelerometerActive()
    {
        return startAccelerometer;
    }
    
    private void Start()
    {
       // startX= Y_arrow.transform.position.x;
      //  startZ = Y_arrow.transform.position.z;
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
            //Mathf.
            //scrollR.vertical = false;
            frameWait = 6;
            //todo este bloque se ejecuta cada cuadri cuando es probable que no sea necesario
            GameObject PnlData = Instantiate(prefabPnlData) as GameObject;//esta creando un nuevo objeto a pesar que ya hay uno en la escena
            PnlDataController pnlDataController = PnlData.GetComponent<PnlDataController>();// getcomponent es una operaciión muy costosa por lo que no suele ser buena idea ocuparlo en un update
            pnlDataController.setValues(x, y, z, 0);
            PnlData.transform.SetParent(scrollContent.transform, false);
            scrollR.verticalNormalizedPosition = 0;
            datas.Add(PnlData);
            scrollR.vertical = false;
          //  Y_arrow.transform.position = new Vector3(startX+x, 0, startZ-z);

        }
        if (Input.touchCount ==1)
        {
            Touch touch = Input.GetTouch(0);
        }
        
       
		
	}
    public void CleanObjects()
    {
        for (int i=0;i<datas.Count;i++)
        {
           Object.Destroy(( datas[i]));
        }
    }
   /*  void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(0.5f, 0, 0), Vector3.up*3);
    }*/
    void LateUpdate()
    {
        if (!startAccelerometer && frameWait > -1)
        {
            frameWait -= 1;
          //  Debug.Log("contando");
        }
        if (frameWait == 0) {
            scrollR.verticalNormalizedPosition = 0;//fix para que al detener la detección del acelerometro el ultimo valor se muestre
            //Debug.Log("frame ==0");
        } 
    }
}

