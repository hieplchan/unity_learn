using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PowerUp powerUp;

    private void OnTriggerEnter(Collider other)
    {
        var visitable = other.GetComponent<IVisitable>();
        if (visitable != null)
        {
            visitable.Accept(powerUp);
            Destroy(gameObject);
        }
    }
}