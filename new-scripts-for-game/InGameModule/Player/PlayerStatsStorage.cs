using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats")]
public class PlayerStatsStorage : ScriptableObject
{
    private Vector3 position;
    private int petals;

    public Vector3 Position { get => position; }
    public int Petals { get => petals; }

    public void SetPosition(Vector3 pos)
    {
        position = pos;
    }

    public void IncreasePetal()
    {
        petals++;
    }
    public void DecreasePetal()
    {
        petals--;
    }
    public void AddPetal(int count)
    {
        petals += count;
    }
    public void SellPetal(int count)
    {
        petals -= count;
        if (petals <= 0)
        {
            petals = 0;
        }
    }
    public void SetPetalsCount(int count)
    {
        petals = count;
    }




}
