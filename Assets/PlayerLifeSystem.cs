using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int life;
    private Vector3 respanePosition;
    void Start()
    {
        respanePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        gameObject.transform.position = respanePosition;
    }

    public void SetRespawnPosition(Vector3 newPosition) 
    {
        respanePosition = newPosition;
    }

    public bool IsDead()
    {
        return life ==0;
    }
}
