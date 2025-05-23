using UnityEngine;

public class cameraSeguio : MonoBehaviour
{

    [SerializeField]
    [Range(0f, 100f)]
    private float OffSet;
    [SerializeField]
    [Range(-10f, 10f)]
    private float HightSet;

    [SerializeField]
    private GameObject Player;

    void Start()
    {

    }

    void Update()
    {
        transform.position = Player.transform.position;
        transform.position += new Vector3(0, 0, -OffSet);
    }
}
