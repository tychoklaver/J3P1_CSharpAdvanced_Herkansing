namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public class PatrolState : EnemyStateBase
{
    private float _patrolTimer;
    private const float PATROL_TIME_LIMIT = 15f;
    private List<Vector2> _waypoints;
    private int _index = 0;

    public PatrolState(Enemy pEnemy) : base(pEnemy)
    {
        _waypoints = pEnemy.PatrolRoute;
        _patrolTimer = 0f;
    }

    public override void UpdateState(GameTime pGameTime)
    {
        _patrolTimer += (float)pGameTime.ElapsedGameTime.TotalSeconds;

        Vector2 waypoint = _waypoints[_index];

        Vector2 direction = waypoint - _enemy.Position;
        MoveToWaypoint(direction, pGameTime);

        if (Vector2.Distance(_enemy.Position, waypoint) < 1f)
            _index = (_index + 1) % _waypoints.Count;

        if (_enemy.IsPlayerInRange())
            _enemy.ChangeState(new ChaseState(_enemy));
        else if (HasPatrolledForTooLong())
            _enemy.ChangeState(new IdleState(_enemy));
    }

    private void MoveToWaypoint(Vector2 pDirection, GameTime pGameTime)
    {
        _enemy.Position += Vector2.Normalize(pDirection) * 100f * (float)pGameTime.ElapsedGameTime.TotalSeconds;
    }


    private bool HasPatrolledForTooLong()
    {
        if (_patrolTimer >= PATROL_TIME_LIMIT)
            return true;
        return false;
    }
}
