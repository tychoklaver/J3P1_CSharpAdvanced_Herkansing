global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
global using System;
global using System.Collections.Generic;

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_1;
public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    private Player _player;

    private readonly List<GameObject> _gameObjects = new();

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

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        Random random = new Random();
        _player = new Player(Content.Load<Texture2D>("Textures/Knight"));
        Sword sword = new Sword(Content.Load<Texture2D>("Textures/Weapon"), random, _player);
        Shield shield = new Shield(Content.Load<Texture2D>("Textures/Shield"), random, _player);
        Gate gate = new Gate(Content.Load<Texture2D>("Textures/Gate"), random, _player);

        _gameObjects.Add(_player);
        _gameObjects.Add(sword);
        _gameObjects.Add(shield);
        _gameObjects.Add(gate);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _gameObjects.ForEach(obj => obj.Update(gameTime));

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.FrontToBack);
        _gameObjects.ForEach(obj => obj.Draw(_spriteBatch));
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
