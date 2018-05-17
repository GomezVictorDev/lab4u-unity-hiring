using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PnlDataController : MonoBehaviour {//este objeto es creado para cada grupo de valores a mostrar en pantalla(vx,vy,vz,vt)
    //camnbie la estructura del codigo para solo tener un componente de tipo Text en cada objeto en vez de cuatro, con la intención de ahorrar un poco de memoria en el momento que hayan demasiados objetos en la lista

       
	public Text txtval ;
    public Text textDataSelected;
    public Button dataButton; //el objeto que contiene un boton para permitir ver en detalle la información.
    private static Text staticTextDataSelected;
    float x, y, z, t;
   
	public void setValues(float x,float y,float z, float t){
        this.x = x;
        this.y = y;
        this.z = z;
        this.t = t;
        string sx =   this.x.ToString();
        string sy =  this.y.ToString();
        string sz =  this.z.ToString();
        string st =  this.t.ToString();
      //  Debug.Log("length: "+sx.Length);
        if (sx.Length > 5) sx = sx.Substring(0, 6);
        if (sy.Length > 5)  sy= sy.Substring(0, 6) ;
        if(sz.Length>5) sz= sz.Substring(0, 6);
        if(st.Length>5) st = st.Substring(0, 5);
        FormatInputData(ref sx, ref sy, ref sz, ref st);
        

        txtval.text=string.Concat( sx+"      ", sy+"      ", sz+"      ", st);
        SetSelectedData();
    }
    private void Start()
    {
        staticTextDataSelected = textDataSelected;

    }
    private void Update()
    {
        if (AccelerometerInput.isAccelerometerActive() && dataButton.interactable)
            dataButton.interactable = false;
        else if(!AccelerometerInput.isAccelerometerActive() && !dataButton.interactable)
            dataButton.interactable = true;

       
    }
    private void FormatInputData(ref string sx,ref string sy,ref string sz,ref string st)
    {
        sx = "<color=#DB3234>X: " + sx + "</color>";
        sy = "<color=#3CB72A>Y: " + sy + "</color>";
        st = "<color=black>T: " + st+"</color>";
        sz = "<color=#0E55E9>Z: " + sz + "</color>";
    }
    /// <summary>
    /// este metodo será ejecutado por un boton para permitir vizualizar en la parte superior derecha con mayor detalle los datos recolectados
    /// </summary>
    public void SetSelectedData()
    {
        string sx = this.x.ToString();
        string sy = this.y.ToString();
        string sz = this.z.ToString();
        string st = this.t.ToString();
        FormatInputData(ref sx, ref sy, ref sz, ref st);

        textDataSelected.text = string.Concat("Datos Seleccionados: "+"\n"+sx+ " ", "\n" + sy + " ", "\n" + sz + " ", "\n" + st);
        

    }
    public static void CleanSelectedText()
    {
        staticTextDataSelected.text = "";
    }
		
}
