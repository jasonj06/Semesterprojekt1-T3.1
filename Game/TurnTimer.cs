class TurnTimer
{
  public int CurrentTurn { get; private set; } = 0;

  // Other parts of the game can react when the turn changes.
  public event Action<int>? TurnChanged;

  public void Advance()
  {
    CurrentTurn++;
    TurnChanged?.Invoke(CurrentTurn);
  }
}
