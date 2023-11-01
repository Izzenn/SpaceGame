using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike9 : MonoBehaviour
{
    private Animator SpikeAnimation;
    private bool Move = true;
    // Start is called before the first frame update
    void Start()
    {
        SpikeAnimation = GetComponent<Animator>();
    }

    public void Spikemove()
    {
        SpikeAnimation.SetBool("OnSpike", Move);
    }
}
