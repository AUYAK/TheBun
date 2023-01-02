using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovesController : MonoBehaviour
{
    public GameObject playerEffect;
    public GameObject wallEffect;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool canMove;
    public float speed = 2f;
    public Vector2 targetPos;

    public Animator anim;

    public float minX;
    public float maxX;

     SwipesController swipe;

    private void Start() {
        swipe = FindObjectOfType<SwipesController>();
        ViewportHandler view = FindObjectOfType<ViewportHandler>();
        Transform leftWall = GameObject.Find("BrickWalls").transform.Find("LeftWall");
        Transform rightWall = GameObject.Find("BrickWalls").transform.Find("RightWall");
         minX = leftWall.position.x + leftWall.GetComponent<BoxCollider2D>().size.x / 2 + transform.GetComponent<CircleCollider2D>().radius;
         maxX = rightWall.position.x - rightWall.GetComponent<BoxCollider2D>().size.x / 2 - transform.GetComponent<CircleCollider2D>().radius;
    }

    private void Update() {
        canMove = !PauseHandler.isPause && Physics2D.OverlapCircle(transform.position,checkRadius,whatIsGround);
        if (swipe.swipedRight == true && transform.position.x < maxX && canMove)
        {
            Instantiate(playerEffect,transform.position, Quaternion.identity);     
            targetPos = new Vector2(maxX,transform.position.y);
            StartCoroutine(AfterMove());


        }
        if (swipe.swipedLeft == true && transform.position.x > minX && canMove)
        {
            Instantiate(playerEffect,transform.position, Quaternion.identity);    
            targetPos = new Vector2(minX,transform.position.y);
            StartCoroutine(AfterMove());

        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos,speed*Time.deltaTime);
    }
    public IEnumerator AfterMove()
    {
        // anim.SetTrigger("isMoving");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitUntil(() => transform.position.x == maxX || transform.position.x == minX);
        if (transform.position.x == maxX)
        {   
            Instantiate(wallEffect,transform.position + new Vector3(transform.localScale.x/2,0,0), Quaternion.identity);  
            anim.SetTrigger("right");
        }
        if (transform.position.x == minX)
        {
            Instantiate(wallEffect,transform.position - new Vector3(transform.localScale.x/2,0,0),Quaternion.Euler(new Vector3(0,0,180)));  
            anim.SetTrigger("left");
        }
        yield return null;
    }
}
