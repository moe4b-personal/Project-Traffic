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
		public Vehicle[] List { get; protected set; }

        private void Awake()
        {
            List = FindObjectsOfType<Vehicle>();
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
        public class ClickEvent : UnityEvent<Vehicle>
        {

        }
        void ClickCallback(Vehicle car)
        {
            onClick.Invoke(car);

            //car.rigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            var position = car.transform.position;
            position.y = 1;
            car.transform.position = position;
        }
    }
}