using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrustPlat1 : MonoBehaviour
{
    public float TrustPlatCheckRadius;
    public Transform TrustPlatCheck;
    public LayerMask TrustPlatLayer;
    private bool IsTouchingTrustPlat;
    private Animator TrustPlatAnimation;
    private float deadzoney = 80f;
    private float deadzonex = 10;
    // Start is called before the first frame update
    void Start()
    {
       TrustPlatAnimation = GetComponent<Animator>();
        
  

    }

    // Update is called once per frame
    void Update()
    {
        IsTouchingTrustPlat = Physics2D.OverlapCircle(TrustPlatCheck.transform.position, TrustPlatCheckRadius, TrustPlatLayer);
        TrustPlatAnimation.SetBool("OnTrustPlat", IsTouchingTrustPlat);
        if ((transform.position.y < deadzoney) && (transform.position.x < deadzonex))
        {
            Destroy(gameObject);
        }
    }
}
