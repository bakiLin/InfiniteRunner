using UnityEngine;

public class EnemySpeed : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public float GetSpeed() => speed;

    public void SetNewSpeed(float value) => speed = value;
}
