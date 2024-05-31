using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Transform cameraEye;
    private float ySpeed;
    private float vertical;
    private float horizontal;
    private CharacterController cc;
    private Animator anim;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetAxis();
        Move();
        Direction();
        Animations();
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = cameraEye.position;
    }

    private void GetAxis()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        Vector3 moveDir = transform.TransformDirection(Vector3.right) * horizontal + transform.TransformDirection(Vector3.forward) * vertical;
        float magnitude = Mathf.Clamp01(moveDir.magnitude) * speed;
        moveDir.Normalize();

        var velocity = moveDir * magnitude;
        velocity.y = ySpeed;

        cc.Move(velocity * Time.deltaTime);

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                ySpeed = jumpSpeed;
        }
    }

    private void Direction()
    {
        transform.localEulerAngles = Vector3.up * Mathf.LerpAngle(transform.localEulerAngles.y, Camera.main.transform.localEulerAngles.y, 5 * Time.deltaTime);
    }

    private void Animations()
    {
        anim.SetFloat("Vertical", vertical);
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Move", (Mathf.Abs(vertical) + Mathf.Abs(horizontal)) / 2);
    }
}
