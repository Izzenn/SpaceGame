using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLastPlat : MonoBehaviour
{
    private Animator TheLastAnimation;
    public float EndCheckRadius;
    public Transform EndCheck;
    public LayerMask EndLayer;
    private bool IsTouchingEnd;
    // Start is called before the first frame update
    void Start()
    {
      TheLastAnimation = GetComponent<Animator>();    
    }

   
    void Update()
    {
        IsTouchingEnd = Physics2D.OverlapCircle(EndCheck.transform.position, EndCheckRadius, EndLayer);
        TheLastAnimation.SetBool("OnEnd", IsTouchingEnd);
    }
}
