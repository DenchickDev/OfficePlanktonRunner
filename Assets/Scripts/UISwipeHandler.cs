 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] float offset = 10.0f;
    [SerializeField] float sensitivity = 10.0f;

    Vector2 old_mouse_pos = Vector2.zero;
    Vector3 start_local_position = Vector3.zero;
    GameObject player;
    Player playerScript;


    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        //player = LevelManager.Instance.player;

        start_local_position = playerScript.gameObject.transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        old_mouse_pos = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 new_mouse_pos = Input.mousePosition;
        Vector2 delta = (new_mouse_pos - old_mouse_pos) * 0.0001f * sensitivity;

        if (Mathf.Abs(start_local_position.x -
            (player.gameObject.transform.localPosition.x + delta.x)) < offset)
            playerScript.AddMovePosition(player.gameObject.transform.right.normalized * delta.x);

        old_mouse_pos = new_mouse_pos;
    }
}
