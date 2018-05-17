using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PnlDataController : MonoBehaviour {//este objeto es creado para cada grupo de valores a mostrar en pantalla(vx,vy,vz,vt)
    //camnbie la estructura del codigo para solo tener un componente de tipo Text en cada objeto en vez de cuatro, con la intención de ahorrar un poco de memoria en el momento que hayan demasiados objetos en la lista
	public Text txtval ;
    public Text textDataSelected;
    public Button dataButton;
    
    float x, y, z, t;
   
	public void setValues(float x,float y,float z, float t){
        this.x = x;
        this.y = y;
        this.z = z;
        this.t = t;
        txtval.text=string.Concat( x+"      ", y+"      ", z+"      ", t);
        SetSelectedData();
    }
    private void Start()
    {
       

    }
    private void Update()
    {
        if (AccelerometerInput.isAccelerometerActive() && dataButton.interactable)
            dataButton.interactable = false;
        else if(!AccelerometerInput.isAccelerometerActive() && !dataButton.interactable)
            dataButton.interactable = true;

       
    }
    public void SetSelectedData()
    {

        
        textDataSelected.text = string.Concat("Datos seleccionados:\nX: "+x+"\n", "Y: " + y + "\n", "Z: " + z + "\n", "T: " + t);
        

    }
		
}
