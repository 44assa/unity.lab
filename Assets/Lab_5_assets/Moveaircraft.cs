using UnityEngine;

public class MoveAircraft : MonoBehaviour
{
    private Rigidbody Rigidbodyrb;
    public float Speed = 50.0f; 
    public float RotationSpeed = 2.0f; 
    public float MaxHoverHeight = 1.0f; 
    public float HoverForce = 500.0f;   
    public float HoverDampening = 5.0f; 

    public float VerticalControlSpeed = 100.0f; 
    public KeyCode UpKey = KeyCode.Space;       
    public KeyCode DownKey = KeyCode.LeftControl; 

    void Start()
    {
        Rigidbodyrb = GetComponent<Rigidbody>();
        Rigidbodyrb.isKinematic = false;
        Rigidbodyrb.useGravity = true;
        Rigidbodyrb.linearDamping = 1f;
        Rigidbodyrb.angularDamping = 1f;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Rigidbodyrb.AddRelativeForce(0f, 0f, verticalInput * Speed);
        Rigidbodyrb.AddRelativeTorque(0f, horizontalInput * RotationSpeed, 0f);
        float hoverCurrentForce = 0f; 

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, MaxHoverHeight * 2f))
        {
            float currentHeight = hit.distance;
            float heightDifference = MaxHoverHeight - currentHeight;

            hoverCurrentForce = heightDifference * HoverForce;
        }

        if (Input.GetKey(UpKey))
        {
            hoverCurrentForce += VerticalControlSpeed;
        }
        if (Input.GetKey(DownKey))
        {
            hoverCurrentForce -= VerticalControlSpeed;
        }

        Rigidbodyrb.AddRelativeForce(0f, hoverCurrentForce, 0f);

        Rigidbodyrb.AddRelativeForce(0f, -Rigidbodyrb.linearVelocity.y * HoverDampening, 0f);
    }
}