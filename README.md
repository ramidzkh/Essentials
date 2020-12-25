# Essentials

An essential server-side Terraria mod

## Finding libraries

The GAC (Global Assembly Cache) is found in `%windir%/Microsoft.NET/assembly`, from where the four Xna DLLs can be
found. The other Terraria dependencies are embedded inside the Terraria client or server, and can be extracted with a
program like ILSpy. Copy the dependencies required by `Libraries/README.md`

## Client setup

If you wish to run this mod locally on the client

1. Replace `TerrariaServer.exe` with `Terraria.exe` in `Essentials/mixins.json`
2. Replace `TerrariaServer` with `Terraria` in `Essentials/Essentials.csproj` (two lines)
3. You must then copy the Terraria.exe into the `Libraries` folder.

Then follow the instructions below

## Setup

1. Install [`SharpILMixins.Processor`](https://www.nuget.org/packages/SharpILMixins.Processor/) (`dotnet tool install --global SharpILMixins.Processor`)
1. Run `msbuild`
2. Open a command prompt in `Essentials/bin/Debug`
3. Run `sharpilmixins -t . -m Essentials.dll`
4. The generated `TerrariaServer-out.exe` (or `Terraria-out.exe`) should be suitable to replace the original Terraria client or server
