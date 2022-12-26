using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovesController : MonoBehaviour
{
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
        Transform leftWall = GameObject.Find("Walls").transform.Find("LeftWall");
        Transform rightWall = GameObject.Find("Walls").transform.Find("RightWall");
         minX = leftWall.position.x + leftWall.GetComponent<BoxCollider2D>().offset.x + leftWall.GetComponent<BoxCollider2D>().size.x;
         maxX = rightWall.position.x + rightWall.GetComponent<BoxCollider2D>().offset.x - rightWall.GetComponent<BoxCollider2D>().size.x;
    }

    private void Update() {
        canMove = !PauseHandler.isPause && Physics2D.OverlapCircle(transform.position,checkRadius,whatIsGround);
        if (swipe.swipedRight == true && transform.position.x < maxX && canMove)
        {     
            targetPos = new Vector2(maxX,transform.position.y);
            StartCoroutine(AfterMove());


        }
        if (swipe.swipedLeft == true && transform.position.x > minX && canMove)
        {
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
            anim.SetTrigger("right");
        }
        if (transform.position.x == minX)
        {
            anim.SetTrigger("left");
        }
        yield return null;
    }
}
