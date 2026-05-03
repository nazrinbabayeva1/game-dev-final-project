using UnityEngine;

public class Crystal : MonoBehaviour
{
    public bool isBlue;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isBlue)
        {
            TimeManager.instance.OnBlueCrystalCollected();
        }
        else
        {
            TimeManager.instance.AddTime(-5f);
        }

        Destroy(gameObject);
    }
}