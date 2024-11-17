
namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_1;

public class Gate : Interactable
{
    public Gate(Texture2D pTexture, Random pRandom, Player pPlayer) : base(pTexture, pRandom, pPlayer) { }

    /// <summary>
    /// The functionality which happens when player interacts with <see cref="Gate"/> object.
    /// </summary>
    /// <param name="pPlayer">Player object used to call interacting logic.</param>
    public override void Interact(Player pPlayer)
    {
        Environment.Exit(0); // Exits game.
    }
}
