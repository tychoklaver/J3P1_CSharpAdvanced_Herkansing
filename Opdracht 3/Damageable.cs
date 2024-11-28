
namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public class Damageable : Interactable
{
    private bool _isTouched;

    public Damageable(Texture2D pTexture, Random pRandom, Player pPlayer) : base(pTexture, pRandom, pPlayer)
    {
        _isTouched = false;
    }

    public override void Interact(Player pPlayer)
    {
        if (!_isTouched)
        { 
            pPlayer.LoseHealth();
            _isTouched = true;
        }
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        if (!_isTouched)
            base.Draw(pSpriteBatch);
    }
}
