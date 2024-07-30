using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(0.5f,2)]
    public float size = 1;

    [Range(0.5f, 4)]
    public float distance = 1;

    public Vector3 origin ;

    
    void Start() {
        origin = this.transform.position;
         var rotatestep = 360/9;
        for(int i = 0; i < 9; i++){
            Debug.Log(Mathf.Cos((rotatestep*i*Mathf.Deg2Rad)) + ", " + Mathf.Sin((rotatestep*i*Mathf.Deg2Rad)));
        }
    }

    
   
}
