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
	public class TriggerArea : MonoBehaviour
	{
        [SerializeField]
        protected ColliderUnitEvent triggerEnter;
        public ColliderUnitEvent TriggerEnter { get { return triggerEnter; } }
        private void OnTriggerEnter(Collider other)
        {
            triggerEnter.Invoke(other);
        }

        [SerializeField]
        protected ColliderUnitEvent triggerExit;
        public ColliderUnitEvent TriggerExit { get { return triggerExit; } }
        private void OnTriggerExit(Collider other)
        {
            triggerExit.Invoke(other);
        }
    }

    [Serializable]
    public class ColliderUnitEvent : UnityEvent<Collider>
    {

    }
}