using UnityEngine;

public class CardManager : MonoSingleton<CardManager>
{
    public CardController selectedCard;

    public void Decorate(CardController clickedCard)
    {
        if (selectedCard.Card is CardDecorator decorator)
        {
            if (selectedCard == clickedCard) return;
            
            Debug.Log("Decorating card");
            decorator.Decorate(clickedCard.Card);
            clickedCard.Card = decorator;
            
            // get rid of old card, animate
            selectedCard.MoveToAndDestroy(clickedCard.transform.position);
        }
        else
        {
            Debug.LogWarning("Cannot decorate card");
        }
    }
}