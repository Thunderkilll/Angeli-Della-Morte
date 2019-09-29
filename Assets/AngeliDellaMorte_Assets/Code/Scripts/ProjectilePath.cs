using System;
using System.Collections.Generic;
using UnityEngine;

namespace ADM
{
    class ProjectilePath : MonoBehaviour
    {
        public float speed = 0f;
        public float fireRate = 1f;
        //public float damage = 0f;

        void Update()
        {
            if (speed != 0)
            {
                transform.position += transform.right* -1 * (speed * Time.deltaTime);
            }
           
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "LevelPart")
            {
                speed = 0f;
                Destroy(gameObject);
            }
               
             
        }

    }
}
