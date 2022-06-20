// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using System;

namespace Microsoft.MixedReality.Toolkit.Experimental.Joystick
{
    /// <summary>
    /// Example script to demonstrate joystick control in sample scene
    /// </summary>
    public class CraneJoystick : MonoBehaviour
    {
        [Experimental]
        [SerializeField, FormerlySerializedAs("objectToManipulate")]
        [Tooltip("The large or small game object that receives manipulation by the joystick.")]
        public GameObject Bridge;
        public GameObject Trolley;

        [SerializeField]
        [Tooltip("A TextMeshPro object that displays joystick values.")]
        public TextMeshPro CraneBridgeLocText = null;
        public TextMeshPro CraneTrolleyLocText = null;

        [SerializeField]
        [Tooltip("The joystick mesh that gets rotated when this control is interacted with.")]
        private GameObject joystickVisual = null;

        [SerializeField]
        [Tooltip("The mesh + collider object that gets dragged and controls the joystick visual rotation.")]
        private GameObject grabberVisual = null;

        [SerializeField]
        [Tooltip("Toggles on / off the GrabberVisual's mesh renderer because it can be dragged away from the joystick visual, it kind of breaks the illusion of pushing / pulling a lever.")]
        private bool showGrabberVisual = true;

        [Tooltip("The speed at which the JoystickVisual and GrabberVisual move / rotate back to a neutral position.")]
        [Range(1, 20)]
        public float ReboundSpeed = 5;

        [Tooltip("How sensitive the joystick reacts to dragging left / right. Customize this value to get the right feel for your scenario.")]
        [Range(0.01f, 10)]
        public float SensitivityLeftRight = 3;

        [Tooltip("How sensitive the joystick reacts to pushing / pulling. Customize this value to get the right feel for your scenario.")]
        [Range(0.01f, 10)]
        public float SensitivityForwardBack = 6;

        [SerializeField]
        [Tooltip("The property that the joystick manipulates.")]
        private JoystickMode mode = JoystickMode.Move;

        public JoystickMode Mode
        {
            get => mode;
            set => mode = value;
        }

        [Tooltip("The distance multiplier for joystick input. Customize this value to get the right feel for your scenario.")]
        [Range(1f, 150f)]
        public float MoveSpeed = 150;

        [Tooltip("The rotation multiplier for joystick input. Customize this value to get the right feel for your scenario.")]
        [Range(0.01f, 1f)]
        public float RotationSpeed = 0.05f;

        [Tooltip("The scale multiplier for joystick input. Customize this value to get the right feel for your scenario.")]
        [Range(0.00003f, 0.003f)]
        public float ScaleSpeed = 0.001f;

        private Vector3 startPosition;
        private Vector3 joystickGrabberPosition;
        private Vector3 joystickVisualRotation;
        private const int joystickVisualMaxRotation = 80;
        private bool isDragging = false;
        private void Start()
        {
            startPosition = grabberVisual.transform.localPosition;
            if (grabberVisual != null)
            {
                grabberVisual.GetComponent<MeshRenderer>().enabled = showGrabberVisual;
            }
        }

        private void Update()
        {
            if (!isDragging)
            {
                // when dragging stops, move joystick back to idle
                if (grabberVisual != null)
                {
                    grabberVisual.transform.localPosition = Vector3.Lerp(grabberVisual.transform.localPosition, startPosition, Time.deltaTime * ReboundSpeed);
                }
            }
            CalculateJoystickRotation();
            ApplyJoystickValues();

        }

        private void CalculateJoystickRotation()
        {
            joystickGrabberPosition = grabberVisual.transform.localPosition - startPosition;
            // Left Right = Horizontal
            joystickVisualRotation.z = Mathf.Clamp(-joystickGrabberPosition.x * SensitivityLeftRight, -joystickVisualMaxRotation, joystickVisualMaxRotation);
            // Forward Back = Vertical
            joystickVisualRotation.x = Mathf.Clamp(joystickGrabberPosition.z * SensitivityForwardBack, -joystickVisualMaxRotation, joystickVisualMaxRotation);
            // TODO: calculate joystickVisualRotation.y to always face the proper direction (for when the joystick container gets moved around the scene)
            if (joystickVisual != null)
            {
                joystickVisual.transform.localRotation = Quaternion.Euler(joystickVisualRotation);
            }
        }

        

        private void ApplyJoystickValues()
        {
                if (Mode == JoystickMode.Move)
                {
                    var BridgeMove = new Vector3(-joystickGrabberPosition.z * MoveSpeed, 0,0 );
                    var TrolleyMove = new Vector3(0, 0, joystickGrabberPosition.x * MoveSpeed);
                    Bridge.transform.localPosition+= BridgeMove;
                    Trolley.transform.localPosition += TrolleyMove;
                if (CraneBridgeLocText != null)
                    {
                    CraneBridgeLocText.text = (Math.Round(Bridge.transform.localPosition.x) + 9700).ToString();
                    CraneTrolleyLocText.text = (Math.Round(Trolley.transform.localPosition.z) + 4650).ToString();
                }
                    
                }
                
        }
        /// <summary>
        /// The ObjectManipulator script uses this to determine when the joystick is grabbed.
        /// </summary>
        public void StartDrag()
        {
            isDragging = true;
        }
        /// <summary>
        /// The ObjectManipulator script uses this to determine when the joystick is released.
        /// </summary>
        public void StopDrag()
        {
            isDragging = false;
        }
        /// <summary>
        /// Set the joystick mode from a UI button.
        /// </summary>
        public void JoystickModeMove()
        {
            Mode = JoystickMode.Move;
        }
        /// <summary>
        /// Set the joystick mode from a UI button.
        /// </summary>
        public void JoystickModeRotate()
        {
            Mode = JoystickMode.Rotate;
        }
        /// <summary>
        /// Set the joystick mode from a UI button.
        /// </summary>
        public void JoystickModeScale()
        {
            Mode = JoystickMode.Scale;
        }
    }
}
