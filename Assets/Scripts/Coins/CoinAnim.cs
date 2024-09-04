using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scripts.coins
{
    public class CoinAnim : MonoBehaviour
    {
        public Vector3 rotation = new(0, -125, 0);
        public Vector3 up = new(0,0,0);
        // Update is called once per frame
        void Update()
        {
            transform.Rotate(rotation * Time.deltaTime);
            transform.Translate(up* Time.deltaTime);
            //transform.Rotate(Vector3.up, 150 * Time.deltaTime);
        }
    }

}
