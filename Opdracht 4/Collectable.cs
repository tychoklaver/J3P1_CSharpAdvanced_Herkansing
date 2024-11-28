namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public class Collectable : Interactable
{
    public bool IsPickedUp { get; private set; }

    public Collectable(Texture2D pTexture, Random pRandom, Player pPlayer) : base(pTexture, pRandom, pPlayer)
    {
        IsPickedUp = false;
    }

    public override void Interact(Player pPlayer)
    {
        IsPickedUp = true;
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        if (!IsPickedUp) 
            base.Draw(pSpriteBatch);
    }
}
