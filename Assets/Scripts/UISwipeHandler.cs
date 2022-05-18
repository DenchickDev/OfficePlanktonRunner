 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform player;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {

            Debug.Log("Horisontal Swipe!");

            /*Vector3 position = player.position;
            position.x += 0.5f * delta.x * 0.25f;
            player.position = position;*/
        }
        else
        {
            if (delta.y > 0) Debug.Log("Up");
            else Debug.Log("Down");
        } 
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
