using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartOfPlayer : MonoBehaviour
{

    public Vector2 Force;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Force); // добавить воздействие силы на объект
    }

}
