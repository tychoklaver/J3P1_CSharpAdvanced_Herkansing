namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_1;
public class Sword : Interactable
{
    public Sword(Texture2D pTexture, Random pRandom) : base(pTexture, pRandom) { }

    public override void Interact(Player pPlayer)
    {
        pPlayer.EquipSword(this);
    }
}
