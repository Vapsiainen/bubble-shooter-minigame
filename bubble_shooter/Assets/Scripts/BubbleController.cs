using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bubble_Type
{
    BLUE = 0,
    GREEN = 1,
    YELLOW = 2,
    RED = 3
}

public class BubbleController : MonoBehaviour
{
    // We want to show this in the editor
    [SerializeField] private Bubble_Type m_bubbleType;
    private List<BubbleController> m_neighbourControllers = new List<BubbleController>();
    private Collider2D m_collider;
    private float m_gap;


    // Call when bubble is created
    public void Init(float gap)
    {
        m_gap = gap;
    }


    // When bubble gets hit and destroyed
    public void OnSuccesfulHit(BubbleController sourceController)
    {
        // Go through all neighbors
        foreach (BubbleController controller in m_neighbourControllers)
        {
            // Skip the one who sent this (to avoid infinite loops)
            if (controller != sourceController)
            {
                controller.OnSuccesfulHit(this);
            }
        }
    }


    // Is bubble controller the same type
    public bool IsType(Bubble_Type bubble_Type)
    {
        return bubble_Type == m_bubbleType;
    }


    // Update all neighbors. Call when all bubbles are created and maybe every time a new bubble is created?
    public void UpdateNeighbours()
    {
        m_neighbourControllers.Clear();

        // Get left
        if (HasNeighbour(Vector2.left, out BubbleController leftController))
        {
            if (leftController.IsType(m_bubbleType))
            {
                m_neighbourControllers.Add(leftController);
            }
        }

        // Get right
        if (HasNeighbour(Vector2.right, out BubbleController rightController))
        {
            if (rightController.IsType(m_bubbleType))
            {
                m_neighbourControllers.Add(rightController);
            }
        }

        // Get top
        if (HasNeighbour(Vector2.up, out BubbleController upController))
        {
            if (upController.IsType(m_bubbleType))
            {
                m_neighbourControllers.Add(upController);
            }
        }

        // Get bottom
        if (HasNeighbour(Vector2.down, out BubbleController downController))
        {
            if (downController.IsType(m_bubbleType))
            {
                m_neighbourControllers.Add(downController);
            }
        }
    }

    // Check if has neighbor in given direction
    private bool HasNeighbour(Vector2 direction, out BubbleController neighbour)
    {
        neighbour = default;

        // Do a raycast, this can also be restricted to a given layer, if bubbles are on their own layer
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, m_gap * 2);

        // If any hits exist
        if (hits.Length > 0)
        {
            BubbleController controller = default;

            // Go through all hits (basicaly there should only be one)
            foreach (RaycastHit2D hit in hits)
            {

                // If hit collider is my collider, skip
                if(hit.collider == m_collider)
                {
                    continue;
                }

                // Get bubble_controller from the hits collider gameObject
                controller = hit.collider.GetComponent<BubbleController>();

                // If controller existed, exit the foreach
                if (controller != null)
                {
                    break;
                }
            }

            // Assign found controller to be the neighbor
            if (controller != null)
            {
                neighbour = controller;

                // Controller was found, return true
                return true;
            }
        }
        // No controller found, return false
        return false;
    }

    private void Awake()
    {
        m_collider = GetComponent<Collider2D>();
    }



}
