[System.Serializable]

public class RewardData
{
    public enum RewardType{
        Coins,
        Gems
    }
    public RewardType type;
    public int amount;
    public bool isUnLocked;
}