using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogFallow : MonoBehaviour
{
    public GameObject Player; //Drag the "player" GO here in the Inspector    

    public void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z + 40f);
    }
}
