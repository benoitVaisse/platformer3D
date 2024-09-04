using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, ICameraManager
{
    [SerializeField]
    private GameObject cameraScene;
    public void ActionEnter()
    {
        cameraScene.SetActive(true);
    }

    public void ActionExit()
    {
        cameraScene.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraScene = cameraScene == null ? GameObject.Find(gameObject.name.Replace("Block", string.Empty)) : cameraScene;
        cameraScene.SetActive(false);
    }
}
