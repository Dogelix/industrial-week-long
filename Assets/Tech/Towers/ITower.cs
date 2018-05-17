using Utilities;

public interface ITower
{
    /// <summary>
    /// To be used when a tower is assigned/spawed
    /// </summary>
    GamePad.Index OwnedByPlayer { get; set; }

    /// <summary>
    /// Returns the type of tower
    /// </summary>
    ETower TowerType { get; }

    /// <summary>
    /// To be called by the TowerManager, causes logic with the tower to intiate
    /// </summary>
    void Tick();
}