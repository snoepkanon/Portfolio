// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""2e050e8d-faca-41c9-a39f-6615ceda7dc5"",
            ""actions"": [
                {
                    ""name"": ""Forward / Backward"",
                    ""type"": ""Value"",
                    ""id"": ""7a945d9f-befe-4527-bb1a-0c5e4d796243"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right / Left"",
                    ""type"": ""Button"",
                    ""id"": ""e2a33453-e32e-47e1-8c73-4f57c06a3430"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5955664a-a73b-424b-ae30-9679f39e0532"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Value"",
                    ""id"": ""e4c30007-3c90-4dd6-bfde-13dbf641183a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Value"",
                    ""id"": ""400da329-eff1-46fb-8bb2-695817e3f471"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""811a35ee-c3cd-4081-85ee-8fd530b5784b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward / Backward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0a5ca5cc-b230-4da1-8407-3535008d4379"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward / Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d82a8282-ab96-47dd-937c-a6fe44511f69"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward / Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""0a9d4bf5-9cca-45a5-8124-2db77bede7ac"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right / Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2f32312b-0d3b-4ef6-a9ce-22983802b05d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right / Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5d2c380c-5451-48fc-ad6b-fbd4b9d0e87e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right / Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ff49bc33-f2e1-481f-a8d3-2669948af119"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fbba766-b6fc-4fa8-9309-b47cfca091b5"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bafcb29-f6b6-4ef5-b15d-76346f7af8a2"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CameraMovement"",
            ""id"": ""1f75c239-d6c3-40c7-b8b2-4cabc26dd91f"",
            ""actions"": [
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9e7d4381-0790-495c-8473-4adbbe2e7393"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6c7bf175-212c-4dde-9dbe-054ea87cf7e4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Leaning"",
            ""id"": ""f273ed68-53c1-46f5-a86e-59ae866bb68a"",
            ""actions"": [
                {
                    ""name"": ""LeanLeft"",
                    ""type"": ""Button"",
                    ""id"": ""5a2e52c2-a1eb-48a2-9915-eb3e36ad098f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeanRight"",
                    ""type"": ""Button"",
                    ""id"": ""ecd3e44d-a6d1-485e-9c31-4a6cfe6c2be1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e704d0f1-c56c-42a9-91cb-0c5d3599d71a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeanLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""369226af-1945-4e6a-ad28-9c7e449e210c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeanRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shooting"",
            ""id"": ""7833f7ab-375b-4acf-9a3a-d7f695ced83c"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""7ce76d4c-20a1-46ce-ac0b-2e91c07852fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5fc36a45-b4e8-4c97-b6dc-144c1b87ae6c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_ForwardBackward = m_Movement.FindAction("Forward / Backward", throwIfNotFound: true);
        m_Movement_RightLeft = m_Movement.FindAction("Right / Left", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Sprint = m_Movement.FindAction("Sprint", throwIfNotFound: true);
        m_Movement_Crouch = m_Movement.FindAction("Crouch", throwIfNotFound: true);
        // CameraMovement
        m_CameraMovement = asset.FindActionMap("CameraMovement", throwIfNotFound: true);
        m_CameraMovement_MouseX = m_CameraMovement.FindAction("MouseX", throwIfNotFound: true);
        // Leaning
        m_Leaning = asset.FindActionMap("Leaning", throwIfNotFound: true);
        m_Leaning_LeanLeft = m_Leaning.FindAction("LeanLeft", throwIfNotFound: true);
        m_Leaning_LeanRight = m_Leaning.FindAction("LeanRight", throwIfNotFound: true);
        // Shooting
        m_Shooting = asset.FindActionMap("Shooting", throwIfNotFound: true);
        m_Shooting_Fire = m_Shooting.FindAction("Fire", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_ForwardBackward;
    private readonly InputAction m_Movement_RightLeft;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Sprint;
    private readonly InputAction m_Movement_Crouch;
    public struct MovementActions
    {
        private @InputMaster m_Wrapper;
        public MovementActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ForwardBackward => m_Wrapper.m_Movement_ForwardBackward;
        public InputAction @RightLeft => m_Wrapper.m_Movement_RightLeft;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Sprint => m_Wrapper.m_Movement_Sprint;
        public InputAction @Crouch => m_Wrapper.m_Movement_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @ForwardBackward.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardBackward;
                @ForwardBackward.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardBackward;
                @ForwardBackward.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardBackward;
                @RightLeft.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightLeft;
                @RightLeft.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightLeft;
                @RightLeft.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightLeft;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Crouch.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ForwardBackward.started += instance.OnForwardBackward;
                @ForwardBackward.performed += instance.OnForwardBackward;
                @ForwardBackward.canceled += instance.OnForwardBackward;
                @RightLeft.started += instance.OnRightLeft;
                @RightLeft.performed += instance.OnRightLeft;
                @RightLeft.canceled += instance.OnRightLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // CameraMovement
    private readonly InputActionMap m_CameraMovement;
    private ICameraMovementActions m_CameraMovementActionsCallbackInterface;
    private readonly InputAction m_CameraMovement_MouseX;
    public struct CameraMovementActions
    {
        private @InputMaster m_Wrapper;
        public CameraMovementActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseX => m_Wrapper.m_CameraMovement_MouseX;
        public InputActionMap Get() { return m_Wrapper.m_CameraMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraMovementActions set) { return set.Get(); }
        public void SetCallbacks(ICameraMovementActions instance)
        {
            if (m_Wrapper.m_CameraMovementActionsCallbackInterface != null)
            {
                @MouseX.started -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMouseX;
            }
            m_Wrapper.m_CameraMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
            }
        }
    }
    public CameraMovementActions @CameraMovement => new CameraMovementActions(this);

    // Leaning
    private readonly InputActionMap m_Leaning;
    private ILeaningActions m_LeaningActionsCallbackInterface;
    private readonly InputAction m_Leaning_LeanLeft;
    private readonly InputAction m_Leaning_LeanRight;
    public struct LeaningActions
    {
        private @InputMaster m_Wrapper;
        public LeaningActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeanLeft => m_Wrapper.m_Leaning_LeanLeft;
        public InputAction @LeanRight => m_Wrapper.m_Leaning_LeanRight;
        public InputActionMap Get() { return m_Wrapper.m_Leaning; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LeaningActions set) { return set.Get(); }
        public void SetCallbacks(ILeaningActions instance)
        {
            if (m_Wrapper.m_LeaningActionsCallbackInterface != null)
            {
                @LeanLeft.started -= m_Wrapper.m_LeaningActionsCallbackInterface.OnLeanLeft;
                @LeanLeft.performed -= m_Wrapper.m_LeaningActionsCallbackInterface.OnLeanLeft;
                @LeanLeft.canceled -= m_Wrapper.m_LeaningActionsCallbackInterface.OnLeanLeft;
                @LeanRight.started -= m_Wrapper.m_LeaningActionsCallbackInterface.OnLeanRight;
                @LeanRight.performed -= m_Wrapper.m_LeaningActionsCallbackInterface.OnLeanRight;
                @LeanRight.canceled -= m_Wrapper.m_LeaningActionsCallbackInterface.OnLeanRight;
            }
            m_Wrapper.m_LeaningActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeanLeft.started += instance.OnLeanLeft;
                @LeanLeft.performed += instance.OnLeanLeft;
                @LeanLeft.canceled += instance.OnLeanLeft;
                @LeanRight.started += instance.OnLeanRight;
                @LeanRight.performed += instance.OnLeanRight;
                @LeanRight.canceled += instance.OnLeanRight;
            }
        }
    }
    public LeaningActions @Leaning => new LeaningActions(this);

    // Shooting
    private readonly InputActionMap m_Shooting;
    private IShootingActions m_ShootingActionsCallbackInterface;
    private readonly InputAction m_Shooting_Fire;
    public struct ShootingActions
    {
        private @InputMaster m_Wrapper;
        public ShootingActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Shooting_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Shooting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootingActions set) { return set.Get(); }
        public void SetCallbacks(IShootingActions instance)
        {
            if (m_Wrapper.m_ShootingActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_ShootingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public ShootingActions @Shooting => new ShootingActions(this);
    public interface IMovementActions
    {
        void OnForwardBackward(InputAction.CallbackContext context);
        void OnRightLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface ICameraMovementActions
    {
        void OnMouseX(InputAction.CallbackContext context);
    }
    public interface ILeaningActions
    {
        void OnLeanLeft(InputAction.CallbackContext context);
        void OnLeanRight(InputAction.CallbackContext context);
    }
    public interface IShootingActions
    {
        void OnFire(InputAction.CallbackContext context);
    }
}
