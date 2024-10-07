using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class CardController : MonoBehaviour
{
    [SerializeField, Required] private CardDefinition cardDefinition;

    [SerializeField] private GameObject particleEffect;
    [SerializeField] private float duration;
    [SerializeField] private Ease ease;
    
    public ICard Card;

    private void Awake() => Card = CardFactory.Create(cardDefinition);

    private void OnMouseDown()
    {
        if (CardManager.instance.selectedCard == null)
        {
            CardManager.instance.selectedCard = this;
        }
        else
        {
            CardManager.instance.Decorate(this);
            CardManager.instance.selectedCard = null;
        }
    }

    public void MoveTo(Vector3 position)
    {
        transform.DOMove(position, duration).SetEase(ease);
    }

    public void MoveToAndDestroy(Vector3 position)
    {
        transform.DOMove(position, duration).SetEase(ease).OnComplete(() =>
        {
            var vfx = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(vfx, 1f);
        });
    }
}