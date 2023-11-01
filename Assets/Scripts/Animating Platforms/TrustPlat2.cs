using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrustPlat2 : MonoBehaviour
{
    public float TrustPlat2CheckRadius;
    public Transform TrustPlat2Check;
    public LayerMask TrustPlat2Layer;
    private bool IsTouchingTrustPlat2;
    private Animator TrustPlat2Animation;
    private Vector3 deadzone;
    // Start is called before the first frame update
    void Start()
    {
        TrustPlat2Animation = GetComponent<Animator>();
        deadzone = new Vector3(-6.2f, 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        IsTouchingTrustPlat2 = Physics2D.OverlapCircle(TrustPlat2Check.transform.position, TrustPlat2CheckRadius, TrustPlat2Layer);
        TrustPlat2Animation.SetBool("OnTrustPlat2", IsTouchingTrustPlat2);
        if (transform.position == deadzone)
        {
            Destroy(gameObject);
        }

    }
}
