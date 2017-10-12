using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Machine : ScriptableObject
{
    public List<Entity> myEntities;
    public Machine nextMachine;
    public void FlowInto(List<Entity> InputEntities)
    {
        myEntities = InputEntities;
        Work();
        if (nextMachine !=null)
        {
            nextMachine.FlowInto(myEntities);
        }

    }
    public abstract void Work();
}

public enum Filtertype
{
    AND,OR,NAND,NOR
}

[CreateAssetMenu]
public class EntityBuilder : Machine
{
    public override void Work()
    {
        var env = Enviroment.get;
        var entityGO = new GameObject("Entity " + env.entities.Count);
        var entity = new Entity(env.entities.Count);
        var behav = entityGO.AddComponent<EntityBehaviour>();
        behav.entity = entity;

        env.entities.Add(entity);

    }
}

public class ComponentAdder : Machine
{
    public List<ComponentDatabase> componentDBs;
    public override void Work()
    {
        
    }
}