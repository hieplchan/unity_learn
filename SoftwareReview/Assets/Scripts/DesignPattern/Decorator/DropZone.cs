using UnityEngine;

public class DropZone : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (CardManager.instance.selectedCard != null)
        {
            CardManager.instance.selectedCard.MoveToAndDestroy(transform.position);
            CardManager.instance.selectedCard.Card.Play();
            int total = CardManager.instance.selectedCard.Card.Play();
            Debug.Log("Total: " + total);
        }
    }
}