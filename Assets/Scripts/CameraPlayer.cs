using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public Vector3 offset;
    void Start()
    {
        target = target == null ? GameObject.Find("CharacterPainEpice") : target;
        offset = target.transform.position -  transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position - offset;
    }
}
