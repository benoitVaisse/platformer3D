using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerController")]
    [Tooltip("Player controller component")]
    public CharacterController cc;
    public Vector3 MoveD;
    public float MoveSpeed;
    public float JumpForce;
    public float Gravity;

    private bool isWalking = false;

    
    public int coins;

    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = false;
        MoveD = new Vector3(
            Input.GetAxis("Horizontal") * MoveSpeed,
            Input.GetButtonDown("Jump") && cc.isGrounded ? JumpForce : MoveD.y,
            Input.GetAxis("Vertical") * MoveSpeed
        );

        if (MoveD.x != 0 || MoveD.z != 0)
        {
            isWalking = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(MoveD.x, 0, MoveD.z)), 0.3f);
        }
        animator.SetBool(nameof(isWalking), isWalking);
    }

    private void FixedUpdate()
    {
        MoveD.y -= !cc.isGrounded ? Gravity : 0;
        cc.Move(MoveD * Time.deltaTime);
    }
    //void FixedUpdate()
    //{
    //    isWalking = false;
    //    MoveD = new Vector3(
    //        Input.GetAxis("Horizontal") * MoveSpeed,
    //        Input.GetButtonDown("Jump") && cc.isGrounded ? JumpForce : MoveD.y,
    //        Input.GetAxis("Vertical") * MoveSpeed);

    //    MoveD.y -= !cc.isGrounded ? Gravity : 0;

    //    if (MoveD.x != 0 || MoveD.z != 0)
    //    {
    //        isWalking = true;
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(MoveD.x, 0, MoveD.z)), 0.3f);
    //    }
    //    animator.SetBool(nameof(isWalking), isWalking);
    //    cc.Move(MoveD * Time.deltaTime);
    //}
}
