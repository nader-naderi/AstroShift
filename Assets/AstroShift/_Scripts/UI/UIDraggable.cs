using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AstroShift
{
    public class UIDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        private Canvas canvas;
        private CanvasGroup canvasGroup;
        private Vector2 originalPosition;
        private Transform originalParent;
        private int originalSiblingIndex;
        private GridLayoutGroup gridLayoutGroup;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            canvas = UIManager.Instance.CustomizeCanvas;
            canvasGroup = GetComponent<CanvasGroup>();
            originalPosition = rectTransform.anchoredPosition;
            originalParent = transform.parent;
            originalSiblingIndex = transform.GetSiblingIndex();
            gridLayoutGroup = GetComponentInParent<GridLayoutGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // Set the sorting order of the element to make it appear on top
            rectTransform.SetAsLastSibling();

            // Enable the element to be dragged
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            // Remove from the grid layout group
            transform.SetParent(originalParent.parent);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Drag the element with the mouse
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // Disable the element from being dragged
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            // Get the closest position in the grid layout group
            var closestPosition = GetClosestPosition(eventData.position);

            // If there is a closest position, snap to it
            if (closestPosition.HasValue)
            {
                // Set the new parent to the grid layout group
                transform.SetParent(gridLayoutGroup.transform);

                // Set the sibling index to the last child of the grid layout group
                transform.SetAsLastSibling();

                // Snap to the closest position in the grid layout group
                rectTransform.anchoredPosition = closestPosition.Value;
            }
            else
            {
                // Snap back to original position if dropped outside of the grid layout group
                transform.SetParent(originalParent);
                transform.SetSiblingIndex(originalSiblingIndex);
                rectTransform.anchoredPosition = originalPosition;
            }
        }

        private Vector2? GetClosestPosition(Vector3 position)
        {
            // Find all child elements in the grid layout group
            var childElements = gridLayoutGroup.transform.GetComponentsInChildren<Transform>();

            if (childElements.Length == 1)
            {
                // If there is only one child element (the grid layout group itself), return null
                return null;
            }

            // Find the closest position to the mouse position
            Vector2? closestPosition = null;
            var closestDistance = float.MaxValue;

            foreach (var childElement in childElements)
            {
                if (childElement == transform)
                {
                    // Skip this element
                    continue;
                }

                var childRectTransform = childElement.GetComponent<RectTransform>();

                if (childRectTransform == null)
                {
                    // Skip elements without a RectTransform component
                    continue;
                }

                var distance = Vector3.Distance(position, childRectTransform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPosition = childRectTransform.anchoredPosition;
                }
            }

            return closestPosition;
        }
    }
}
