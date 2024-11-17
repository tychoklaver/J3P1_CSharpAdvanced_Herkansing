
namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_1;
public abstract class Interactable : GameObject
{
    protected Random _random;
    public Interactable(Texture2D pTexture, Random pRandom) : base(pTexture)
    {
        _random = pRandom;
        RandomizePosition();
    }

    /// <summary>
    /// Randomizes starting position of the object.
    /// </summary>
    protected void RandomizePosition()
    {
        Position = new Vector2(
            _random.Next((int)_origin.X, Game1.ScreenWidth - (int)_origin.X),
            _random.Next((int)_origin.Y, Game1.ScreenHeight - (int)_origin.Y)
        );
    }

    public override void Update(Player pPlayer)
    {
        HandleInteraction(pPlayer);
    }

    /// <summary>
    /// Checks for collision with Player object, then calls interaction functionality logic.
    /// </summary>
    /// <param name="pPlayer">The Player object used to check collision with.</param>
    public void HandleInteraction(Player pPlayer)
    {
        if (pPlayer.Rectangle.Intersects(Rectangle))
            Interact(pPlayer);
    }

    public abstract void Interact(Player pPlayer);
}
