using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
        #region Variables

        [Header("Input Variable Fields - Movement")]
        [SerializeField] int playerSpeed;

        Vector3 moveDirection;

        [Header("Input Variable Fields - Jumping")]
        [SerializeField] float jumpHeight;
        [SerializeField] private float groundDetectRayLength;
        [SerializeField] GameObject groundCheck;
        [SerializeField] LayerMask ground;
        [SerializeField] private bool canDoubleJump;
        [SerializeField] private int maxJumpAmount;
        [SerializeField] private float afterFirstJumpMultiplier;
        [SerializeField] private int timesJumped;

        [Header("Gravity")] 
        [SerializeField] private float gravityScale = 1f;
        public static float globalGravity = -9.81f; 
        
        bool jump;
        bool isGrounded;

        [Header("Player Variable Fields")]
        Rigidbody rb;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }

        void Update(){
            HandleMovementInput();
            HandleJumpInput();
            isGrounded = Physics.Raycast(groundCheck.transform.position, Vector3.down, groundDetectRayLength, ground);
        }

        void FixedUpdate() {
            Move();
            Gravity();
        }

        #endregion

        #region Private Methods

        private void Gravity()
        {
            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);
        }

        private void HandleMovementInput() {
                float moveX = Input.GetAxisRaw("Horizontal");
                float moveZ = Input.GetAxisRaw("Vertical");
                moveDirection = ((transform.forward * moveZ) + (transform.right * moveX)) * playerSpeed;
                moveDirection.y = rb.velocity.y;
                rb.velocity = moveDirection;
        }

        private void HandleJumpInput(){
            jump = Input.GetButtonDown("Jump");

            if (isGrounded)
            {
                canDoubleJump = true;
                timesJumped = 0;
            }
            
            if(jump && isGrounded) {
                Jump(jumpHeight);
                timesJumped++;
            }
            if (jump && !isGrounded && canDoubleJump && timesJumped < maxJumpAmount)
            {
                var height = jumpHeight * afterFirstJumpMultiplier;
                Jump(height);
                timesJumped++;
            }
            else if (timesJumped >= maxJumpAmount)
            {
                canDoubleJump = false;
            }
        }

        private void Move() {
            rb.velocity = moveDirection;
        }

        private void Jump(float height)
        {
            rb.AddForce(Vector3.up * height, ForceMode.Impulse);
            timesJumped++;
        }

        #endregion

        #region Public Methods



        #endregion
}
