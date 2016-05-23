using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour{

    public float rotationSpeed = 10f;
    public float speedBoost = 20;
   

    private string m_inputMovementAxisName;
    private string m_inputRotationAxisName;

    private float m_inputMovement;
    private float m_inputRotation;

    private Rigidbody m_rigidbody;

   
    // moves the Player frward based on input
    private void Move() {
        m_inputMovement = Input.GetAxis(m_inputMovementAxisName);
        Vector3 movement = transform.forward * speedBoost * m_inputMovement * Time.deltaTime;

        m_rigidbody.MovePosition(m_rigidbody.position + movement);

    }

  
    // rotates the Player based on the input
    private void Rotate(){
        m_inputRotation = Input.GetAxis(m_inputRotationAxisName);

        float turn = m_inputRotation * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_rigidbody.MoveRotation(m_rigidbody.rotation * turnRotation);

    }

    
    // updates the Input of the Player per Frame 
    void FixedUpdate(){
        Move();
        Rotate();
    }

    //sets up the input standards and the rigidbody
    public void Start()
    {
        m_inputMovementAxisName = "Vertical";
        m_inputRotationAxisName = "Horizontal";

        m_rigidbody = GetComponent<Rigidbody>();
    }

}