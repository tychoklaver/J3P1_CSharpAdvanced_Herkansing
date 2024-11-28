
namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public class HealthUI : GameObject
{
    private int _lives;
    private readonly Player _player;

    public HealthUI(Texture2D pTexture, Player pPlayer) : base(pTexture)
    {
        _player = pPlayer;
        _lives = pPlayer.PlayerLives;
    }

    public override void Update(GameTime pGameTime)
    {
        _lives = _player.PlayerLives;
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        base.Draw(pSpriteBatch);

        for (int i = 0; i < _lives; i++)
        {
            Vector2 position = new Vector2(10 + (i * 30), 10);
            pSpriteBatch.Draw(_texture, position, Color.White);
        }
    }
}
