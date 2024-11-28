
namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public class IdleState : EnemyStateBase
{
    private float _idleTimer;
    private const float IDLE_TIME_LIMIT = 5f;
    public IdleState(Enemy pEnemy) : base(pEnemy)
    {
        _idleTimer = 0f;
    }

    public override void UpdateState(GameTime pGameTime)
    {
        _idleTimer += (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (IsIdleForTooLong())
            _enemy.ChangeState(new PatrolState(_enemy));

        if (_enemy.IsPlayerInRange())
            _enemy.ChangeState(new ChaseState(_enemy));
    }

    private bool IsIdleForTooLong()
    {
        if (_idleTimer > IDLE_TIME_LIMIT)
            return true;
        return false;
    }
}
