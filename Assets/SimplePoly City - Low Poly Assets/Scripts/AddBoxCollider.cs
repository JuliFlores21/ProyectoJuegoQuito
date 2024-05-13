using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Obtener todos los hijos del objeto vacío que contiene los edificios
        Transform buildingsParent = transform; // Cambia 'transform' por la referencia al objeto vacío que contiene los edificios
        foreach (Transform child in buildingsParent)
        {
            // Agregar un Box Collider si no lo tiene
            if (child.GetComponent<BoxCollider>() == null)
            {
                child.gameObject.AddComponent<BoxCollider>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
