using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform5 : MonoBehaviour
{
    public float Plat5CheckRadius;
    public Transform Plat5Check;
    public LayerMask Plat5Layer;
    private bool IsTouchingPlat5;
    private Animator PlatformAnimation;
   

    // Start is called before the first frame update
    void Start()
    {
        PlatformAnimation = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        IsTouchingPlat5 = Physics2D.OverlapCircle(Plat5Check.transform.position, Plat5CheckRadius, Plat5Layer);
        PlatformAnimation.SetBool("OnPlat5", IsTouchingPlat5);
        
    }

   
}
