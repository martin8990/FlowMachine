using UnityEngine;
[CreateAssetMenu]
public class EntityGenerator : EntityTank
{
    public int numEntities;

    public override void Prepare()
    {
        base.Prepare();
        for (int i = 0; i < numEntities; i++)
        {
            var transform = Enviroment.myTransform;
            var entityGO = new GameObject("Entity " + transform.childCount);
            var entity = entityGO.AddComponent<Entity>();
            entity.id = transform.childCount;
            entity.transform.parent = transform;
            entityBuffer.Add(entity);
        }
    }

    
}
