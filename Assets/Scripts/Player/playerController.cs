using Gun;
using System;
using System.Diagnostics;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class playerController : MonoBehaviour
    {
        public Rigidbody rb;
        public bool inMenu;
        public Inputmanager inputManager;
        public UIManager uiManager;

        [Header("Movement Values")]
        [Tooltip("The walking speed of the player")] public float walkSpeed;
        [Tooltip("The running speed of the player")] public float runspeed;
        [Tooltip("The acceleration of the player when moving")] public float accel;
        [Tooltip("The force added to the player when jumping")]public int jumpforce;
        float currentRunspeed;
        bool isGrounded;
        float speed;

        [Header("Crouching values")]
        [Tooltip("Allows the player to crouch")]public bool canCrouch;
        [ConditionalHide("canCrouch")][Tooltip("The heigt of the player when crouching 1 is normal hieght")]public float crouchHeight;
        private float normalHeight;

        [Header("Leaning values")]
        [Tooltip("Allows the player to lean")]public bool canLean;
        [ConditionalHide("canLean")][Tooltip("The speed you lean at")]public float leanSpeed;
        [ConditionalHide("canLean")][Tooltip("The distance you lean to the side")]public float leanDistance;
        [ConditionalHide("canLean")][Tooltip("The height of the camera when you lean")]public float leanHight;
        [ConditionalHide("canLean")][Tooltip("The amount the camera rotates leave 0 if you dont want to rotate the camera when leaning")]public float leanAngle;
        private Vector3 targetLeanPos;
        private float currentLeanAngle;
        private float targetLeanAngle;
        private float leanInput;
        private float baseHight;

        [Header("Camera sensetivity")]
        [Tooltip("The sensetivity of the camera")]public float sensetivity;
        public Transform cam;
        private float xRotation = 0;
        public RaycastHit hit;

        private void Start()
        {
            inputManager.inputMaster.Movement.Jump.started += _ => Jump();
            uiManager = UIManager.InstanceUI;
            cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
            baseHight = cam.transform.localPosition.y;
            normalHeight = GetComponent<CapsuleCollider>().height;
        }
        
        private void Update()
        {
            float forwardBackward = inputManager.inputMaster.Movement.ForwardBackward.ReadValue<float>();
            float leftRight = inputManager.inputMaster.Movement.RightLeft.ReadValue<float>();
            Vector3 move = transform.right * leftRight  + transform.forward * forwardBackward;

            /*if (!inMenu)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;*/

            if (speed <= walkSpeed && forwardBackward != 0 | leftRight != 0)
            {
                speed += accel;
            }
            else if (speed >= 0)
            {
                speed -= accel;
            }

            if (currentRunspeed <= runspeed && inputManager.inputMaster.Movement.Sprint.ReadValue<float>() == 1 && forwardBackward != 0 | leftRight != 0)
            {
                currentRunspeed += accel * 2;
            }
            else if (currentRunspeed >= 0)
            {
                currentRunspeed -= accel;
            }

            move *= inputManager.inputMaster.Movement.Sprint.ReadValue<float>() == 0 ? speed : currentRunspeed;

            rb.velocity = new Vector3(move.x,rb.velocity.y, move.z);

            Vector2 mouseV2 = inputManager.inputMaster.CameraMovement.MouseX.ReadValue<Vector2>() * sensetivity * Time.deltaTime;

            xRotation -= mouseV2.y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseV2.x);

            if (canLean && inputManager.inputMaster.Leaning.LeanLeft.ReadValue<float>() == 1)
            {
                if (!Physics.Raycast(transform.position, transform.right, out hit, 1))
                {
                    if (hit.transform == null)
                    {
                        targetLeanPos.x = -leanDistance;
                        targetLeanPos.y = leanHight;
                        leanInput = 1f;
                        Leaning();
                    }
                }
                else
                {
                    targetLeanPos.x = 0;
                    targetLeanPos.y = baseHight;
                    leanInput = 0f;
                    Leaning();
                }
            }
            else if (canLean && inputManager.inputMaster.Leaning.LeanRight.ReadValue<float>() == 1)
            {
                if (!Physics.Raycast(transform.position, transform.right, out hit, 1))
                {
                    if (hit.transform == null)
                    {
                        targetLeanPos.x = leanDistance;
                        targetLeanPos.y = leanHight;
                        leanInput = -1f;
                        Leaning();
                    }
                }
                else
                {
                    targetLeanPos.x = 0;
                    targetLeanPos.y = baseHight;
                    leanInput = 0f;
                    Leaning();
                }
            }
            else
            {
                targetLeanPos.x = 0;
                targetLeanPos.y = baseHight;
                leanInput = 0f;
                Leaning();
            }

            if (canCrouch && inputManager.inputMaster.Movement.Crouch.ReadValue<float>() == 1)
            {
                float newHeight = Mathf.Lerp(GetComponent<CapsuleCollider>().height, crouchHeight, Time.deltaTime * leanSpeed);
                GetComponent<CapsuleCollider>().height = newHeight;
            }
            else
            {
                float newHeight = Mathf.Lerp(GetComponent<CapsuleCollider>().height, normalHeight, Time.deltaTime * leanSpeed);
                GetComponent<CapsuleCollider>().height = newHeight;
            }

            if(Input.GetKeyDown(KeyCode.Escape)) 
            {
                if(!inMenu)
                {
                    uiManager.pauzeMenu.SetActive(true);
                    inMenu = true;
                }
                else
                {
                    uiManager.pauzeMenu.SetActive(false);
                    inMenu = false;

                }
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }

        void Jump()
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpforce);
            }
        }

        void Leaning()
        {
            targetLeanAngle = leanInput * leanAngle;
            currentLeanAngle = Mathf.Lerp(currentLeanAngle, targetLeanAngle, Time.deltaTime * leanSpeed);

            cam.localRotation = Quaternion.Euler(xRotation, cam.localRotation.y, currentLeanAngle);
            cam.localPosition = Vector3.Lerp(cam.localPosition, targetLeanPos, Time.deltaTime * leanSpeed);

        }
    }
}
