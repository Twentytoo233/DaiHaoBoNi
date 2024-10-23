using UnityEngine;

public class SeesawPanelGroup : MonoBehaviour
{
    public SeesawPanel leftPanel;
    public SeesawPanel rightPanel;
    public float offset;
    private float InitPosY;

    private void Start()
    {
        if (leftPanel.transform.position.y == rightPanel.transform.position.y)
        {
            InitPosY = leftPanel.transform.position.y;
        }
        else
        {
            Debug.LogError("确保跷跷板两个板子的初始y值一样!!!");
        }
    }

    void Update()
    {
        float leftAllMass = leftPanel.GetUpColliderGroupMass();
        float rightAllMass = rightPanel.GetUpColliderGroupMass();

        if (leftAllMass > rightAllMass)
        {
            if (leftPanel.transform.position.y > InitPosY - offset) leftPanel.transform.position += (Vector3.down * Time.deltaTime);
            if (rightPanel.transform.position.y < InitPosY + offset) rightPanel.transform.position += (Vector3.up * Time.deltaTime);
        }
        else if (rightAllMass > leftAllMass)
        {
            if (leftPanel.transform.position.y < InitPosY + offset) leftPanel.transform.position += (Vector3.up * Time.deltaTime);
            if (rightPanel.transform.position.y > InitPosY - offset) rightPanel.transform.position += (Vector3.down * Time.deltaTime);
        }
        else
        {
            if (Mathf.Abs(leftPanel.transform.position.y - InitPosY) > 0.01f)
            {
                if (leftPanel.transform.position.y > InitPosY)
                {
                    leftPanel.transform.position += (Vector3.down * Time.deltaTime);
                    rightPanel.transform.position += (Vector3.up * Time.deltaTime);
                }
                else
                {
                    leftPanel.transform.position += (Vector3.up * Time.deltaTime);
                    rightPanel.transform.position += (Vector3.down * Time.deltaTime);
                }
            }
        }
    }
}
