using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Animator myAnimator;

    [SerializeField]
    protected Transform arrowPos;

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    [SerializeField]
    protected GameObject arrowPrepfab;

    public bool Attack { get; set; }




    // Start is called before the first frame update
    public virtual void Start()
    {
        Debug.Log("CharacterStart");
        facingRight = true;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
    }




    public virtual void ShootAnArrow(int value)
    {
        if (facingRight)
        {
            GameObject tmp = Instantiate(arrowPrepfab, arrowPos.position, Quaternion.identity);
            tmp.GetComponent<Arrow>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = Instantiate(arrowPrepfab, arrowPos.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            tmp.GetComponent<Arrow>().Initialize(Vector2.left);
        }                
    }

}
