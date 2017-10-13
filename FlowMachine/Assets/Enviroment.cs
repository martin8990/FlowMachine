using UnityEngine;
using System.Collections.Generic;
public class Enviroment : MonoBehaviour
{
    public static Transform myTransform
    {
        get
        {
            
            return tf;
        }
    }
    static Transform tf;
    private void Start()
    {
        tf = transform;
    }
    

}
