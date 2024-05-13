using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaSuelo : MonoBehaviour
{
    public PlayerMovement controllerSalto;
    private void OnTriggerStay (Collider other)
    {
        controllerSalto.Grounded= true;
    }
    private void OnTriggerExit(Collider other)
    {
        controllerSalto.Grounded= false;
    }
}
