using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCtrl : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start(){
        boxCollider = GetComponent <BoxCollider2D>();
    }
    private void FixedUpdate(){
        // Coletar o valor do input no eixo X
        float x = Input.GetAxisRaw("Horizontal");
        // Coletar o valor do input no eixo Y
        float y = Input.GetAxisRaw("Vertical");
        moveDelta = new Vector3(x,y,0);

        //Mudar a sprite baseado se vc vai pra esquerda ou não
        if(moveDelta.x > 0)
            transform.localScale = new Vector3(1,1,1);
        else if(moveDelta.x < 0)
        transform.localScale = new Vector3(-1,1,1);
        //Verificando se podemos ir para aquele lugar
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y*Time.deltaTime), LayerMask.GetMask("Characters","Blocking"));
        if(hit.collider == null){
        //Movimento em y
        transform.Translate(0,moveDelta.y * Time.deltaTime,0);
        //Verificando se podemos ir para aquele lugar
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x*Time.deltaTime), LayerMask.GetMask("Characters","Blocking"));
        if(hit.collider == null){
        //Movimento em x
        transform.Translate(moveDelta.x * Time.deltaTime,0,0);
            }
        }
    }
} 
