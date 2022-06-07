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

    bool startingTheFinalScene = false;
    public bool isRun = false;
    float targetX;

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
    public State state = State.Idle;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
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
        anim.SetInteger("stateAnim",(int)state);
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
            var point = gameObject.transform.position + gameObject.transform.forward.normalized * Time.fixedDeltaTime * speed;
            point.x = targetX;
            rb.MovePosition(point);
        }
        if(startingTheFinalScene == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPointTransform.position, speed * Time.deltaTime);
        }
    }
    public void AddMovePosition(Vector3 delta)
    {
        targetX += delta.x;
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
            mainScript.finalTrigger();
            startingTheFinalScene = true;
            isRun = false;
        }

    }
}

