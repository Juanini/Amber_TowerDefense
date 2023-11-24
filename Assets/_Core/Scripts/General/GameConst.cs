
public class GameConst
{
    public const string TAG_ENEMY = "Enemy";
    public const string TAG_PLAYER = "Player";
}

public enum GameState
{
    Idle = 0,
    Paused,
    CreateTower,
    UpgradeTower,
    Win,
    Lose
}

public enum TowerType
{
    Archer = 0,
    Magic
}

public enum ProjectileType
{
    Arrow = 0,
    MagicSphere
}

public enum TowerLvl
{
    LVL_1 = 0,
    LVL_2,
    LVL_3
}

public enum TowerNodeState
{
    Available = 0,
    Busy
}