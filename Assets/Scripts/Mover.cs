using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected private BoxCollider2D boxCollider;
    protected private Vector3 moveDelta;
    protected private RaycastHit2D hit;
    protected float ySpeed = 0.7f;
    protected float xSpeed = 1f;
    protected virtual void Start (){
    boxCollider = GetComponent <BoxCollider2D>();
}
    protected virtual void UpdateMotor(Vector3 input){
            moveDelta = input;
    //Verificando se podemos seguir nessa direção (Y)
    hit = Physics2D.BoxCast(transform.position, boxCollider.size,0, new Vector2 (0,moveDelta.y),Mathf.Abs(moveDelta.y*Time.deltaTime), LayerMask.GetMask("Personagens","Collider"));
    if(hit.collider == null){
            //Movimento eixo Y
            transform.Translate(0,moveDelta.y*Time.deltaTime,0);
            }
    
    //Verificando se podemos seguir nessa direção (X)
     hit = Physics2D.BoxCast(transform.position, boxCollider.size,0, new Vector2 (moveDelta.x,0),Mathf.Abs(moveDelta.x*Time.deltaTime), LayerMask.GetMask("Personagens","Collider"));
    if(hit.collider == null){
            //Movimento eixo X
            transform.Translate(moveDelta.x*Time.deltaTime,0,0);
            }
            if(moveDelta.x <0){
                transform.localScale = new Vector3(-1,1,1);
            }
            else if(moveDelta.x > 0){
                 transform.localScale = new Vector3(1,1,1);
            }
    }
}
