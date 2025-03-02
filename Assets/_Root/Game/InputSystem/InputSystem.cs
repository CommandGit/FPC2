using UnityEngine;

internal sealed class InputSystem
{
    public Card CardClicked;

    public void Update()
    {
        CardClicked = null;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                CardView cardView = hit.transform.GetComponentInParent<CardView>();
                if (cardView != null)
                {
                    if (cardView.Card.IsCreated)
                    {
                        CardClicked = cardView.Card;
                    }
                    
                }
            }
        }
    }
}
