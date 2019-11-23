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

using UnityEngine.EventSystems;

namespace Game
{
    public class UIPanZone : MonoBehaviour, IPointerEnterHandler, IDragHandler, IPointerExitHandler
    {
        Vector2 delta;
        public Vector2 Delta => delta;

        [SerializeField]
        protected float gravity;
        public float Gravity { get { return gravity; } }

        int? PointerID;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (PointerID == null)
            {
                PointerID = eventData.pointerId;
                delta = Vector2.zero;
            }
            else
            {

            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(PointerID == eventData.pointerId)
            {
                delta = eventData.delta;
            }
        }

        private void LateUpdate()
        {
            delta = Vector2.MoveTowards(delta, Vector2.zero, gravity * Time.deltaTime);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(PointerID == eventData.pointerId)
            {
                PointerID = null;
            }
        }
    }
}