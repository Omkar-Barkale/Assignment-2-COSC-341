using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShifter : MonoBehaviour
{
    public GameManager gm;
    public TargetShifter nextTarget;

    private bool active = false;
    public SpriteRenderer sp;

    void Start(){
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update() {

         Vector3 scale = this.transform.localScale;
         Vector3 direction = (this.transform.position - gm.origin).normalized;

        this.transform.localScale = new Vector3(Mathf.Lerp(scale.x, gm.size,0.1f), Mathf.Lerp(scale.y, gm.size,0.1f),0);

        this.transform.localPosition =  new Vector3(Mathf.Lerp(this.transform.position.x, (direction.x-gm.origin.x)*gm.distance,0.1f),Mathf.Lerp(this.transform.position.y, (direction.y-gm.origin.y)*gm.distance,0.1f),0);
    }

    public void activate(){
        active = true;
        this.sp.color = Color.red;

    }

    public void deactivate(){
        active = false;
        this.sp.color = Color.white;
        nextTarget.activate();
    }


    
}
