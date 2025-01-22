
# Clicker Game Project - AssetBundle, JSON, and Counter

## Game Description:
This is a simple game where the player interacts with a counter. The game loads data from the server, including JSON files for settings and a welcome message, and an AssetBundle containing a sprite for the button's background. The player can increase the counter or refresh the content.
## Features:
- Loading screen with progress bar.
- JSON files with settings and welcome message.
- AssetBundle containing a sprite for the button background.
- Main screen with buttons to increase the counter or refresh content.
- Counter state saving for the next session.
## Technologies Used:
- **AssetBundles** — For dynamic resource loading.
- **JSON** — For storing settings and messages.
- **UniTask** — For async loading and delays.
- **File I/O** — For saving and loading the counter state.
## Game Overview:
The game starts with a loading screen where data (JSON and AssetBundle) is loaded. After loading, the player is taken to the main screen with two buttons:

- **Increase Counter:** Increases the counter by 1 when clicked.
- **Refresh Content:** Loads new data (images and settings) and updates the interface.
The counter state is saved to a file so that the value persists across sessions.

[youtube](https://youtu.be/AKCfeyqWh6w)
