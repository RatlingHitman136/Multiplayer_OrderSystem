// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PLayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PLayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PLayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PLayerControl"",
    ""maps"": [
        {
            ""name"": ""MainControl"",
            ""id"": ""0dde480f-3ca0-4a28-8ac1-ee2dba13b1eb"",
            ""actions"": [
                {
                    ""name"": ""SetOrder"",
                    ""type"": ""Button"",
                    ""id"": ""7a2fe0fa-417d-4245-a138-1328c41076e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectUnit"",
                    ""type"": ""Button"",
                    ""id"": ""336dd152-71e9-4bb6-ae0d-dbdf70bed3dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""f9570336-cee2-491f-9590-bd1f763fef0f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f6da213c-4ef2-4014-abd2-94e99a3485b8"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyBorad and Mouse"",
                    ""action"": ""SetOrder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6c4fe4a-ebcc-4229-b72f-fe19b8f5917b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyBorad and Mouse"",
                    ""action"": ""SelectUnit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3c1ce6a-9e7d-49f5-aa34-ed166ea1a06b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBorad and Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Preperation"",
            ""id"": ""fe9eb65b-fc80-4daa-9223-8d7c39e0f2d6"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""Menu"",
            ""id"": ""50bf5680-da76-44f6-81ca-f4cc15970dd2"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBorad and Mouse"",
            ""bindingGroup"": ""KeyBorad and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MainControl
        m_MainControl = asset.FindActionMap("MainControl", throwIfNotFound: true);
        m_MainControl_SetOrder = m_MainControl.FindAction("SetOrder", throwIfNotFound: true);
        m_MainControl_SelectUnit = m_MainControl.FindAction("SelectUnit", throwIfNotFound: true);
        m_MainControl_MousePosition = m_MainControl.FindAction("MousePosition", throwIfNotFound: true);
        // Preperation
        m_Preperation = asset.FindActionMap("Preperation", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
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

    // MainControl
    private readonly InputActionMap m_MainControl;
    private IMainControlActions m_MainControlActionsCallbackInterface;
    private readonly InputAction m_MainControl_SetOrder;
    private readonly InputAction m_MainControl_SelectUnit;
    private readonly InputAction m_MainControl_MousePosition;
    public struct MainControlActions
    {
        private @PLayerControl m_Wrapper;
        public MainControlActions(@PLayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @SetOrder => m_Wrapper.m_MainControl_SetOrder;
        public InputAction @SelectUnit => m_Wrapper.m_MainControl_SelectUnit;
        public InputAction @MousePosition => m_Wrapper.m_MainControl_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_MainControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainControlActions set) { return set.Get(); }
        public void SetCallbacks(IMainControlActions instance)
        {
            if (m_Wrapper.m_MainControlActionsCallbackInterface != null)
            {
                @SetOrder.started -= m_Wrapper.m_MainControlActionsCallbackInterface.OnSetOrder;
                @SetOrder.performed -= m_Wrapper.m_MainControlActionsCallbackInterface.OnSetOrder;
                @SetOrder.canceled -= m_Wrapper.m_MainControlActionsCallbackInterface.OnSetOrder;
                @SelectUnit.started -= m_Wrapper.m_MainControlActionsCallbackInterface.OnSelectUnit;
                @SelectUnit.performed -= m_Wrapper.m_MainControlActionsCallbackInterface.OnSelectUnit;
                @SelectUnit.canceled -= m_Wrapper.m_MainControlActionsCallbackInterface.OnSelectUnit;
                @MousePosition.started -= m_Wrapper.m_MainControlActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MainControlActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MainControlActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_MainControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SetOrder.started += instance.OnSetOrder;
                @SetOrder.performed += instance.OnSetOrder;
                @SetOrder.canceled += instance.OnSetOrder;
                @SelectUnit.started += instance.OnSelectUnit;
                @SelectUnit.performed += instance.OnSelectUnit;
                @SelectUnit.canceled += instance.OnSelectUnit;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public MainControlActions @MainControl => new MainControlActions(this);

    // Preperation
    private readonly InputActionMap m_Preperation;
    private IPreperationActions m_PreperationActionsCallbackInterface;
    public struct PreperationActions
    {
        private @PLayerControl m_Wrapper;
        public PreperationActions(@PLayerControl wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Preperation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PreperationActions set) { return set.Get(); }
        public void SetCallbacks(IPreperationActions instance)
        {
            if (m_Wrapper.m_PreperationActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_PreperationActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public PreperationActions @Preperation => new PreperationActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    public struct MenuActions
    {
        private @PLayerControl m_Wrapper;
        public MenuActions(@PLayerControl wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyBoradandMouseSchemeIndex = -1;
    public InputControlScheme KeyBoradandMouseScheme
    {
        get
        {
            if (m_KeyBoradandMouseSchemeIndex == -1) m_KeyBoradandMouseSchemeIndex = asset.FindControlSchemeIndex("KeyBorad and Mouse");
            return asset.controlSchemes[m_KeyBoradandMouseSchemeIndex];
        }
    }
    public interface IMainControlActions
    {
        void OnSetOrder(InputAction.CallbackContext context);
        void OnSelectUnit(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IPreperationActions
    {
    }
    public interface IMenuActions
    {
    }
}
