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

using UnityEngine.Events;

namespace Game
{
	public class LevelCars : MonoBehaviour
	{
		public Car[] List { get; protected set; }

        private void Awake()
        {
            List = FindObjectsOfType<Car>();
        }

        private void Start()
        {
            foreach (var car in List)
            {
                car.Selectable.PointerClick.AddListener(() => ClickCallback(car));
            }
        }

        [SerializeField]
        protected ClickEvent onClick;
        public ClickEvent OnClick { get { return onClick; } }
        [Serializable]
        public class ClickEvent : UnityEvent<Car>
        {

        }
        void ClickCallback(Car car)
        {
            onClick.Invoke(car);
        }
    }
}