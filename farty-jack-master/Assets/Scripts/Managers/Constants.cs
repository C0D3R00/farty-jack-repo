public enum GameStates
{
    HOME,
    LOADING,
    TUTORIAL,
    PLAY,
    GAME_OVER,
    UNLOADING,
    QUIT
}

public enum SceneNames
{
    HOME,
    GAME
}

public enum InputTypes
{
    NONE,
    TAP
}

public enum CollisionTypes
{
    NONE,
    COLUMN,
    GROUND,
    CEILING
}

public enum ActionNames
{
    START_GAME,
    PASSED_COLUMN
}

public enum ObjectPoolType
{
    COLUMN
}

public enum CameraTypes
{
    FIXED_HEIGHT,
    FIXED_WIDTH
}

public class Constants
{
    public static float ScrollSpeed = -3.5f;
}