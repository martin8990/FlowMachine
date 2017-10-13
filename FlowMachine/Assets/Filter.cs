using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Filter : EntityTank
{
    public EntityTank FilterDrain;
    public List<ComponentDatabase> componentDBs;
    public List<Entity> removedEntities;

    public Filtertype filtertype;

    public override void Operate(Entity entity)
    {
        foreach (var componentdB in componentDBs)
        {
            if (filtertype == Filtertype.NOR)
            {
                if (componentdB.HasComponent(entity.id))
                {
                    myEntities.Remove(entity);
                    removedEntities.Add(entity);
                }
            }
        }
    }
    public override void Cleanup()
    {
        FilterDrain.LoadEntities(removedEntities);
    }
}


