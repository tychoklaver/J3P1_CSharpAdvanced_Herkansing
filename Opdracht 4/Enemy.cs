namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public class Enemy : GameObject
{
    private EnemyStateBase _currentState;
    private Vector2 _startPosition;
    private readonly Player _player;
    public List<Vector2> PatrolRoute { get; private set; }
    public Enemy(Texture2D pTexture, Vector2 pStartPosition, List<Vector2> pPatrolRoute, Player pPlayer) : base(pTexture)
    {

        _position = pStartPosition;
        PatrolRoute = pPatrolRoute;

        _currentState = new PatrolState(this);
        _player = pPlayer;
    }

    public void ChangeState(EnemyStateBase pNewState) => _currentState = pNewState;

    public override void Update(GameTime pGameTime)
    {
        base.Update(pGameTime);
        _currentState.UpdateState(pGameTime);
    }

    public Vector2 GetPlayerPosition()
    {
        return _player.Position;
    }

    public bool IsPlayerInRange()
    {
        return Vector2.Distance(Position, GetPlayerPosition()) < 100f;
    }


}
