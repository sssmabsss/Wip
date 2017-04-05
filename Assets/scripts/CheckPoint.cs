using UnityEngine;

public class CheckPoint : MonoBehaviour 
{
    public bool Activated = false;
    public static GameObject[] CheckPointsList;
    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(0, 0, 0);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<CheckPoint>().Activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }

    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckPoint>().Activated = false;
        }

        // We activated the current checkpoint
        Activated = true;
    }



    void Start()
    {
        // We search all the checkpoints in the current scene
        CheckPointsList = GameObject.FindGameObjectsWithTag("checkPoint");
    }

    void Update()
    {
        if (Activated) GetComponent<SpriteRenderer>().color = Color.green;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }
}
