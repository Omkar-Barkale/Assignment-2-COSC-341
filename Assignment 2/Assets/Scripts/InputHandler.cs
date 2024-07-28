using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCam;
    void Awake(){
        mainCam = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext ctx){
        if(!ctx.started)return;
        
        var rayHit = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if(!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);
    }
}
