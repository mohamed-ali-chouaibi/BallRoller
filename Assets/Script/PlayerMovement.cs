using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float forwardForce = 500f;
    public float lateralForce = 15f;
    public float targetSpeed = 100f;
    public float maxLateralPos = 3f;
    private Rigidbody rb;
    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        ForwardMovement();

        LateralMovement();
    }

    void ForwardMovement(){
        float currentSpeed = rb.linearVelocity.z;
        if (currentSpeed < targetSpeed){
            rb.AddForce(Vector3.forward * forwardForce * Time.deltaTime, ForceMode.Force);
        }else if(currentSpeed > targetSpeed ){
            Vector3 clampedVelocity = rb.linearVelocity;
            clampedVelocity.z = targetSpeed;
            rb.linearVelocity = clampedVelocity;
        }
    }

    void LateralMovement(){
        float direction = Input.GetAxis("Horizontal");

        Vector3 lateralVelocity = rb.linearVelocity;
        lateralVelocity.x = direction * lateralForce;
        rb.linearVelocity = lateralVelocity;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxLateralPos, maxLateralPos);
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Obstacle")){
            GameStateManager.instance.ChangeToGameOver();
            AudioManager.instance.PlaySFX(AudioManager.instance.destroyClip);
        }
    }
}
