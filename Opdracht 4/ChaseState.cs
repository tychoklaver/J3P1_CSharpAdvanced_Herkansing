namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public class ChaseState : EnemyStateBase
{
    public ChaseState(Enemy pEnemy) : base(pEnemy)
    {
    }

    public override void UpdateState(GameTime pGameTime)
    {
        Vector2 playerPosition = _enemy.GetPlayerPosition();

        float distance = Vector2.Distance(_enemy.Position, playerPosition);

        //_enemy.Position = Vector2.Lerp(_enemy.Position, playerPosition, 150f * (float)pGameTime.ElapsedGameTime.TotalSeconds);

        if (distance < 300f)
        {
            Vector2 direction = playerPosition - _enemy.Position;
            _enemy.Position += Vector2.Normalize(direction) * 150f * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
        else
            _enemy.ChangeState(new PatrolState(_enemy));
            
    }
}
