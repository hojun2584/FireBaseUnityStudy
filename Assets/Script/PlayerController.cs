using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    Transform playerTransform;
    float rayDistance = 3f;

    float playerSpped = 0.02f;
    [SerializeField]
    GameObject target;

    float rotationSpeed = 1f;
    private Vector3 rotation;


    public void Update()
    {



        float vertical = Input.GetAxisRaw("Vertical");
        float horizon = Input.GetAxisRaw("Horizontal");


        Vector3 vecZero = Vector3.zero;
        Vector3 vecleft = Vector3.zero;
        if (vertical != 0)
        {
            vecZero.z += vertical * playerSpped;
        }
        if (horizon != 0)
        {
            vecleft.y += horizon * rotationSpeed;
        }

        transform.Translate(vecZero);
        transform.Rotate(vecleft);
        FindItem();

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (target.TryGetComponent(out IInteractiveItem interactive))
            {
                interactive.Interactive(gameObject);
            }
                

        }
    }

    public void FindItem()
    {

        RaycastHit hitObject;

        if (Physics.Raycast(transform.position, transform.forward , out hitObject , rayDistance) )
        {
            target = hitObject.transform.gameObject;
        }

    }


}
