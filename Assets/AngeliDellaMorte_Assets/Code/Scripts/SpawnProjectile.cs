using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ADM
{
    public class SpawnProjectile : MonoBehaviour
    {
        public GameObject firePoint;
        public List<GameObject> vfx = new List<GameObject>();
        GameObject effectToSpawn;
        public RotateToMouse rotateToMouse;
        public float timeToFire = 0f;
        void Start()
        {
            effectToSpawn = vfx[0];
        }

        // Update is called once per frame
        void Update()
        {
            instantiatingVfX();
        }

        void instantiatingVfX()
        {
           
            if (Input.GetKey(KeyCode.N) && Time.time >= timeToFire)
            {
                timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectilePath>().fireRate;
                GameObject obj;
                if (firePoint != null)
                {
                    obj = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
                    if (rotateToMouse != null )
                    {
                        obj.transform.localRotation = rotateToMouse.GetRotation();
                    }
                }
                else
                {
                    Debug.Log("no fire point");
                }
            }

        }
    }

}
