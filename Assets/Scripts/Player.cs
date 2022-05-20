using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IBeginDragHandler, IDragHandler 
{
    Rigidbody rb;
    public float speed;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Постоянный бег
        rb.AddForce(Vector3.forward * (speed * 100));
     
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;
        if (Mathf.Abs(delta.x)>Mathf.Abs(delta.y))
        {
            Debug.Log("Horisontal Swipe!");
            Vector3 position = transform.position;
            position.x += 1.5f * delta.x * 0.5f;
            transform.position = position;
        }
        else
        {
            if (delta.y > 0) Debug.Log("Up");
            else Debug.Log("Down");
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
