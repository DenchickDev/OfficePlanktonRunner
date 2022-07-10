using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    
  
    Rigidbody rb;
    public float speed;
    GameObject papperCounterObject;

    GameObject finalPointObject;
    Transform finalPointTransform;

    GameObject mainCameraObject;
    Main mainScript;

    private bool startingTheFinalScene = false;
    public bool isRun = false;
    float targetX;
    [SerializeField]
    private int passingAmountOfPaper = 10;

    private GameObject Boss;
    private Boss bossScript;

    public enum State
    {
        /// <summary>
        /// Состояние покоя
        /// </summary>
        Idle,
        /// <summary>
        /// Бег
        /// </summary>
        Run,
        /// <summary>
        /// Финальная анимация победы 
        /// </summary>
        finalWin,
        /// <summary>
        /// Финальная анимация поражения  
        /// </summary>
        finalDefeat
    }

    /// <summary>
    /// Текущее состояние
    /// </summary>
    private State state  = State.Idle;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        Boss = GameObject.Find("SM_Chr_Boss_Male_01");
        bossScript = Boss.GetComponent<Boss>();
        papperCounterObject = GameObject.Find("CountPapperText");
        mainCameraObject = GameObject.Find("Main Camera");
        mainScript = mainCameraObject.GetComponent<Main>();
        finalPointObject = GameObject.Find("finalPointObject");
        finalPointTransform = finalPointObject.GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        targetX = gameObject.transform.position.x;
    }
    private void Update()
    {
        anim.SetInteger("stateAnim", (int)state);
    }

    /*IEnumerator Run_Coroutine()
    {
        isRun = true;


        while (isRun)
        {
            rb.MovePosition(gameObject.transform.position + gameObject.transform.forward.normalized * Time.fixedDeltaTime * speed);
            yield return new WaitForFixedUpdate();
        }
    }*/

    private void LateUpdate()
    {
        if (isRun == true)
        {
            calculateState();
            var point = gameObject.transform.position + gameObject.transform.forward.normalized * Time.fixedDeltaTime * speed;
            point.x = targetX;
            rb.MovePosition(point);
        }
        if (startingTheFinalScene == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPointTransform.position, (speed/2) * Time.deltaTime);

            if (transform.position == finalPointTransform.position)
            {
                calculateState();
            }
             
        }
    }
    public void AddMovePosition(Vector3 delta)
    {
        targetX += delta.x;
    }
    private void calculateState()
    {
        if (isRun)
        {
            state = State.Run;
        }
        else
        if (startingTheFinalScene)
        {
            if (mainScript.papperCount < passingAmountOfPaper)
            {
                state = State.finalDefeat;
                bossScript.startAngry();
                //speed /= 2;

            }
            else if (mainScript.papperCount >= passingAmountOfPaper)
            {
                state = State.finalWin;
                bossScript.startPraise();
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pappers")
        {
            Debug.Log("Косание");
            Destroy(other.gameObject);
            //other.GetComponent<Papper>().collisionPlayer();
            mainScript.recalculationOfPpaper();
        }
        if (other.gameObject.tag == "Trap")
        {
            mainScript.recalculationOfPpaperBecauseCollidTrap();
        }
        if (other.gameObject.tag == "Finish")
        {
           // mainScript.finalTrigger();
            startingTheFinalScene = true;
            isRun = false;
        }
      
    }
    public void triggerFinalScene()
    {
        mainScript.finalTrigger();
    }
}