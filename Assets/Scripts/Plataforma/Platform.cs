using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform [] target;
    public float speed = 6.0f;

    int IniPos = 0;
    int NextPos = 1;

    bool moveNext = true;
    public float timetoNext = 2.0f;

    private void FixedUpdate()
    {
        if(moveNext)
        transform.position = Vector3.MoveTowards(transform.position, target[NextPos].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target[NextPos].position) <= 0)
        {
            StartCoroutine(TimeMove());
            IniPos = NextPos;
            NextPos++;

            if (NextPos > target.Length - 1)
                NextPos = 0;

        }

        IEnumerator TimeMove () 
        {
            moveNext = false;
            yield return new WaitForSeconds(timetoNext);
            moveNext = true;
        
        }
    }
}
