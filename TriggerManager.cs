using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            Destroy(col.gameObject);
        }
        else if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            CharacterController controller = col.GetComponent<CharacterController>();
            controller.enabled = false;
            col.transform.position = new Vector3(0, 10f, 0);
            controller.enabled = true;
        }
    }
}
