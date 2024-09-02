using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stringPoints : MonoBehaviour
{
    public Transform _leftPoint;
    public Transform _rightPoint;
    public Transform _centerPoint;

    LineRenderer slingshotString;
    // Start is called before the first frame update
    void Start()
    {
        slingshotString = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        slingshotString.SetPositions(new Vector3[3] { _leftPoint.position, _centerPoint.position, _rightPoint.position });
    }
}
