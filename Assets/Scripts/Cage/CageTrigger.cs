using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageTrigger : MonoBehaviour, ITriggerEnterHero, ITriggerExitHero
{
    private GameObject Buble;
    private bool CanFree = false;

    public void ActionEnter(GameObject hero)
    {
        ScriptManager.GetInstance().SetTextInfo("Appuyer sur E ...");
        CanFree = true;
    }

    public void ActionExit(GameObject hero)
    {
        ScriptManager.GetInstance().SetTextInfo(string.Empty);
        CanFree = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Buble = gameObject.transform.Find("ThxImage").gameObject;
        CanFree = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanFree) 
        {
            Buble.GetComponent<MeshRenderer>().enabled = true;
            iTween.ShakeScale(gameObject, new Vector3(150, 150, 150), 1f);
            Destroy(gameObject.GetComponent<MeshRenderer>(), 1.2f);
            Destroy(gameObject.GetComponent<BoxCollider>());

        }
    }

}
