using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float visionRadius = 5f;
    public float extraTimeDrain = 2f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist < visionRadius)
        {
            // 🔴 RED ALERT MODE
            TimeManager.instance.AddTime(-extraTimeDrain * Time.deltaTime);
        }
    }
}