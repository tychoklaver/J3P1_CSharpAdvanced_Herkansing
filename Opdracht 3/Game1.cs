global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
global using System;
global using System.Collections.Generic;

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;

    private SceneBase _currentScene;
    private SceneBase _nextScene;
    private Gate _gate;
    private Gate _gate2;
    private TitleScreenScene _titleScene;
    private Level2Scene _levelTwoScene;
    private WinScene _winScene;
    private LoseScene _loseScene;


    public Texture2D ButtonTexture {  get; private set; }
    public static int ScreenWidth { get; private set; }
    public static int ScreenHeight { get; private set; }
    public MenuScene MenuScene { get; private set; }
    public Level1Scene LevelOneScene { get; private set; }

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ScreenWidth = _graphics.PreferredBackBufferWidth;
        ScreenHeight = _graphics.PreferredBackBufferHeight;
        ButtonTexture = Content.Load<Texture2D>("Textures/ButtonTexture");
        base.Initialize();
    }

    

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        InitializeGameInstance();
    }
    public void InitializeGameInstance()
    {
        _player = new Player(Content.Load<Texture2D>("Textures/Knight"));
        HealthUI healthUI = new HealthUI(Content.Load<Texture2D>("Textures/Heart_full"), _player);

        _titleScene = new TitleScreenScene(this);
        MenuScene = new MenuScene(this);
        LevelOneScene = new Level1Scene(this, _player, healthUI);
        _levelTwoScene = new Level2Scene(this, _player, healthUI);
        _winScene = new WinScene(this);
        _loseScene = new LoseScene(this);

        InitializeGates();

        LoadScenes();

        _currentScene = _titleScene;
        _nextScene = null;
    }
    private void InitializeGates()
    {
        Random random = new Random();

        _gate = new Gate(Content.Load<Texture2D>("Textures/Gate"), random, _player, this, _levelTwoScene);
        _gate2 = new Gate(Content.Load<Texture2D>("Textures/Gate"), random, _player, this, LevelOneScene);

        _gate.LinkedGate = _gate2;
        _gate2.LinkedGate = _gate;

        LevelOneScene.SetGate(_gate);
        _levelTwoScene.SetGate(_gate2);
    }

    private void LoadScenes()
    {
        _titleScene.LoadContent();
        MenuScene.LoadContent();
        LevelOneScene.LoadContent();
        _levelTwoScene.LoadContent();
        _winScene.LoadContent();
        _loseScene.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (ShouldExit())
            Exit();

        // TODO: Add your update logic here
        SwitchSceneIfNeeded();
        _currentScene.Update(gameTime);
        CheckWinLoseCondition();
        base.Update(gameTime);
    }

    public void ChangeScene(SceneBase pScene)
    {
        _currentScene.OnSceneExit();
        _nextScene = pScene;
        _currentScene.OnSceneEnter();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(SpriteSortMode.FrontToBack);
        _currentScene.Draw(_spriteBatch);
        _spriteBatch.End(); 
        base.Draw(gameTime);
    }

    private bool ShouldExit() => GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape);

    private void SwitchSceneIfNeeded()
    {
        if (_nextScene != null)
        {
            _currentScene = _nextScene;
            _nextScene = null;
        }
    }

    private void CheckWinLoseCondition()
    {
        if (_player.EquippedSword != null && _player.EquippedShield != null && LevelOneScene.Level1Collectables && _levelTwoScene.Level2Collectables)
            ChangeScene(_winScene);

        if (_player.PlayerLives <= 0)
            ChangeScene(_loseScene);
    }
}
