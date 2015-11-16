using UnityEngine;
using System.Collections;

public class FuckSlimeTransport : MonoBehaviour {

    public GameObject Sludge;
    public GameObject newSludgePosition;     //Turn off previous text Overlays
    public bool isLeft = false;
    public bool isRight = false;
    public bool isUpsideDown = false;
    public bool isNormal = false;

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        RevisedSlimeMovement slimeMovement = new RevisedSlimeMovement();
        //Stores position and rotation of one of the objects
        //var position1 : Vector3 = object1.transform.position;
        //var rotation1 : Quaternion = object1.transform.rotation;

        Vector3 position1 = Sludge.transform.position;
        Quaternion rotation1 = Sludge.transform.rotation;
        Quaternion rotation2 = Sludge.transform.rotation;

        newSludgePosition.transform.rotation = rotation2;

        Sludge.transform.position = newSludgePosition.transform.position;
        Sludge.transform.rotation = newSludgePosition.transform.rotation;

        if (isLeft)
        {
            slimeMovement.slimeDir = RevisedSlimeMovement.SlimeDirection.isNormal;
            Sludge.transform.Rotate(0, 0, 90);
            print(slimeMovement.slimeDir);
            Physics2D.gravity = Vector3.zero;
            slimeMovement.CheckRotation();
        }
        else if(isRight)
        {
            slimeMovement.slimeDir = RevisedSlimeMovement.SlimeDirection.isNormal;
            Sludge.transform.Rotate(0, 0, 270);
            print(slimeMovement.slimeDir);
            Physics2D.gravity = Vector3.zero;
            slimeMovement.CheckRotation();
        }
        else if (isLeft && isUpsideDown)
        {
            slimeMovement.slimeDir = RevisedSlimeMovement.SlimeDirection.isLeft;
            Sludge.transform.Rotate(0, 0, 180);
            print(slimeMovement.slimeDir);
            Physics2D.gravity = Vector3.zero;
            slimeMovement.CheckRotation();
        }
        else if (isRight && isUpsideDown)
        {
            slimeMovement.slimeDir = RevisedSlimeMovement.SlimeDirection.isRight;
            Sludge.transform.Rotate(0, 0, 180);
            print(slimeMovement.slimeDir);
            Physics2D.gravity = Vector3.zero;
            slimeMovement.CheckRotation();
        }
                
        /*object2.transform.position = position1;
        object2.transform.rotation = rotation1;
        */
    }
}