using System;
using UnityEngine;

namespace lib.ndk
{
    [ExecuteInEditMode]
    public class GridWithTransformedChildren : MonoBehaviour
    {
        public Vector2 gridSize = new Vector2(2, 2); // Define the number of rows and columns in the grid.
        public float spacing = 2.0f; // Spacing between grid elements.
    
        void Start()
        {
            ArrangeChildrenInGrid();
        }

        void OnEnable()
        {
            ArrangeChildrenInGrid();

        }

        void Update()
        {
            ArrangeChildrenInGrid();

            
        }

        void ArrangeChildrenInGrid()
        {
            int childCount = transform.childCount;
            if (childCount == 0)
            {
                Debug.LogWarning("No child objects found to arrange in the grid.");
                return;
            }

            Vector3 initialPosition = transform.position - new Vector3((gridSize.x - 1) * spacing / 2, 0, (gridSize.y - 1) * spacing / 2);

            int childIndex = 0;

            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    if (childIndex >= childCount)
                    {
                        return;
                    }

                    Transform child = transform.GetChild(childIndex);
                    Vector3 newPosition = initialPosition + new Vector3(x * spacing, 0, y * spacing);
                    child.position = newPosition;

                    // You can apply additional transformations to each child here if needed.
                    // For example, you can rotate or scale the child objects.
                    // child.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
                    // child.localScale = new Vector3(2, 2, 2);

                    childIndex++;
                }
            }
        }
    }
}
