using UnityEngine;
public class Entity : MonoBehaviour
{
    public int id;
    public TestComponent testComponent {
        get
        {
            return TestDatabase.get.LookUpTable[id];
        }
    }
}



