using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endScreen;

    [Range(0.5f,2)]
    public float size = 1;

    [Range(0.5f, 4)]
    public float distance = 1;

    public Vector3 origin;


    private ArrayList conditions;
    
    void Start() {
        origin = this.transform.position;
        conditions = new ArrayList();
        conditions.Add(new Vector2(1,1));
        conditions.Add(new Vector2(1,2));
        conditions.Add(new Vector2(1,3));
        conditions.Add(new Vector2(2,1));
        conditions.Add(new Vector2(2,2));
        conditions.Add(new Vector2(2,3));
        conditions.Add(new Vector2(3,1));
        conditions.Add(new Vector2(3,2));
        conditions.Add(new Vector2(3,3));
        newConditions();

    }

    public void newConditions(){
        if(conditions.Count <=0f){
            endGame();
            return;
        }
        int randomIndex = Random.Range(0,conditions.Count-1);


        Vector2 newCond = (Vector2) conditions[randomIndex];
        conditions.RemoveAt(randomIndex);
        size = newCond.x * 0.5f;
        distance = newCond.y * 1.5f;

    }

    public void endGame(){
        endScreen.SetActive(true);
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    
   
}
