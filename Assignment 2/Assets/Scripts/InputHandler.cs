using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class InputHandler : MonoBehaviour
{
    
    private Camera mainCam;
    public TargetShifter starter;
    public GameManager gm;
    
    string filename = "";
    private float currentTime = 0;

    private bool playing = false;
    private ArrayList times = new ArrayList();
    private ArrayList valids = new ArrayList();

    
    void Awake(){
        mainCam = Camera.main;
        starter.activate();
        
        
    }

    void Update(){
        if(playing){
            currentTime = currentTime + Time.deltaTime;
        }
        
    }

    public void OnClick(InputAction.CallbackContext ctx){
        if(!ctx.started) return;
        
        var rayHit = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if(!rayHit.collider) return;
        if(filename == ""){
            filename = gm.getFilename();
        }

        

    
        if(gm.play){
            if(rayHit.collider.gameObject.name == starter.gameObject.name){
            
                

                if(playing){
                    TextWriter tw = new StreamWriter(filename, true);
                    tw.WriteLine(gm.inputype + ", " + gm.size*2 + ", " + gm.distance/0.75f*5f + ", " + currentTime + ", " + 1);
                    tw.Close();
                    currentTime = 0;}

                if(rayHit.collider.gameObject.name == "9"){
                    gm.newConditions();
                    playing = false;
                }
                if(rayHit.collider.gameObject.name == "1")
                {
                    playing = true;
                }
                starter.deactivate();
               starter = starter.nextTarget;
            }
            else if(playing){
              TextWriter tw = new StreamWriter(filename, true);
        
                tw.WriteLine(gm.inputype + ", " + gm.size*2 + ", " + gm.distance/0.75f*5f + ", " + currentTime + ", " + 0);
                tw.Close();
                
            }

        }
        
    }
}
