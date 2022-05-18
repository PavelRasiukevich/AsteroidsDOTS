using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Root
{
    public class SpaceShipControlls : MonoBehaviour
    {
        public InputAction MoveAction;
        public InputAction RotationAction;
        public InputActionAsset InputActionAsset;
        public InputActionMap ActionMap;
        public MyControlls Controlls;


        private Vector2 moveVector;
        private Vector2 rotationVector;

        private void Awake()
        {
            Controlls = new MyControlls();
            
            InputActionAsset = Controlls.asset;

            ActionMap = InputActionAsset.FindActionMap("SpaceShip_AM");
                
            MoveAction = InputActionAsset.FindAction("Move");
            RotationAction = InputActionAsset.FindAction("Rotation");
        }

        private void OnEnable()
        {
            Controlls.Enable();
            MoveAction.performed += ReadValue;
            MoveAction.canceled += ZeroValue;

            RotationAction.performed += ReadValue2;
            RotationAction.canceled += ZeroValue2;
        }

        private void ZeroValue2(InputAction.CallbackContext obj)
        {
            rotationVector = Vector2.zero;
        }

        private void ReadValue2(InputAction.CallbackContext obj)
        {
            rotationVector = obj.ReadValue<Vector2>();
        }

        private void ZeroValue(InputAction.CallbackContext obj)
        {
            moveVector = Vector2.zero;
        }

        private void ReadValue(InputAction.CallbackContext obj)
        {
            moveVector = obj.ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            Controlls.Disable();
            MoveAction.performed -= ReadValue;
        }

        private void Update()
        {
            /*if (Keyboard.current.wKey.isPressed)
                transform.position += new Vector3(0, 0, 1) * (Time.deltaTime * 25.0f);*/

            transform.position += transform.forward * (moveVector.y * (Time.deltaTime * 25.0f));

            transform.rotation *= Quaternion.Euler(new Vector3(0, rotationVector.x, 0));
        }
    }
}