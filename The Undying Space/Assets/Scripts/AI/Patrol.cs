using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public float speed;

    public Transform target1;
    public Transform target2;
    public bool bens;

    void Start()
    {
        bens = false;
    }
    //private float timeCount = 0.0f;

    void Update()
    {
        if (bens == false)
        {


            //Vector3 direction = target1.position - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(Vector3.forward,direction);
            //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.5f * Time.deltaTime);


            //transform.position = Vector2.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
            //agent.SetDestination(target1.position);

        }
        if (bens == true)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);

            //Vector3 offset = target2.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, offset);
        }
        if (transform.position == target1.position) StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(2);    //Wait one frame
        bens = true;
    }
}
