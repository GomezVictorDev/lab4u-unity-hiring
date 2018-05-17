using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerometerInput : MonoBehaviour {

    //public PnlDataController pnlDataController;
   
	public GameObject scrollContent;
	public GameObject prefabPnlData;
    public Text textDataSelected;
    [Tooltip("Asignar el scroll rect donde se encuetra el objeto PnlVariables")]
    public ScrollRect scrollR;//si bien primero cree una clase para manejar los valores del scroll, despues pense que el manejo del scroll es tan básico que tal vez no justificaba un script propio.
    // Use this for initialization
    private static bool startAccelerometer = false;//nos permitirá detener o comenzar el ciclo de obtención de datos del acelerometro,tambíen podremos saber en que estado esta en funcion de activar o desactivar los botones
    private int frameWait=6;
    private float seconds = 0;
    private float lastTouchTime = 0;
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
            seconds += Time.deltaTime;
            if (seconds > 60) seconds /=60;
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;
            float z = Input.acceleration.z;
            //Mathf.
            //scrollR.vertical = false;
            frameWait = 6;
           //la creación de objetos es bastante pesada y la cantidad que se crean puede ser bastante grande. Dependiendo del uso de la aplicación tal vez seria necesario buscar una optimización mayor, por ejemplo desactivar los objetos que estan fuera del alcance de la vista del "rect component" y así alivianar un poco el uso de memoria
            GameObject PnlData = Instantiate(prefabPnlData) as GameObject;
            PnlDataController pnlDataController = PnlData.GetComponent<PnlDataController>();
            pnlDataController.textDataSelected = textDataSelected;
            pnlDataController.setValues(x, y, z, seconds);//a pesar que en el archivo no se informa asumí que el cuarto valor es el tiempo desde que se comienzan a recolectar los datos
            PnlData.transform.SetParent(scrollContent.transform, false);
            scrollR.verticalNormalizedPosition = 0;
            datas.Add(PnlData);
            scrollR.vertical = false;
          //  Y_arrow.transform.position = new Vector3(startX+x, 0, startZ-z);

        }
        else
        {
            scrollR.vertical = true;
            if (seconds > 0) seconds = 0;
        }

        TochQuit();

    }
    /// <summary>
    /// este metodo cerrará la aplicación al hacer dos clicks rapidos en la pantalla.
    /// </summary>
    private void TochQuit()//este metodo podria estar en una clase de administración, pero en pos de la simplesa y dado el tamaño del ejercicio lo deje en esta clase.
    {
        if (Input.touchCount > 0)
        {

            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                if (lastTouchTime > 0)
                {
                    float timeBetweenTouch = Time.time - lastTouchTime;
                    if (timeBetweenTouch < 0.2f)
                    {
                        Application.Quit();
                    }
                }
                lastTouchTime = Time.time;
            }

        }
    }
    public void CleanObjects()
    {
        for (int i=0;i<datas.Count;i++)
        {
           Object.Destroy(( datas[i]));
        }
    }
 
    void LateUpdate()
    {
        
        if (!startAccelerometer && frameWait > -1)
        {
            frameWait -= 1;
          //  Debug.Log("contando");
        }
        // haremos un checkeo de luego 6 cuadros desde que a startAccelerometer se le asigno el valor de falso.
        if (frameWait == 0) {
            scrollR.verticalNormalizedPosition = 0;//fix para que al detener la detección del acelerometro el ultimo valor se muestre
            //Debug.Log("frame ==0");
        } 
    }
}

