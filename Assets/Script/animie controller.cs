using UnityEngine;

public class animiecontroller : MonoBehaviour
{
    public float moveSpeed;
    public AnimiePass enemyPath;

    private int currentPathPointIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyPath == null || enemyPath.pathPoints == null || enemyPath.pathPoints.Length == 0)
        {
            return;
        }

        Transform currentPathPoint = enemyPath.pathPoints[currentPathPointIndex];
        if (currentPathPoint == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            currentPathPoint.position,
            moveSpeed * Time.deltaTime);

        if (transform.position == currentPathPoint.position)
        {
            if (currentPathPointIndex == enemyPath.pathPoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            currentPathPointIndex++;
        }
    }
}
