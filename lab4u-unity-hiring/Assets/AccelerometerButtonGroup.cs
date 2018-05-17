using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Esta clase tiene como objetivo permiti desactivar los botones dependiendo si alguno de los otros fue activado o no
/// </summary>
public class AccelerometerButtonGroup : MonoBehaviour {

    // Use this for initialization
    public GameObject goStartButton;
    public GameObject goStopButton;
    public GameObject goCleanButton;
    CanvasGroup canvasGroupButtonStart;
    CanvasGroup canvasGroupButtonClean;
    CanvasGroup canvasGroupButtonStop;
    AccelerometerInputButton startButton;
    AccelerometerInputButton stopButton;
    AccelerometerInputButton cleanButton;
    void Awake () {
        canvasGroupButtonStart = goStartButton.GetComponent<CanvasGroup>();
        canvasGroupButtonStop = goStopButton.GetComponent<CanvasGroup>();
        canvasGroupButtonClean = goCleanButton.GetComponent<CanvasGroup>();
        startButton = goStartButton.GetComponent<AccelerometerInputButton>();
        stopButton = goStopButton.GetComponent<AccelerometerInputButton>();
        cleanButton = goCleanButton.GetComponent<AccelerometerInputButton>();
    }
	
	// Update is called once per frame
	void Update () {
        if (startButton.getOnPressed)
        {
            DisableButtonStart();
            EnableButtonStop();
            DisableButtonClean();
        }
        if (stopButton.getOnPressed)
        {
            DisableButtonStop();
            EnableButtonStart();
            EnableButtonClean();
        }
      

    }
    private void EnableButtonStop()
    {
        canvasGroupButtonStop.alpha = 1;
        canvasGroupButtonStop.interactable = true;
    }
    private void DisableButtonStop()
    {
        canvasGroupButtonStop.alpha = 0;
        canvasGroupButtonStop.interactable = false;
    }
    private void EnableButtonClean()
    {
        canvasGroupButtonClean.alpha = 1;
        canvasGroupButtonClean.interactable = true;
    }
    private void DisableButtonClean()
    {
        canvasGroupButtonClean.alpha = 0;
        canvasGroupButtonClean.interactable = false;
    }
    private void EnableButtonStart()
    {
        canvasGroupButtonStart.alpha = 1;
        canvasGroupButtonStart.interactable = true;
    }
    private void DisableButtonStart()
    {
        canvasGroupButtonStart.alpha = 0;
        canvasGroupButtonStart.interactable = false;

    }
}
