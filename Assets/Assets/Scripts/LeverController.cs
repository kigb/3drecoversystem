using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LeverController : MonoBehaviour
{
    // Start is called before the first frame update
    public PowerEventSO powerEvent;
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform basePoint;
    private float preLeftDistance;
    private float preRightDistance;
    void Start()
    {
        preLeftDistance = Vector3.Distance(leftPoint.position, basePoint.position);
        preRightDistance = Vector3.Distance(rightPoint.position, basePoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        float leftDistance = Vector3.Distance(leftPoint.position, basePoint.position);
        float rightDistance = Vector3.Distance(rightPoint.position, basePoint.position);
        
        if (leftDistance < preLeftDistance)
        {
            preLeftDistance = leftDistance;
        }
        if(leftDistance - preLeftDistance > 1.5 )
        {
            preLeftDistance = leftDistance;
            
            //TODO
            powerEvent.RaiseEvent(new Vector2(0.1f, 0.1f));
        }
        if (rightDistance < preRightDistance)
        {
            preRightDistance = rightDistance;
        }
        if (rightDistance - preRightDistance > 1.5)
        {
            preRightDistance = rightDistance;
            
            //TODO
            powerEvent.RaiseEvent(new Vector2(-0.1f, 0.1f));
        }
    }
}
