namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public class MenuScene : SceneBase
{
    public MenuScene(Game1 pGame) : base(pGame) { }

    public override void LoadContent()
    {
        Rectangle buttonStartBounds = new Rectangle((Game1.ScreenWidth - _game.ButtonTexture.Width) / 2, (Game1.ScreenHeight - 100 - _game.ButtonTexture.Height) / 2, _game.ButtonTexture.Width, _game.ButtonTexture.Height);
        Rectangle buttonQuitBounds = new Rectangle((Game1.ScreenWidth - _game.ButtonTexture.Width) / 2, (Game1.ScreenHeight + 100 - _game.ButtonTexture.Height) / 2, _game.ButtonTexture.Width, _game.ButtonTexture.Height);
        void onClickStartAction() => _game.ChangeScene(_game.LevelOneScene);
        void onClickQuitAction() => Environment.Exit(0);
        _objects.Add(new ButtonBase(_game.ButtonTexture, buttonStartBounds, onClickStartAction, _game.Content.Load<SpriteFont>("Fonts/ButtonFont"), "Start Game"));
        _objects.Add(new ButtonBase(_game.ButtonTexture, buttonQuitBounds, onClickQuitAction, _game.Content.Load<SpriteFont>("Fonts/ButtonFont"), "Quit Game"));
    }
}
