using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Filter : Machine
{
    public List<ComponentDatabase> componentDBs;

    public Filtertype filtertype;

    public override void Work()
    {
        foreach (var componentdB in componentDBs)
        {
            for (int i = 0; i < myEntities.Count; i++)
            {
                if (filtertype == Filtertype.NOR)
                {
                    if (componentdB.HasComponent(myEntities[i].id))
                    {
                        myEntities.Remove(myEntities[i]);
                    }
                }                
            }
        }
    }
}
