using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scripts.flowers
{
    public class FlowerAnim : MonoBehaviour
    {
        public Vector3 amount;
        void Start()
        {
            float time = Random.Range(1.5f, 2.5f);
            iTween.PunchScale(gameObject, iTween.Hash(
                "amount", amount,
                "time", time,
                "looptype", iTween.LoopType.loop
                ));
        }
    }

}
