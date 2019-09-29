using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ADM
{
    public class RotateToMouse : MonoBehaviour
    {
        public Camera cam;
        public float maximusLength;
        
        private Ray rayMouse;
        private Vector3 pos;
        private Vector3 diretion;
        Quaternion rotation; 


        // Update is called once per frame
        void Update()
        {
            if (cam != null)
            {
                RaycastHit hit;
                var mousePosition = Input.mousePosition;
                rayMouse = cam.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(rayMouse.origin , rayMouse.direction , out hit , maximusLength))
                {
                    RotateToMousePosition(gameObject , hit.point);
                }
                else
                {
                    var pos = rayMouse.GetPoint(maximusLength);
                    RotateToMousePosition(gameObject,pos);
                }
            }
        }

        void RotateToMousePosition(GameObject obj , Vector3 destination )
        {
            diretion = destination - obj.transform.position;
            rotation = Quaternion.LookRotation(diretion);
            obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation , rotation , 1);
        }

        public Quaternion GetRotation()
        {
            return rotation;
        }
    }
}

