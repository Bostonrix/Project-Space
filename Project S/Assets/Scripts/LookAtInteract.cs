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
                if (Input.GetMouseButtonDown(0)){ //left mouse button pressed
                        action.buttonPressed(); //execute raycast object's buttonPressed method
                } else if (Input.GetMouseButtonUp(0)){ //left mouse button released
                    action.buttonReleased();//execute raycats object's button released method
                }
            }else if (hit.collider.TryGetComponent<FuelLever>(out var leverVar)){ //if raycast object is a GameObject with the FuelLever script : continue
                leverVar.OnLook();
                if (Input.GetMouseButtonDown(0)){ //left mouse button pressed
                        leverVar.buttonPressed(); //execute raycast object's buttonPressed method
                } else if (Input.GetMouseButtonUp(0)){ //left mouse button released
                    // newVar.buttonReleased();//execute raycats object's button released method
                }
            }else if (hit.collider.gameObject.name.Equals("ResearchPanel")){
                if(Input.GetMouseButtonDown(0)){
                    gameObject.TryGetComponent<PlayerController>(out var player);
                    player.canMove = !player.canMove;
                }
            }else if (hit.collider.TryGetComponent<ButtonTask>(out var newVar)){ //if raycast object is a GameObject with the Buttontask script : continue
                if (Input.GetMouseButtonDown(0)){ //left mouse button pressed
                        newVar.onPress(); //execute raycast object's onPress method
                }
            }
            
            
        }
    }

}
