using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHero : MonoBehaviour, IHitHero
{
    public void Action(GameObject hero)
    {
        Debug.Log("touch�");
        hero.GetComponent<PlayerControllerTrigger>().HittingDammage();
    }
}
