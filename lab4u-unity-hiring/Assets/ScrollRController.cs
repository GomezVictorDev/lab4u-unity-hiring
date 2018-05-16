using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRController : MonoBehaviour {

    // Use this for initialization
    ScrollRect m_rect;
    private void Awake()
    {
        m_rect = GetComponent<ScrollRect>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // m_rect.verticalNormalizedPosition = 0;
		
	}
}
