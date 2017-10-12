using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour {

    public static Enviroment get
    {
        get
        {
            if (me==null)
            {
                me = GameObject.Find("Enviroment").GetComponent<Enviroment>();
            }
            return me;
        }
    }
    static Enviroment me;
    public List<Entity> entities = new List<Entity>();
    
}
