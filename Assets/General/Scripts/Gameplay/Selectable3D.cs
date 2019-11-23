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
using UnityEngine.EventSystems;

namespace Game
{
    public class Selectable3D : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        protected UnityEvent pointerClick;
        public UnityEvent PointerClick { get { return pointerClick; } }
        public void OnPointerClick(PointerEventData eventData)
        {
            pointerClick.Invoke();
        }
    }
}