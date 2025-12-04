# Murder Mystery: Release v1.0
## Unity Play Link: https://play.unity.com/en/games/c64c5846-aff9-46d5-8dca-483031757a82/webbuild1 
### By Jenna Hopkins, December 4th, 2025

## Part 1: About The Project
### Project Title & Description
- The game Murder Mystery is a puzzle-adventure genre inspired by the social games ‘Mafia’ and ‘Clue’. Players are a detective driving in a car around crime-scene neighborhoods trying to find and pick up clues to solve a murder. Collect enough evidence and get to the murderer’s house before the timer runs out to successfully arrest the murderer and restore justice to the neighborhood. Levels start off simple, but as players get more skilled at their detective skills the murders will become harder and harder to solve, separating the extraordinary detectives from the rest.
### How to Install & Play
- This game is published on Unity Play, so all players need to play it are a computer and access to the internet.
- Use the W-S or up-down arrow keys to move forwards and backwards, and the A-D or left-right arrow keys to steer. Click on people in the neighborhood to talk to them and try to figure out what happened. Click on potential clues to the murder to learn more about them and pick them up. There is limited inventory space at the bottom of the screen to store clues, though, so choose wisely. Clicking on a clue in inventory will drop it to make space for new ones. By the time the timer runs out, you need to have picked up the right clues and have brought them to the murderer to solve the case and restore justice to the neighborhood!
- If you are confident you’ve solved the murder before the timer runs out, click the ‘End Level Early’ button on the top right corner to bypass the rest of the timer and see if you were right. Click the pause button at the top center of the screen to pause the level and have the chance to return to the main menu or resume the level. At the main menu, click on any of the unlocked levels to play them. Unlock levels by solving the murder in the previous one!
### Controls
- W-S or up-down arrow keys for forwards/backwards movement
- A-D or left-right arrow keys for left/right steering
- Left click for clicking on people, clues, and buttons in the game
### Features
#### Gameplay
- Fully designed and functional Levels 1–3
- Player-controlled car movement (WASD / Arrow Keys; forward, backward, steering)
- Collectible clue system with world interactions
- Character interaction popups when talking to NPCs
- Inventory system with limited slots and UI display
- Ability to drop clues back into the world
- Level win/loss logic based on required clues and proximity to the murderer
- Different timer lengths per level for adjustable difficulty
#### UI & UX
- Start-level and end-level popup screens
- Timer countdown UI with color warning and sounds under 10 seconds
- Early end-level button
- Pause menu with return-to-main-menu option
- Main menu with level select screen
- Levels unlock only after previous level is completed
- "How to Play" popup from the main menu
- Inventory UI visible during gameplay
#### Audio
- Background music for:
- Main menu
- Individual levels
- End-level sequence
- Car engine movement sound (looping)
- Clue pickup and click sound effects
- Clock tick sound when time <= 10 seconds
- Centralized AudioManager handling all playback
#### Progression & Persistence
- PlayerPrefs saving:
- Completed levels
- Level unlock progression
- Level transitions and ability to replay or proceed to next level

## Part 2: Development Info
### Assets & Resources Used
- Police Station: “Simple Generic Buildings - Cartoon Buildings” by Studio Horizon on Unity Asset Store
- Police Car: “Police Car & Helicopter” by SICS Games on Unity Asset Store
- Neighborhood Houses: “House Pack” by Mehdi Rabiee on Unity Asset Store
- Flowers: “Pixel Art Flower Pack” by karsiori on Unity Asset Store
- Napkin: “Garbage Bag” by emgidev on OpenGameArt.org
- Gardening Shears: “Gardening Set” by Name By Another Rose on OpenGameArt.org
- Wrench: “Wrench” by Santoniche on OpenGameArt.org
- Dead Man Body: “Person accidently fell lying on the ground-” by fiore26 on Shutterstock
- Rose Petal: “Petal Flower, Rose petal, 3D Computer Graphics, flower png” on pngegg.com
- Background Grass and Dirt: Professor Cordova’s 2D Car Assets
- People, Caution Tape, Goggles, Blood Drips: free Google images
- Mallet & Toolbox: “CC0 Tool Icons” by AntumDeluge on OpenGameArt.org
- Footprints: “Footprint/ shoeprint silhouette” by KobatoGames on OpenGameArt.org
- Flashlight: “CC0 Light Icons” by AntumDeluge on OpenGameArt.org
- Floodlights: “Street Lamp” by Varkalandar on OpenGameArt.org
- Pause Button: “GUI Pack” by trezegames on OpenGameArt.org
- Electric Panel: “Energy Box” by Khar03 on OpenGameArt.org
- Car Engine Sound: “Engine Sound” by kurt on OpenGameArt.org
- Pickup Clue Sound: “Opening and Closing a Map Sounds” by Spring Spring on OpenGameArt.org
- Click on Clue Sound: “Dry Bushes” by sinny on OpenGameArt.org
- Level Background Music: “free Music background (looping)” by Ali Hraich on OpenGameArt.org
- Main Menu Music: “Menu Music” by mrpoly on OpenGameArt.org
- Clock Tick Sound: “Ticking clock.” by bart on OpenGameArt.org
- End of Level Music: “At the end of hope” by Emma_MA on OpenGameArt.org
- Gloves: “Loyalty Lies Equipment - Gauntlets & Brass Knuckles” by Emerald on OpenGameArt.org
- Rag: “Animal fat pixelart” by Hiross on OpenGameArt.org
- Gas Can: “Gas tank - pixel art” by ArlanTR on OpenGameArt.org
### Technical Details
- Unity version 6000.2.2f1
- In addition to the built-in packages from Unity’s Universal 2D template, I used the TextMeshPro, InputSystem, and Cinemachine packages
- No known issues or bugs

## Part 3: Reflection
### What Went Well
    I’m most proud of the code I wrote to determine the win/loss conditions at the end of the game. It was easy to think of what I wanted the conditions to be, but harder to connect that to the Unity objects in the game to compare to the conditions. I think the end-game logic implementation is a good example showing what I’ve learned through this course and how Unity interacts with the code I’m writing.
### What Was Challenging
	The hardest part of developing this game surprised me. It was challenging to write all the code and figure out how I wanted everything to connect, but what took the most time and effort was by far all of the visual elements. It was challenging to find images and sprites that were 2D, represented what I wanted, matched the style that I wanted, and were free. Sometimes I would get 3D assets and take screenshots as a cheat way to turn it into 2D. In addition, placing all the assets in each scene and setting everything up in the inspector took longer than I anticipated. Lastly, the UI was hard to create so it looked just how I wanted it to. I had to constantly change and check the placement of the UI elements so it would look right and scale well. Overall, the visual elements were the most challenging to implement in my game, but it also is what makes the game worth playing and entertaining.
### What I Learned
	Through creating this game, I learned the most about the design of games and how everything fits together. I created many different classes and files to control different aspects of my game, and throughout that process I had to connect them to how they would be used in the game by assigning them in the inspector and creating scriptable objects. Before I started to build this game I had a vague understanding of what scriptable objects were and how you created and used them in a game, but now I have a better understanding of how they are made, used, and important to game development. There’s too many to list them all, but I understand scriptable objects, singletons, event actions, and more so much better after going through this process.
### Version 2.0 Ideas
	If I choose to continue to develop this game, some ideas I have for v2.0 are adding more levels, hints for if the user fails to catch the murderer, volume control settings, and sound effects when the player clicks on a person in the game. With these additions, Murder Mystery can be taken to the next level and even more entertaining to play!