using System.Collections;

public class TestComponent : Component {
   
    public int x;
    public TestComponent(int x)
    {
        this.x = x;
    }
}



public partial class Entity
{
    public TestComponent test
    {
        get { return TestDatabase.get.LookUpTable[id];}
        set { TestDatabase.get.LookUpTable[id] = value;}

    }
    public void AddTest(int x)
    {
        var newComp = new TestComponent(x);
        TestDatabase.get.LookUpTable.Add(id, newComp);
        TestDatabase.get.testComponents.Add(newComp);
    }
}
