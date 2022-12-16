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
    }

    private void Update() {
        canMove = Physics2D.OverlapCircle(transform.position,checkRadius,whatIsGround);
        Debug.Log(canMove);
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
        new WaitForSeconds(0.13f);
        new WaitUntil(() => transform.position.x == maxX || transform.position.x == minX);
        if (transform.position.x == maxX)
        {
            anim.SetTrigger("left");
        }
         if (transform.position.x == minX)
        {
            anim.SetTrigger("right");
        }
        yield return null;
    }

}
