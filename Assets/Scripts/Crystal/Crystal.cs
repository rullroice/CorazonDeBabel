using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private Manager manager;

    private void Start()
    {
        manager = Manager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            manager.ChangeCrystals(value);
            Destroy(gameObject);
        }
    }
}

