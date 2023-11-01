using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float hspeed = 5;
    public float hsspeed = 30;
    public float vspeed = 3;
    public float upstrength = 5;
    private float directionH;
    private float directionV;
    private float directionW;
    public Rigidbody2D player;
    public float GroundCheckRadius;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    private bool IsTouchingGround;
    public float ladderCheckRadius;
    public Transform LadderCheck;
    public LayerMask LadderLayer;
    private bool IsTouchingLadder;
    private Animator playeranimation;
    public GameObject Fall;
    public InGameFuncs alive;
    private Vector3 respawnpoint;
    public LogicScript logics;
    public GameObject Leapoffaith;
    private bool Alive = true;
    public float FaithCheckRadius;
    public Transform FaithCheck;
    public LayerMask FaithLayer;
    private bool IsTouchingFaith; 
    public float Plat5CheckRadius;
    public Transform Plat5Check;
    public LayerMask Plat5Layer;
    private bool IsTouchingPlat5;
    public float Plat1CheckRadius;
    public Transform Plat1Check;
    public LayerMask Plat1Layer;
    private bool IsTouchingPlat1;
    public GameObject Platform5;
    public GameObject Platform1;
    public GameObject AnotherFaith;
    public float AnotherFaithCheckRadius;
    public Transform AnotherFaithCheck;
    public LayerMask AnotherFaithLayer;
    private bool IsTouchingAnotherFaith;
    public float TrustCheckRadius;
    public Transform TrustCheck;
    public LayerMask TrustLayer;
    private bool IsTouchingTrust;
    public float TrustPlatCheckRadius;
    public Transform TrustPlatCheck;
    public LayerMask TrustPlatLayer;
    private bool IsTouchingTrustPlat;
    public float TrustPlat2CheckRadius;
    public Transform TrustPlat2Check;
    public LayerMask TrustPlat2Layer;
    private bool IsTouchingTrustPlat2;
    public GameObject Trust;
    public GameObject TrustPlat1;
    public GameObject TrustPlat2;
    public GameObject Ghost;
    public float SpikePlatCheckRadius;
    public Transform SpikePlatCheck;
    public LayerMask SpikePlatLayer;
    private bool IsTouchingSpikePlat;
    public Spike1 Spike;
    public GameObject Spikes;
    public GameObject Spikes2;
    public Spike2 Spike2;
    public Spike3 Spike3;
    public Spike4 Spike4;
    public Spike5 Spike5;
    public Spike6 Spike6;
    public Spike7 Spike7;
    public Spike8 Spike8;
    public Spike9 Spike9;
    public Spike10 Spike10;
    public Spike11 Spike11;
    public TheLastPlat End;
    private int SpikePlatIndex = 0;
    public GameObject BossFight;
    public GameObject Instructions;
    public float InstructionsCheckRadius;
    public Transform InstructionsCheck;
    public LayerMask InstructionsLayer;
    private bool IsTouchingInstructions;
    public float EndCheckRadius;
    public Transform EndCheck;
    public LayerMask EndLayer;
    private bool IsTouchingEnd;
    public GameObject TheLastPlat;
    public GameObject Rest;
    public Joystick joystick;

    void Start()
    {
        playeranimation = GetComponent<Animator>();
        respawnpoint = transform.position;
        logics = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Spike = GameObject.FindGameObjectWithTag("Spike1").GetComponent<Spike1>();
        Spike2 = GameObject.FindGameObjectWithTag("Spike2").GetComponent<Spike2>();
        Spike3 = GameObject.FindGameObjectWithTag("Spike3").GetComponent<Spike3>();
        Spike4 = GameObject.FindGameObjectWithTag("Spike4").GetComponent<Spike4>();
        Spike5 = GameObject.FindGameObjectWithTag("Spike5").GetComponent<Spike5>();
        Spike6 = GameObject.FindGameObjectWithTag("Spike6").GetComponent<Spike6>();
        Spike7 = GameObject.FindGameObjectWithTag("Spike7").GetComponent<Spike7>();
        Spike8 = GameObject.FindGameObjectWithTag("Spike8").GetComponent<Spike8>();
        Spike9 = GameObject.FindGameObjectWithTag("Spike9").GetComponent<Spike9>();
        Spike10 = GameObject.FindGameObjectWithTag("Spike10").GetComponent<Spike10>();
        Spike11 = GameObject.FindGameObjectWithTag("Spike11").GetComponent<Spike11>();
        End = GameObject.FindGameObjectWithTag("End").GetComponent<TheLastPlat>();






    }

    
    void Update()
    {
        directionW = joystick.Horizontal * hspeed;
        directionH = Input.GetAxis("horizontal"); 
        
        IsTouchingGround = Physics2D.OverlapCircle(GroundCheck.transform.position, GroundCheckRadius, GroundLayer);
        IsTouchingLadder = Physics2D.OverlapCircle(LadderCheck.transform.position, ladderCheckRadius, LadderLayer);
        IsTouchingFaith = Physics2D.OverlapCircle(FaithCheck.transform.position, FaithCheckRadius, FaithLayer);
        IsTouchingPlat5 = Physics2D.OverlapCircle(Plat5Check.transform.position, Plat5CheckRadius, Plat5Layer);
        IsTouchingPlat1 = Physics2D.OverlapCircle(Plat1Check.transform.position, Plat1CheckRadius, Plat1Layer);
        IsTouchingAnotherFaith = Physics2D.OverlapCircle(AnotherFaithCheck.transform.position, AnotherFaithCheckRadius, AnotherFaithLayer);
        IsTouchingTrust = Physics2D.OverlapCircle(TrustCheck.transform.position, TrustCheckRadius, TrustLayer);
        IsTouchingTrustPlat = Physics2D.OverlapCircle(TrustPlatCheck.transform.position, TrustPlatCheckRadius, TrustPlatLayer);
        IsTouchingTrustPlat2 = Physics2D.OverlapCircle(TrustPlat2Check.transform.position, TrustPlat2CheckRadius, TrustPlat2Layer);
        IsTouchingSpikePlat = Physics2D.OverlapCircle(SpikePlatCheck.transform.position, SpikePlatCheckRadius, SpikePlatLayer);
        IsTouchingInstructions = Physics2D.OverlapCircle(InstructionsCheck.transform.position, InstructionsCheckRadius, InstructionsLayer);
        IsTouchingEnd = Physics2D.OverlapCircle(EndCheck.transform.position, EndCheckRadius, EndLayer);
        
        if (directionH > 0 && Alive )
        {
            player.velocity = new Vector2 (directionH * hspeed, player.velocity.y);
            transform.localScale = new Vector2(0.35f, 0.35f);
        }
        else if (directionH < 0 && Alive)
        {
            player.velocity = new Vector2(directionH * hspeed, player.velocity.y);
            transform.localScale = new Vector2(-0.35f, 0.35f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
        if  (Input.GetKeyDown(KeyCode.Space) && (IsTouchingGround || IsTouchingFaith || IsTouchingPlat5 || IsTouchingPlat1 || IsTouchingAnotherFaith || IsTouchingTrust || IsTouchingSpikePlat || IsTouchingInstructions || IsTouchingEnd) && Alive)
        {
            player.velocity = new Vector2(player.velocity.x, upstrength);
        }
        if (IsTouchingLadder)
        {
            player.velocity = new Vector2 (player.velocity.x, vspeed);
        }
        if (IsTouchingPlat5)
        {
            upstrength = 10;
            transform.position = new Vector2(Platform5.transform.position.x, transform.position.y);   
        }
        if (IsTouchingEnd)
        {
            
            Rest.SetActive(true);
            transform.position = new Vector2(TheLastPlat.transform.position.x, transform.position.y);
        }
        if (!IsTouchingEnd)
        {

            Rest.SetActive(false);

        }
        if (!IsTouchingPlat5)
        {
            upstrength = 6;
        }
        if (IsTouchingPlat1)
        {
            transform.position = new Vector2(Platform1.transform.position.x, transform.position.y);
        }
        if (IsTouchingTrustPlat)
        {
            transform.position = new Vector2(TrustPlat1.transform.position.x, transform.position.y);
        }
        if (IsTouchingTrustPlat2)
        {
            transform.position = new Vector2(TrustPlat2.transform.position.x, TrustPlat2.transform.position.y);
        }
        if (IsTouchingSpikePlat)
        {
            SpikePlatIndex += 1;
            if (SpikePlatIndex == 1)
            {
                Spike.Spikemove();

            }
            else if (SpikePlatIndex == 2)
            {
                Spike2.Spikemove();
            }
            else if (SpikePlatIndex == 3)
            {
                Spike3.Spikemove();
            }
            else if (SpikePlatIndex == 4)
            {
                Spike4.Spikemove();
            }
            else if (SpikePlatIndex == 5)
            {
                Spike5.Spikemove();
            }
            else if (SpikePlatIndex == 6)
            {
                Spike6.Spikemove();
            }
            else if (SpikePlatIndex == 7)
            {
                Spike7.Spikemove();
            }
            else if (SpikePlatIndex == 8)
            {
                Spike8.Spikemove();
            }
            else if (SpikePlatIndex == 9)
            {
                Spike9.Spikemove();
            }
            else if (SpikePlatIndex == 10)
            {
                Spike10.Spikemove();
            }
            else if (SpikePlatIndex == 11)
            {
                Spike11.Spikemove();
            }

        }
      
        playeranimation.SetFloat("Speed",Mathf.Abs(player.velocity.x));
        playeranimation.SetBool("OnGround", IsTouchingGround);
        playeranimation.SetBool("OnLadder", IsTouchingLadder);
        playeranimation.SetBool("OnLadder", IsTouchingLadder);
        Fall.transform.position = new Vector2(transform.position.x, Fall.transform.position.y);
        Ghost.transform.position = new Vector2(Ghost.transform.position.x, transform.position.y);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            transform.position = respawnpoint;
            Leapoffaith.SetActive(false);
            BossFight.SetActive(false);
            AnotherFaith.SetActive(false);
            Trust.SetActive(false);
            Instructions.SetActive(false);
        }
        if (collision.gameObject.layer == 9)
        {
            logics.gameover();
            Alive = false;
            
        }
        if (collision.gameObject.layer == 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnpoint = transform.position;
        }
        if (collision.gameObject.layer == 12)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnpoint = transform.position;
        }
        if (collision.gameObject.layer == 13)
        {
            Leapoffaith.SetActive(true);
        }
        if (collision.gameObject.layer == 14)
        {
            Leapoffaith.SetActive(false);
        }
        if (collision.gameObject.layer == 17)
        {
            AnotherFaith.SetActive(true);
        }
        if (collision.gameObject.layer == 18)
        {
            AnotherFaith.SetActive(false);
            Trust.SetActive(true);
        }
        if (collision.gameObject.layer != 18)
        {
            Trust.SetActive(false);
        }
        if (collision.gameObject.layer == 23)
        {
            BossFight.SetActive(true);
        }
        if (collision.gameObject.layer == 24)
        {
            BossFight.SetActive(false);
            Instructions.SetActive(true);

        }
        if (collision.gameObject.layer != 24)
        {
            Instructions.SetActive(false);

        }
       







    }
    public void cantmove()
    {
        Alive = false;
    }
    public void canmove()
    {
        Alive = true;
    }
    public void Jump()
    {
        if (Alive && (IsTouchingGround || IsTouchingFaith || IsTouchingPlat5 || IsTouchingPlat1 || IsTouchingAnotherFaith || IsTouchingTrust || IsTouchingSpikePlat || IsTouchingInstructions || IsTouchingEnd))
        {
            player.velocity = Vector2.up * upstrength;
        }
        
    }
    
}
