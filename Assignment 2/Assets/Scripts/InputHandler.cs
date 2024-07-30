using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCam;
    public TargetShifter starter;

    private int current = 1;
    void Awake(){
        mainCam = Camera.main;
        starter.activate();
    }

    public void OnClick(InputAction.CallbackContext ctx){
        if(!ctx.started)return;
        
        var rayHit = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if(!rayHit.collider) return;

        if(rayHit.collider.gameObject.name == starter.gameObject.name){
            starter.deactivate();
            starter = starter.nextTarget;
        }

        
    }
}
