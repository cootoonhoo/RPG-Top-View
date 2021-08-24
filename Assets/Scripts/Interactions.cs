using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxColider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start(){
        boxColider = GetComponent<BoxCollider2D>();
    }
    protected virtual void Update(){
        boxColider.OverlapCollider(filter, hits);
        for(int i =0; i< hits.Length; i++){
            if(hits[i]== null){
                continue;
            }
                Debug.Log(hits[i].name);
            hits[i] = null;
        }
    }
    protected virtual void OnCollide(Collider2D coll){
        Debug.Log(coll.name);
        Debug.Log("Porra");
    }
}
