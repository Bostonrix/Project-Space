using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookAtInteract : MonoBehaviour
{
    public Camera playerCamera;
    public float maxRayDistance = 100f; //variable to limit interactabke distance

    void Update()
    {
        
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); //sets target ray
        RaycastHit hit; //initialises variable for raycast data to be stored
        if (Physics.Raycast(ray, out hit, maxRayDistance)) // if object is in raycast : continue
        {
            if (hit.collider.TryGetComponent<Console>(out var action)){ //if raycast object is a GameObject with the Console script : continue
                action.OnLook();
                if (Input.GetMouseButtonDown(0)) //left mouse button pressed
                {
                        action.OnClickAction(); //execute raycast object's OnClickAction method
                }
            }
        }
    }

}
