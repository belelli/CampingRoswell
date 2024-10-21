using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAnim : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] AnimationCurve myCurve;
    [SerializeField] int rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levitateAnim();
    }

    public void levitateAnim()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
        transform.localPosition = new Vector3(transform.localPosition.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.localPosition.z);

    }

}
