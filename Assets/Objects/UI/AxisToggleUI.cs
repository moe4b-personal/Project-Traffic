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
    public abstract class AxisToggleUI : MonoBehaviour
    {
        [SerializeField]
        protected Toggle positive;
        public Toggle Positive { get { return positive; } }

        [SerializeField]
        protected Toggle negative;
        public Toggle Negative { get { return negative; } }

        float _value = 0f;
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

        protected virtual void Start()
        {
            RegisterToggle(positive);
            RegisterToggle(negative);

            OnValueChange += ChangeCallback;
        }

        protected virtual void RegisterToggle(Toggle toggle)
        {
            void Callback(bool isOn) => OnChange(toggle, isOn);

            toggle.onValueChanged.AddListener(Callback);
        }

        protected abstract void ChangeCallback(float value);

        protected virtual void OnChange(Toggle toggle, bool isOn)
        {
            if (isOn)
            {
                if (toggle == positive)
                    Value = 1f;
                else if (toggle == negative)
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