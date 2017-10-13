using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ComponentAdder : EntityTank
{
    public List<ComponentDatabase> componentDBs;
    public override void MyOperation (Entity entity)
    {
        foreach (var cDB in componentDBs)
        {
                cDB.AddComponent(entity.id);           
        }
    }
}