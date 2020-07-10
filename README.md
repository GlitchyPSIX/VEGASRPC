<span style="text-align: center; display: inline-block;">
<img src="images/icon.png" style="max-width: 30%;">

### VEGAS Pro Rich Presence for Discord

Because why not? There wasn't any before.

</span>

## Overview

This is an extension for VEGAS Pro from MAGIX VEGAS 13 (downloadable from MAGIX's website) that enables support for Discord's Rich Presence features.

<img src="images/VEGAS_SS.png">_

## Features

 * Display how many tracks of both Audio and Video you're currently editing.

 * Displays whether you're rendering, and how much time has passed since you started, whether you cancelled, failed, or finished successfully.

 * Displays when you're just being lazy (no activity in one minute, lol)

 * Displays a logo related to your VEGAS version as well as its specific version on hover.

## Roadmap

 - [x] Basic functionality stated above
 - [x] Able to turn on and off the Rich Presence
 - [ ] Change the old discord-rpc.dll with the new Game SDK library
 - [ ] Small key icons for when you're recording, etc...
 - [ ] Compatibility with Sony Vegas (Vegas Pro 12 and lower)

## Requirements

 * MAGIX (not Sony) VEGAS Pro 13 and above (64-bit)
   * This does **NOT** work in Movie Studio!
 * .NET Framework 4.5

## Install Instructions

Grab the latest `"VEGASRPC.zip"` from the [Releases tab](https://github.com/GlitchyPSI/VEGASRPC) and extract its contents in **My Documents/Vegas Application Extensions** or **C:/ProgramData/Vegas Pro/Application Extensions** (Only one of these!).

## Building

To build this extension, you need:
 * MAGIX VEGAS Pro 13 or later,
 * Visual Studio 2017
 * .NET Framework 4.5

Drag your MAGIX VEGAS's ``ScriptPortal.Vegas.dll`` into the folder ``Libraries`` inside the "VEGAS4Discord" folder. This is because the library for VEGAS Scripting cannot be distributed.

## License

MIT. see LICENSE for more details.