using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class UpColliderCheck : MonoBehaviour
{
    private Vector2 boxSize;
    private float offset;
    void Start()
    {
        boxSize = GetComponent<BoxCollider2D>().size * gameObject.transform.localScale.x;
        offset = 1.01f;
    }
    public void GetUpColliderGroup(ref List<Collider2D> previousGroupList)
    {
        Vector2 checkPos = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliderGroup = Physics2D.OverlapBoxAll(checkPos, boxSize * offset, 0);
        foreach (var item in colliderGroup)
        {
            if (item == GetComponent<BoxCollider2D>()) continue;
            if (!previousGroupList.Contains(item) && item.gameObject.transform.position.y > gameObject.transform.position.y)
            {
                previousGroupList.Add(item);
                //µÝ¹é×ÓÎïÌå
                if (item.gameObject.GetComponent<UpColliderCheck>())
                {
                    item.gameObject.GetComponent<UpColliderCheck>().GetUpColliderGroup(ref previousGroupList);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y), boxSize * 1.01f);
    }
}
