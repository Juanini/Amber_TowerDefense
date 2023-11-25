using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/Enemy Config", order = 1)]
public class EnemyConfig : ScriptableObject
{
    public int health;
    public int attackValue;
    public float speed;
    public float goldToGive;
}