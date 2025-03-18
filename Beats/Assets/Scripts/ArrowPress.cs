using UnityEngine;

public class ArrowPress : MonoBehaviour
{
    [SerializeField] bool canBePressed;
    [SerializeField] KeyCode keyToPress;

    [SerializeField] private int scoreValue = 10; // Points for each correct hit

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            // Call the ScoreManager to add points
            ScoreManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target") canBePressed = true;
        else if (other.CompareTag("Destroyer")) Destroy(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Target") canBePressed = false;
    }
}
