using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    GameObject papperCounterObject;

    GameObject mainCameraObject;
    Main mainScript;
    public bool isRun;
    float targetX;

    // Start is called before the first frame update
    void Start()
    {
        papperCounterObject = GameObject.Find("CountPapperText");
        mainCameraObject = GameObject.Find("Main Camera");
        mainScript = mainCameraObject.GetComponent<Main>();
        rb = GetComponent<Rigidbody>();
        targetX = gameObject.transform.position.x;
    }

    IEnumerator Run_Coroutine()
    {
        isRun = true;


        while (isRun)
        {
            rb.MovePosition(gameObject.transform.position + gameObject.transform.forward.normalized * Time.fixedDeltaTime * speed);
            yield return new WaitForFixedUpdate();
        }
    }

    private void LateUpdate()
    {
        if (isRun)
        {
            var point = gameObject.transform.position
                + gameObject.transform.forward.normalized * Time.fixedDeltaTime * speed;
            point.x = targetX;
            rb.MovePosition(point);
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
        }

    }
}

