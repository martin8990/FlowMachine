using System.Collections.Generic;
using UnityEngine;
public abstract class ComponentDatabase : ScriptableObject
{
    public abstract bool HasComponent(int Id);
}
[CreateAssetMenu]
public class TestDatabase : ComponentDatabase
{
    public static TestDatabase get
    {
        get
        {
            if (me==null)
            {
                me = FindObjectOfType<TestDatabase>();
            }
            return me;
        }
    }
    static TestDatabase me;
    
    public List<TestComponent> testComponents = new List<TestComponent>();
    public Dictionary<int, TestComponent> LookUpTable = new Dictionary<int, TestComponent>();

    

    public void load()
    {
        LookUpTable = new Dictionary<int, TestComponent>();
        foreach (var testComponent in testComponents)
        {
            LookUpTable.Add(testComponent.EntityId, testComponent);
        }
    }

    public override bool HasComponent(int Id)
    {
        return LookUpTable.ContainsKey(Id);
    }

    
}
