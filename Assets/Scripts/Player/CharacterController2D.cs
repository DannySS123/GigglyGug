using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour {
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)][SerializeField] private float m_CrouchSpeed = .36f;           // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
    [SerializeField] private Collider2D m_CrouchEnableCollider;                 // A collider that will be enabled when crouching

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;
    private bool didDoubleJump = false;

    private void Awake() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate() {
        checkGrounded();
        if (m_Grounded) {
            didDoubleJump = false;
        }
    }


    public void Move(float move, bool crouch, bool jump) {
        // If crouching, check to see if the character can stand up
        if (!crouch) {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround)) {
                crouch = true;
            }
        }
        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl) {
            if (crouch) {
                playerIsCrouching();
                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;
            }
            else playerIsNotCrouching();
            movePlayer(move);
            correctPlayerFacing(move);
        }
        if (m_Grounded && jump) {
            m_Grounded = true;
            doJump();
        } else if (jump && !didDoubleJump) {
            doJump();
            didDoubleJump = true;
        }
    }
    private void doJump() {
        m_Rigidbody2D.velocity = Vector2.up * m_JumpForce;
    }

    private void checkGrounded() {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject != gameObject) {
                m_Grounded = true;
                if (!wasGrounded) OnLandEvent.Invoke();
            }
        }
    }
    private void playerIsCrouching() {
        if (!m_wasCrouching) {
            m_wasCrouching = true;
            OnCrouchEvent.Invoke(true);
        }
        // Disable one of the colliders when crouching
        if (m_CrouchDisableCollider != null) {
            m_CrouchDisableCollider.enabled = false;
        }

        if (m_CrouchEnableCollider != null) {
            m_CrouchEnableCollider.enabled = true;
        }
    }
    private void playerIsNotCrouching() {
        // Enable the collider when not crouching
        if (m_CrouchDisableCollider != null) {
            m_CrouchDisableCollider.enabled = true;
        }

        if (m_CrouchEnableCollider != null) {
            m_CrouchEnableCollider.enabled = false;
        }

        if (m_wasCrouching) {
            m_wasCrouching = false;
            OnCrouchEvent.Invoke(false);
        }
    }
    private void movePlayer(float move) {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
    private void correctPlayerFacing(float move) {
        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight) {
            Flip(); // ... flip the player.
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight) {
            Flip(); // ... flip the player.
        }
    }
    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}