# Lutra Game Framework - Audio Library - FMOD

This library allows you to integrate FMOD audio into a Lutra game.

Thankfully, somebody already made a nicer C# FMOD wrapper than the very basic one provided by FMOD: [ChaiFoxes.FMODAudio](https://github.com/Martenfur/ChaiFoxes.FMODAudio).
The only catch is that it was designed specifically with MonoGame in mind, so this is a fork which removes any MonoGame specific code.
The FMOD dependency has also been updated to the latest version at time of writing (2.02.03).

Big thanks to the devs of ChaiFoxes.FMODAudio for doing most of the hard work so I didn't have to :)

## Setup

Initial setup is a little fiddly, since the FMOD native library binaries must be downloaded and installed manually.

At the time of writing, there are no example projects for this library yet.

### Initial Steps

**NOTE: The current version of the library is made for FMOD 2.02.03. Later versions may also work, but there is no guarantee.**

**Step 1:** Visit the [FMOD Download page](https://www.fmod.com/download) (accessing it requires registration), then download the *FMOD Engine* for your choice of Windows, macOS, and/or Linux.
Some platform APIs require installation, while some are just in an archive.

**Step 2:** Add this repo as a submodule to your Lutra game project and reference `Lutra.FMODAudio.csproj` directly.
Until I make a Nuget package, this is the best way to do it.

**Step 3:** Make sure your Lutra game project has `lib` directory at the top level, containing `x86` and `x64` dirs.

**Step 4:** Make sure libs will be copied to the output directory by adding the following to your `csproj`:

    <ItemGroup>
      <Content Include="lib/**/*.*">
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      </Content>
    </ItemGroup>

### FMOD Libraries

For each OS API you are installing, navigate to `/api/core/lib`. 
You will see two directories: `x86` and either `x64` or `x86_64`.
You'll need all the `fmod`, but not the `fmodL`, files.

Copy corresponding versions of `fmod` files into your project under `lib/x86` and `lib/x64`.

And that's cross-platform desktop FMOD!
Mapping the library names for different platforms is already done internally, so no need to worry about that.

### FMOD Studio Libraries

FMOD Studio setup process is exactly the same, but you'll need to navigate to `/api/studio/lib` instead. 

**NOTE: It's very important that all your native libs are for the same FMOD version.**

## License

Unlike the main Lutra libs, this library is licensed under [MPL 2.0](http://mozilla.org/MPL/2.0/).
This is due to being based on an existing MPL 2.0 licensed codebase.

You can still use this library in any larger work, including free or commercial works, distributed under different terms.

However, remember that FMOD has its own [license](https://fmod.com/licensing), which has much more restrictive terms.
