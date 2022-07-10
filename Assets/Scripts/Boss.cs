using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum State
    {
        /// <summary>
        /// ��������� �����
        /// </summary>
        Idle,
        /// <summary>
        /// ���
        /// </summary>
        Angry,
        /// <summary>
        /// ��������� �������� ������ 
        /// </summary>
        Praise
    }


    /// <summary>
    /// ������� ���������
    /// </summary>
    private State state = State.Idle;

   
    Animator anim;
    // Start is called before the first frame update
    void Start()

    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {  

        anim.SetInteger("stateAnim", (int)state);
    }

    public void startAngry()
    {
        state = State.Angry;
    }
    public void startPraise()
    {
        state = State.Praise;
    }

}
