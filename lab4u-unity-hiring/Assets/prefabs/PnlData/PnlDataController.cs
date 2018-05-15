using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PnlDataController : MonoBehaviour {

	public Text[] txtval = new Text[4];

	public void setValues(float x,float y,float z, float t){
		txtval [0].text = s(x);
		txtval [1].text = s(y);
		txtval [2].text = s(z);
		txtval [3].text = s(t);
	}
	private string s(float f){
		return string.Concat(f);
	}
		
}
