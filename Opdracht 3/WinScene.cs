namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public class WinScene : SceneBase
{
    public WinScene(Game1 pGame) : base(pGame)
    {

    }

    public override void LoadContent()
    {
        Rectangle buttonAgainBounds = new Rectangle((Game1.ScreenWidth - _game.ButtonTexture.Width) / 2, (Game1.ScreenHeight - 100 - _game.ButtonTexture.Height) / 2, _game.ButtonTexture.Width, _game.ButtonTexture.Height);
        Rectangle buttonMenuBounds = new Rectangle((Game1.ScreenWidth - _game.ButtonTexture.Width) / 2, (Game1.ScreenHeight + 100 - _game.ButtonTexture.Height) / 2, _game.ButtonTexture.Width, _game.ButtonTexture.Height);
        void onClickAgainAction() => _game.InitializeGameInstance();
        void onClickMenuAction() => Environment.Exit(0) ;
        _objects.Add(new ButtonBase(_game.ButtonTexture, buttonAgainBounds, onClickAgainAction, _game.Content.Load<SpriteFont>("Fonts/ButtonFont"), "Play Again!"));
        _objects.Add(new ButtonBase(_game.ButtonTexture, buttonMenuBounds, onClickMenuAction, _game.Content.Load<SpriteFont>("Fonts/ButtonFont"), "Quit Game"));
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        base.Draw(pSpriteBatch);

        SpriteFont font = _game.Content.Load<SpriteFont>("Fonts/TextFont");
        Vector2 textSize = font.MeasureString("You win!");
        Vector2 positon = new((Game1.ScreenWidth / 2) - (textSize.X / 2), (Game1.ScreenHeight / 2) - (textSize.Y / 2));

        pSpriteBatch.DrawString(font, "You win!", positon, Color.White);
    }
}
