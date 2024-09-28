/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

using Game10003;
using Raylib_cs;

/// <summary>
///     The main underlying program. DO NOT EDIT.
/// </summary>
[GeneratorTools.OmitFromDocumentation]
public static class Program
{
    private static void Main()
    {
        // Create game instance
        Game game = new();

        // Raylib one-time setup
        Raylib.InitWindow(Window.Width, Window.Height, Window.Title);
        Raylib.SetTargetFPS(Window.TargetFPS);
        Raylib.InitAudioDevice();

        // Wrapper setup
        Text.Initialize();
        game.Setup();

        // Raylib & wrapper frame loop
        while (!Raylib.WindowShouldClose())
        {
            // Update music buffers every frame
            foreach (var music in Audio.LoadedMusic)
                Raylib.UpdateMusicStream(music);

            // Run game frame
            Raylib.BeginDrawing();
            game.Update();
            Raylib.EndDrawing();

            // Update rendered frame count
            Time.FramesElapsed++;
        }

        // Unload assets
        foreach (var music in Audio.LoadedMusic)
            Audio.UnloadMusic(music);
        foreach (var sound in Audio.LoadedSounds)
            Audio.UnloadSound(sound);
        foreach (var font in Text.LoadedFonts)
            Text.UnloadFont(font);
        foreach (var texture in Graphics.LoadedTextures)
            Graphics.UnloadTexture(texture);
        // Proper shutdown
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }
}