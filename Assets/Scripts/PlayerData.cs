using System;
[Serializable]
public class PlayerData
{
    public int id;
    public string playerName;
    public long phonNumber;
    public int score;

    public PlayerData(int _id, string _playerName, long _phoneNum,int _Score)
    {
        id = _id;
        playerName = _playerName;
        phonNumber = _phoneNum;
        score = _Score;
    }
}