using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// esta clase permite estandarizar el uso de los botones y establecer su comportamiento por medio del enumerador ButtonType que podremos seleccionar en el inspector
/// </summary>
public class AccelerometerInputButton : MonoBehaviour {

    // Use this for initialization
   // [Tooltip("true si queremos comenzar la detección de valores al presionar este boton, si es false detendrá la detección")]
    [SerializeField]//para que esta propiedad sea publica en el inspector pero privada para los scripts
    private AccelerometerInput accelerometerInput ;
    
    public enum ButtonType
    {
        START,
        CLEAN,
        STOP
    }
    [SerializeField]
    ButtonType buttonType;

    private bool onPressed;
    public bool getOnPressed {
        get { return onPressed; }
    }

    public void PressButtonAction()
    {
        switch (buttonType)
        {
            case ButtonType.CLEAN:
                accelerometerInput.CleanObjects();
                PnlDataController.CleanSelectedText();// al presionar el boton clean tambien limpiamoz el boton seleccionado
                break;
            case ButtonType.START:
                accelerometerInput.StartAccelerometer();
                break;
            case ButtonType.STOP:
                accelerometerInput.StopAccelerometer();
                break;
        }
        
        onPressed = true;
    }
    private void LateUpdate()
    {
        if (onPressed) onPressed = false;
        
    }

}
