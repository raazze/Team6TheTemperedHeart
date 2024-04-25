using System.Data.Common;
using CGP;
using TMPro;


namespace CGP
{
    using UnityEngine;
    
    
    public class PrefabSummon : MonoBehaviour
    {
        private bool isInteractable = false;
        public TextMeshProUGUI infoText;
        public GameObject infoPanel;
        public CanvasGroup infoTextCanvas;
        public GameObject myPrefab;
        public float x, y, z;

        public int questNum;
        // Function to call when interacting
        void OnInteraction()
        {
            // Implement your interaction logic here
            Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            infoPanel.SetActive(false);
        }

        // Check for player entering the collider
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Player is inside the collider, enable interaction
                EnableInteraction();
                isInteractable = true;
                infoText.text = "Press E to Spawn";
                infoTextCanvas.alpha = 1; //this makes everything transparent
                infoTextCanvas.blocksRaycasts = true; //this prevents the UI element to receive input events
            }
        }

        // Check for player exiting the collider
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Player has exited the collider, disable interaction
                DisableInteraction();
                isInteractable = false;
                infoText.text = null;
                infoTextCanvas.alpha = 0; //this makes everything transparent
                infoTextCanvas.blocksRaycasts = false; //this prevents the UI element to receive input events
            }
        }

        // Enable interaction
        void EnableInteraction()
        {
            // Subscribe to the key press event
            if (!Input.GetKeyDown(KeyCode.E))
            {
                Input.GetKeyDown(KeyCode.E);
            }
        }

        // Disable interaction
        void DisableInteraction()
        {
            // Unsubscribe from the key press event
            if (Input.GetKeyDown(KeyCode.E))
            {
                Input.GetKeyUp(KeyCode.E);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Check for 'E' key press while player is inside collider
            if (Input.GetKeyDown(KeyCode.E) && isInteractable)
            {
                OnInteraction();
            }
        }

        void Start()
        {
            infoTextCanvas.alpha = 0; //this makes everything transparent
            infoTextCanvas.blocksRaycasts = false; //this prevents the UI element to receive input events
        }
    }
}
