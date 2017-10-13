using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EntityTank : ScriptableObject
{
    public bool TriggeredUnload;
    public EntityTank nextTank;
    public bool Threaded;
    public List<Entity> entityBuffer;

    public void LoadEntities(List<Entity> inputEntites)
    {

        Prepare();
        if (Threaded)
        {
            var or = new OperationRequest(Operate, UnLoadEntities, inputEntites);
        }
        
        Cleanup();

    }
    List<Entity> Operate(List<Entity> inputEntities)
    {
        foreach (var entity in inputEntities)
        {
            MyOperation(entity);
        }
        return inputEntities;
    }
   


    public void UnLoadEntities(List<Entity> outputEntities)
    {
        if (nextTank != null && !TriggeredUnload)
        {
            nextTank.LoadEntities(outputEntities);
        }
        else
        {
            
        }

    }
    public virtual void Prepare()
    {

    }
    public virtual void MyOperation(Entity entity)
    {

    }
    public virtual void Cleanup()
    { }
}

public enum Filtertype
{
    AND,OR,NAND,NOR
}
