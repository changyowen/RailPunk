using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Text survival_ins, creative_ins, mode;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float flySpeed = 30f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool SurvivalMode;

    // Start is called before the first frame update
    void Start()
    {
        SurvivalMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SurvivalMode = !SurvivalMode;
            ChangeInstruction();
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move * speed * Time.deltaTime);


        if (SurvivalMode == true)
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            //controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                float flyUp = Input.GetAxis("Jump");
                Vector3 fly = transform.up * flyUp;
                controller.Move(fly * flySpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                float flyUp = Input.GetAxis("Fire3");
                Vector3 fly = transform.up * -(flyUp);
                controller.Move(fly * flySpeed * Time.deltaTime);
            }
        }
    }

    void ChangeInstruction()
    {
        if(SurvivalMode == true)
        {
            survival_ins.gameObject.SetActive(true);
            creative_ins.gameObject.SetActive(false);
            mode.text = "Survival";
        }
        else
        {
            survival_ins.gameObject.SetActive(false);
            creative_ins.gameObject.SetActive(true);
            mode.text = "Creative";
        }
    }
}
