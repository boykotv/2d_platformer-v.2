﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    [SerializeField]
    protected Transform arrowPos;

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    [SerializeField]
    protected GameObject arrowPrepfab;

    [SerializeField]
    protected Stat healthStat;

    [SerializeField]
    private EdgeCollider2D swordCollider;

    [SerializeField]
    private List<string> damageSourses = new List<string>();

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }

    public Animator MyAnimator { get; private set; }
    public EdgeCollider2D SwordCollider { get => swordCollider; }

    public virtual void Start()
    {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
        healthStat.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract IEnumerator TakeDamage();

    public abstract void Death();
    
    public virtual void ChangeDirection()
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

    public void MeleeAttack()
    {
        SwordCollider.enabled = true;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (damageSourses.Contains(other.tag))
        {
            StartCoroutine(TakeDamage());
        }
    }

}
