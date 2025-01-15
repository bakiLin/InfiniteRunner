using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class RenderTrail : MonoBehaviour
{
    [SerializeField]
    private float lifetime; 

    [SerializeField]
    private float minimumVertexDistance; 

    [SerializeField]
    private Vector3 velocity; 

    private LineRenderer line;
    
    private List<Vector3> points;

    private Queue<float> spawnTimes = new Queue<float>();

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = true;
        line.useWorldSpace = true;
        points = new List<Vector3>() { transform.position }; 
        line.SetPositions(points.ToArray());
    }

    private void Update()
    {
        while (spawnTimes.Count > 0 && spawnTimes.Peek() + lifetime < Time.time)
            RemovePoint();

        Vector3 diff = -velocity * Time.deltaTime;

        for (int i = 1; i < points.Count; i++)
            points[i] += diff;

        if (points.Count < 2 || Vector3.Distance(transform.position, points[1]) > minimumVertexDistance)
            AddPoint(transform.position);

        points[0] = transform.position;

        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }

    private void AddPoint(Vector3 position)
    {
        points.Insert(1, position);
        spawnTimes.Enqueue(Time.time);
    }

    private void RemovePoint()
    {
        spawnTimes.Dequeue();
        points.RemoveAt(points.Count - 1);
    }

    public void MoveTrail()
    {
        transform.DOMoveZ(-20f, 10f)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => {
                gameObject.SetActive(false);
            });
    }
}
