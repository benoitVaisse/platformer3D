using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTrigger : MonoBehaviour
{
    [SerializeField]
    private bool _isInvinsible = false;

    public PlayerController playerController;
    public PlayerLifeSystem playerLifeSystem;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerLifeSystem = GetComponent<PlayerLifeSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        ITriggerHero triggerHero = other.GetComponent<ITriggerHero>();
        triggerHero?.Action(gameObject);

        ICameraManager cameraManager = other.GetComponent<ICameraManager>();
        cameraManager?.ActionEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        ICameraManager cameraManager = other.GetComponent<ICameraManager>();
        cameraManager?.ActionExit();
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!_isInvinsible)
        {
            IHitHero hitHero = hit.gameObject.GetComponent<IHitHero>();
            hitHero?.Action(gameObject);
        }

        ITouchedByHero touchedByHero = hit.gameObject.GetComponent<ITouchedByHero>();
        touchedByHero?.Action();
    }

    public void HittingDammage()
    {
        AddCoins(-1);
        ScriptManager.GetInstance().SetUIlife(playerLifeSystem.life--, false);
        if(playerLifeSystem.IsDead())
        {
            playerLifeSystem.Respawn();
            playerLifeSystem.life = 3;
            ScriptManager.GetInstance().InitHeart();
        }
        _isInvinsible = true;
        StartCoroutine(nameof(ResetInvinsible));

    }

    IEnumerator ResetInvinsible()
    {
        GameObject body = gameObject.transform.Find("Body").gameObject;
        SkinnedMeshRenderer s = body.GetComponent<SkinnedMeshRenderer>();
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(.2f);
            s.enabled = !s.enabled;
        }
        yield return new WaitForSeconds(.2f);
        s.enabled = true;
        _isInvinsible = false;
    }

    public void AddCoins(int number)
    {
        ScriptManager.GetInstance().SetNumberCoin(playerController.coins += number);
    }
}
