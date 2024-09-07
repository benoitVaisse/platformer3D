using scripts.coins;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace scripts.checkPoint
{
    public class CheckPoint : MonoBehaviour, ITriggerHero
    {
        private bool _isTouched = false;
        public void Action(GameObject hero)
        {
            Debug.Log("checpoint");
            hero.GetComponent<PlayerLifeSystem>().SetRespawnPosition(transform.position);
            if(!_isTouched) 
                StartCoroutine(nameof(ActionTouched));
        }

        private IEnumerator ActionTouched()
        {
            _isTouched = true;
            Animator animator = GetComponent<Animator>();
            animator.enabled = true;
            yield return new WaitForSeconds(2f);
            animator.enabled = false;
            _isTouched = false;
        }
    }

}
