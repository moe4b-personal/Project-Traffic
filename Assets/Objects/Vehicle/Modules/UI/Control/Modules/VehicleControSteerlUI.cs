using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game
{
	public class VehicleControSteerlUI : MonoBehaviour, IReference<Vehicle>
	{
		[SerializeField]
        protected Toggle right;
        public Toggle Right { get { return right; } }

        [SerializeField]
        protected Toggle left;
        public Toggle Left { get { return left; } }

        float _value;
        public float Value
        {
            get => _value;
            set
            {
                _value = value;

                OnValueChange?.Invoke(Value);
            }
        }
        public delegate void ValueChangeDelegate(float value);
        public event ValueChangeDelegate OnValueChange;

        public Vehicle Vehicle { get; protected set; }
        public void Set(Vehicle reference) => Vehicle = reference;

        private void Awake()
        {
            Value = 0f;
        }

        private void Start()
        {
            RegisterToggle(right);
            RegisterToggle(left);

            OnValueChange += ChangeCallback;
        }

        void RegisterToggle(Toggle toggle)
        {
            void Callback(bool isOn) => OnChange(toggle, isOn);

            toggle.onValueChanged.AddListener(Callback);
        }

        private void ChangeCallback(float value)
        {
            Vehicle.Wheels.Steer.Target = value;

            Vehicle.Engine.Torque.Scale = value;
        }

        void OnChange(Toggle toggle, bool isOn)
        {
            if (isOn)
            {
                if (toggle == right)
                    Value = 1f;
                else if (toggle == left)
                    Value = -1f;
                else
                    Value = 0f;
            }
            else
            {
                Value = 0f;
            }
        }
    }
}