using Unity.Mathematics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float rotSpeed = 90f; 
    private Animator anim;
    private CharacterController controller;
    private float blendValue = 0f;  

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();  
    }

    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");

        
        float z = Input.GetAxis("Vertical");

        
        transform.Rotate(0, x * rotSpeed * Time.deltaTime, 0);

        
        Vector3 move = transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        
        if (!controller.isGrounded)
        {
            controller.Move(Vector3.down * 9.81f * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.E))
        {
            blendValue += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            blendValue -= Time.deltaTime;
        }

        blendValue = Mathf.Clamp(blendValue, 0f, 1f);
        anim.SetFloat("Blend", blendValue);
    }
}