using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour, IUseable
{

    [SerializeField]
    private Collider2D platformCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        if (Player.Instance.OnLadder)
        {
            //nees to stop climbing
            UseLadder(false, 1);
        }
        else
        {
            //need to start climbing
            UseLadder(true, 0);
            Physics2D.IgnoreCollision(Player.Instance.GetComponent<Collider2D>(), platformCollider, true);
        }
    }

    private void UseLadder(bool onLadder, int gravity)
    {
        Player.Instance.OnLadder = onLadder;
        Player.Instance.MyRigidbody.gravityScale = gravity;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UseLadder(false, 1);
            Physics2D.IgnoreCollision(Player.Instance.GetComponent<Collider2D>(), platformCollider, false);
        }
    }

}
