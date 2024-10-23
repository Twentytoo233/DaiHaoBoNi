using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawPanel : MonoBehaviour
{
    private Vector2 boxSize;
    private List<Collider2D> upColliderGroup;
    private float offset;
    void Start()
    {
        boxSize = GetComponent<BoxCollider2D>().size;
        offset = 1.01f;
        upColliderGroup = new List<Collider2D>();
    }
    public float GetUpColliderGroupMass()
    {
        upColliderGroup = new List<Collider2D>();

        Vector2 checkPos = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliderGroup = Physics2D.OverlapBoxAll(checkPos, boxSize * offset, 0);
        foreach (var item in colliderGroup)
        {
            if (item == GetComponent<BoxCollider2D>()) continue;
            //暂时给0.1f偏移
            if (!upColliderGroup.Contains(item) && item.gameObject.transform.position.y > gameObject.transform.position.y + 0.1f)
            {
                upColliderGroup.Add(item);
                //递归子物体
                if (item.gameObject.GetComponent<UpColliderGroupCheck>())
                {
                    item.gameObject.GetComponent<UpColliderGroupCheck>().GetUpColliderGroup(ref upColliderGroup);
                }
            }
        }

        float allMass = 0f;
        foreach (var item in upColliderGroup)
        {
            if (item.gameObject.GetComponent<Rigidbody2D>()) allMass += item.gameObject.GetComponent<Rigidbody2D>().mass;
        }

        return allMass;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y), boxSize * 1.01f);
    }
}
