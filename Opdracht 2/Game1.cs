global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
global using System;
global using System.Collections.Generic;
using System.Linq;

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_2;
public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player _player;
    private GameStates _state;
    private Texture2D _buttonTexture;

    private readonly List<GameObject> _titleObjects = new();
    private readonly List<GameObject> _menuObjects = new();
    private readonly List<GameObject> _levelOneObjects = new();
    private readonly List<GameObject> _levelTwoObjects = new();

    private Shield _shield;
    private Sword _sword;
    private Gate _gate;
    private Gate _gate2;

    public static int ScreenWidth { get; private set; }
    public static int ScreenHeight { get; private set; }

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
        _buttonTexture = Content.Load<Texture2D>("Textures/ButtonTexture");
        _state = GameStates.Title;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        TitleLoadContent();
        MenuLoad();

        Random random = new Random();
        _player = new Player(Content.Load<Texture2D>("Textures/Knight"));
        _sword = new Sword(Content.Load<Texture2D>("Textures/Weapon"), random, _player);
        _shield = new Shield(Content.Load<Texture2D>("Textures/Shield"), random, _player);
        _gate = new Gate(Content.Load<Texture2D>("Textures/Gate"), random, _player, this, GameStates.Level2);
        _gate2 = new Gate(Content.Load<Texture2D>("Textures/Gate"), random, _player, this, GameStates.Level1);
        void OnMenuAction() => ChangeGameState(GameStates.Menu);
        Rectangle menuButtonBounds = new Rectangle(0, 0 , _buttonTexture.Width, _buttonTexture.Height);

        LevelOneLoad(OnMenuAction, menuButtonBounds);
        LevelTwoLoad(OnMenuAction, menuButtonBounds);
    }

    private void TitleLoadContent()
    {
        Rectangle buttonBounds = new Rectangle((ScreenWidth - _buttonTexture.Width)/ 2, (ScreenHeight - _buttonTexture.Height )/ 2, _buttonTexture.Width, _buttonTexture.Height);
        Action onClickAction = () => ChangeGameState(GameStates.Menu);
        _titleObjects.Add(new ButtonBase(_buttonTexture, buttonBounds, onClickAction, Content.Load<SpriteFont>("Fonts/ButtonFont"), "Go To Menu"));
    }

    private void MenuLoad()
    {
        Rectangle buttonStartBounds = new Rectangle((ScreenWidth - _buttonTexture.Width) / 2, (ScreenHeight - 100 - _buttonTexture.Height) / 2, _buttonTexture.Width, _buttonTexture.Height);
        Rectangle buttonQuitBounds = new Rectangle((ScreenWidth - _buttonTexture.Width) / 2, (ScreenHeight + 100 - _buttonTexture.Height) / 2, _buttonTexture.Width, _buttonTexture.Height);
        void onClickStartAction() => ChangeGameState(GameStates.Level1);
        void onClickQuitAction() => Environment.Exit(0);
        _menuObjects.Add(new ButtonBase(_buttonTexture, buttonStartBounds, onClickStartAction, Content.Load<SpriteFont>("Fonts/ButtonFont"), "Start Game"));
        _menuObjects.Add(new ButtonBase(_buttonTexture, buttonQuitBounds, onClickQuitAction, Content.Load<SpriteFont>("Fonts/ButtonFont"), "Quit Game"));
    }

    private void LevelOneLoad(Action pMenuAction, Rectangle pBounds)
    {
        _gate.LinkedGate = _gate2;

        _levelOneObjects.Add(_player);
        _levelOneObjects.Add(_gate);
        _levelOneObjects.Add(new ButtonBase(_buttonTexture, pBounds, pMenuAction, Content.Load<SpriteFont>("Fonts/ButtonFont"), "Back To Menu"));

        if (_player.EquippedSword == null)
            _levelOneObjects.Add(_sword);
        if (_player.EquippedShield == null)
            _levelOneObjects.Add(_shield);

    }

    private void LevelTwoLoad(Action pMenuAction, Rectangle pBounds)
    {
        _gate2.LinkedGate = _gate;
        _levelTwoObjects.Add(_player);
        _levelTwoObjects.Add(_gate2);
        _levelTwoObjects.Add(new ButtonBase(_buttonTexture, pBounds, pMenuAction, Content.Load<SpriteFont>("Fonts/ButtonFont"), "Back To Menu"));


        if (_player.EquippedSword == null)
            _levelTwoObjects.Add(_sword);
        if (_player.EquippedShield == null)
            _levelTwoObjects.Add(_shield);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        switch (_state)
        {
            case GameStates.Title:
                _titleObjects.ForEach(obj => obj.Update(gameTime));
                break;
            case GameStates.Menu:
                _menuObjects.ForEach(obj => obj.Update(gameTime));
                break;
            case GameStates.Level1:
                _levelOneObjects.ForEach(obj => obj.Update(gameTime));
                break;
            case GameStates.Level2:
                _levelTwoObjects.ForEach(obj => obj.Update(gameTime));
                break;
        }

        base.Update(gameTime);
    }

    public void ChangeGameState(GameStates pState) => _state = pState;

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.FrontToBack);

        switch (_state)
        {
            case GameStates.Title:
                _titleObjects.ForEach(obj => obj.Draw(_spriteBatch));
                _titleObjects.ForEach(obj => obj.DrawText(_spriteBatch, Content.Load<SpriteFont>("Fonts/TextFont"), "Welcome to The Player!", new Vector2(ScreenWidth / 2, 100)));
                break;
            case GameStates.Menu:
                _menuObjects.ForEach(obj => obj.Draw(_spriteBatch));
                break;
            case GameStates.Level1:
                _levelOneObjects.ForEach(obj => obj.Draw(_spriteBatch));
                break;
            case GameStates.Level2:
                _levelTwoObjects.ForEach(obj => obj.Draw(_spriteBatch));
                break;
        }

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
