using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerCtrl : MonoBehaviour
{
private BoxCollider2D boxCollider;
private Vector3 moveDelta;
private RaycastHit2D hit;
    void Start (){
    boxCollider = GetComponent <BoxCollider2D>();
}
    void FixedUpdate(){
    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");
 
    moveDelta = new Vector3(x,y,0);
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
        }
}