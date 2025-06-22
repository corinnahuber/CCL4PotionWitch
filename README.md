<p align="center">
  <img src="https://github.com/user-attachments/assets/18ebdba0-e7b9-4110-9a96-54e9519de4f6" alt="WitchsBrew">
</p>


# CCL4
Course: CCL4 SS 2025 (5 ECTS, 3 SWS)
<br>
Student ID: cc231036, cc231032, cc231043, cc231045
<br>
BCC Group: B and C
<br>
Witch's Brew
<br>
by Sara Beslic, Corinna Huber, Helene Urban, Nicoleta Dublea

## Roles
**Sara Beslic**
<br>
Coding, Game Logic
<br>
**Corinna Huber**
<br>
3D Modeling, Documentation, Story and Game Design, Organisation
<br>
**Helene Urban**
<br>
3D Modeling, Game Trailer
<br>
**Nicoleta Dublea**
<br>
UI Design, Game Audio

<br>

Witch’s Brew is a dark, low-poly 3D adventure game set in a haunted forest. You play as Raven, a young witch who must collect ingredients, brew magical potions, and banish ghostly enemies that spawn from an ancient graveyard. 
Guided by Wisp, a mysterious moth-like creature, players explore a small open world filled with spooky atmosphere and magical danger. This project was created to apply and combine skills in 3D modeling, animation, 
Unity programming, and game audio. It represents our first complete game developed as a team.

<br>

# Important Links
### Github Repository
https://github.com/corinnahuber/CCL4PotionWitch

### Documentation
https://corinnahuber.github.io/CCL4PotionWitch/

### Tasks and Task Distribution
[📊 View Task Distribution Sheet](https://docs.google.com/spreadsheets/d/1JoXOu1FA6CLF7Gw7_sG8vjeYPlOJek5lW0gHAlsVlDM/edit?usp=sharing)

### Miro board
https://miro.com/app/board/uXjVINxA_V0=/?share_link_id=535119272679

## Story
In the twilight-drenched forest of Black Hollow, a young witch named Raven stirs her cauldron, desperate to cleanse her haunted home. 
Once a place of peace, the forest is now stalked by restless ghosts, echoes of an ancient curse. These spirits feed on fear, growing stronger in the dark old woods.
 Armed only with her cunning and her potions, Raven must face each ghost and banish them all to restore the forest’s peace — or be consumed by the spirits that hunger in the shadows.

### Ending
With the last ghost banished, a calm silence returns to the forest. Raven’s potions have driven away the darkness, and the woods can finally breathe again. 
She stands among the whispering trees, knowing that peace has been restored — at least, for now.

## Characters
**Main Character**
<br>
(Witch, human)
<br>
Name: Raven

**Side Character**
<br>
(Moth)
<br>
Name: Wisp

**Enemies**
<br>
Ghosts

## Goal
The player’s ultimate goal is to cleanse the forest by defeating all the ghosts haunting the world.
To do this, they can craft up to five unique potions, each with its own effect. Ingredients are scattered throughout the world and must be gathered to brew potions at the cauldron outside the witch’s home.
When a ghost appears, the player must quickly choose the right potion and throw it at the ghost to kill it. But beware — if the ghosts get too close and deals too much damage, it's game over!

## System Design
**Player role:**
<br>
The player takes on the role of a witch in a third-person perspective. To cleanse her haunted forest of ghosts, 
she must brew potions using ingredients found in the woods. 
However, she must remain cautious - ghosts lurk in the shadows.
<br>
**The witch’s Book:**
<br>
Her ancient book contains recipes for potions, listing all the necessary ingredients she must gather. 
Each potion has a unique effect, essential for battling the ghosts.
<br>
**The ghosts:**
<br>
Ghost health depletes based on the potion used (Burn = fast damage etc.). 
Their movement and attack patterns will be polished later to align with the rest of the game visuals and logic.
<br>

![image](https://github.com/user-attachments/assets/f6d642a0-3300-4ea4-8d5d-6f794bae8cf6)


## Key Features and Implementation Detail
- 3D Modeling
  1. Raven (Main Character)
  2. Wisp (Side Character)
  3. Ghost Enemy
  4. Cauldron
  5. 5 Different kinds of Potion Bottles
  6. 8 Different kinds of Collectable Items
  7. Witch House Full Interior
     - Candles
     - Books
     - Desk
     - Stool
     - Broom
     - Carpet
     - 2 Different Plants
     - Mirror
     - Pencil
     - Cup
     - Crystal Ball
     - Small Desk Storage
  8. Three different kinds of Pine Trees
  9. Pumpkin
  10. Well
  
- Animation
  1. Main Character - Raven (Idle, Walk, Jump)
  2. Side Character - Wisp (Idle, LookAround)
  3. Ghost (Hover)
  4. Cauldron (Bubbling)

- Game Audio
  1. Pickup Sound
  2. Button Click
  3. Book Flipping
  4. Player getting attacked
  5. Different sounds for areas (cave, lake, graveyard,...)
  6. Ambient Sounds (wind, forest, main menu audio)
  7. Ghost Sound (main sound and dying)
  8. Footsteps on grass and wood

- Unity Coding
  1. Main Menu scene
  2. Witch House
  3. World
  4. Game Win
  5. Game Over
  6. PotionButton
  7. slot- Ingredient Field in inventory
  8. IngBook - Book Ingredient Field
  9. Ghost - enemy

  **UI**
- WordScene
- PauseMenu - canvas
  - (Panel - bg and Icons)
- CanvasBook - canvas
  - Book - potions and text
  - Ingredients - ingredients for each potion
- CanvasIcons - canvas
  - PotionsInventory - always on-screen bar (length 5)
- PotionsButtons
  - InventoryManager - gray pannel with ingredients
  - Hearts - players lives
- CanvasDialog - conversation box

  **Objects in Main Scene**
  - World - all the items of the world
  - Player - Raven
  - Collectables - holding all ingredients objects scattered around the world
  - Enemies - all ghost prefabs
  - Wisp
  - Witch House - another scene with its own items

- C# & Theory of CG&A
  1. Billboard - ghost bar camera centering
  2. Book (logic) - holds potionsList, manages book state for left and right flip, brews potions, checks for ingredients in inventory, removes used inventory and calls Ui updates
  3. BookToggle - open/ closed
  4. BookUi - Updates book Ui and Ingredients checked
  5. CameraIntro - camera world rotation as intro (there but not added to the scene)
  6. Collectable - key presses for collecting the ingredients (onTrigger)
  7. Dialogue - the conversation logic and Ui update
  8. DontDestroy - tracks items that need to persist
  9. DoorTrigger - triggers the scene change from the world to the house ( works but doesn't teleport correctly)
  10. Enemy - enemies array, takes players hearts and holds the bar
  11. EnemyBar - logic for gradient and slider
  12. EnemyMovements - randomly positions the ghosts inside the nav mesh for the agents in the specified range and sets wander positions. Checks the chase range and players' hearts left to trigger the game over or if all the ghosts are gone. Calls potion throw if ghost clicked
  13. Inventory - stores ingredients slot data, adds items, calls refresh Ui
  14. InventoryFieldUi - Sets and clears Inventory Ui
  15. InventorySlot (simple class)
  16. InventoryToggle- open/closed
  17. InventoryUi - holds invenotryFieldUis and refreshes (updates) Ui
  18. ItemData (scriptable objects)
  19. MenuToggle - open/closed
  20. Player- updates the movement based on key presses, camera angle
  21. PotionData (scriptable objects)
  22. PotionEffects - methods for potion throwing and potion types effects
  23. PotionInvenotry - add/removes potion (logic)
  24. PotionInventoryUi - holds thePotionInventory Update method (the grey boxes at the bottom) and equips the potion
  25. SceneButtons - calling the methods from the gameManager
  26. WhichHouseTrigger - opens the door
  27. WorldSceneManager - all the methods for the scene changes (start, exit..)

### Implementation Logic Explained
- Player collects the ingredients scattered in the world ( prefabs holding Item data).
- Collecting updates inventoryFieldUI and state with ingredient and its quantity.
- Opening the Book for checking the potions ( data stored as a List of potions holding their respective ingredients). Book is updated every time a player collects an ingredient.
- If all the ingredients are there for the potion the Brew button enables brewing.
- Player brews the potion and triggers immediate Update of the book and the Inventory including the potion appearing in the bottom bar.
- Potion that is at the first position is instantly equipped ( purple color) meaning that potion can be used for defeating a ghost. Clicking on a potion we can change which one we are using.
- Damage potion – removes 1/3 of the ghosts health
- Destruction potion – depletes the whole health and ghost is destroyed
- Stun – stops the ghost movement for a few seconds
- Ghost and fighting

Each potion and their effect on the player or the ghost is written in the PotionEffects and then called every tine when a player uses the potion on themselves or on the ghost. Again the use of potion triggers updating of the potion inventory ( bottom bar).
Ghosts are randomly placed around the world using setDestinantion on a navMesh and they roam around the place until they spot a player. If in the given range they start to chase us and the fighting icon appears- the time when we can fight the ghosts. When the icon is gone potion has no effect and cant be used.
If hit by a ghost, ghost goes into cooldown to give us a chance to escape. Every time we are hit the update method checks if we are out of hearts and ends the game if we are dead.

## System Infrastructure
![ClassDiagram](https://github.com/user-attachments/assets/926b4e39-fdb8-4a14-94c6-d99f7624ed8c)

### Update
![ClassDiagram](https://github.com/user-attachments/assets/7e930688-ccdb-4ddb-bd98-aa4144c694bb)

<br>

<p align="center">
<img src="https://github.com/user-attachments/assets/81575a37-8e73-48ed-b636-efc306fe902a" alt="WitchsBrewLogo" width="100">
</p>

<br>

### Achievements
- Very proud of the characters we made, it was a long and hard process at times, especially the rigging and weight painting part for it to look good when animating, but we are really proud of the outcome
- We tried to make as many assets as possible ourselves so the whole game would have a nice feel to it, we are very happy with how the world looks and feels like
- We were able to implement almost every function we planned on having, we have a nice combat system, the inventory works really well, the witch is able to brew potions as planned and use them to fight off the ghosts
- Managed to implement the whole logic as we planned. Biggest achievement is understanding how to make the code reusable and clean and how to reference the data through the classes and pass the necessary data to make all the Updates instant and correct

### Major Challenges and Solutions
- One of the biggest challenges was definitely the rigging part and adjusting the weight painting accordingly, it just took a lot longer than expected
- I faced a lot of challenges in Blender with exporting the right files and also animations not saving, but now I know how to tackle those problems correctly which will safe me a lot of time, energy and struggle in the future
- Handling Item Persistence and Recognition: When collecting ingredients, cloned items weren’t recognized as the same item by the inventory system and the book didn’t update properly. Fixed by correctly passing and referencing to the same item type.
- Inventory UI Index Out-of-Bounds: After using potions and updating the UI, selecting or highlighting potions caused index out-of-bounds errors. Added safety checks to reset selectedIndex if it's invalid, and defaulted to auto-selecting the first potion only if none were selected.
- Wwise Integration Errors: One of the biggest challenges was integrating Wwise into Unity without causing conflicts across branches. After switching from the development branch to wwisedevelopment, Wwise just kept throwing errors when integrating into Unity. After troubleshooting for hours and clearing the Wwise cache from the project's folder, I managed to finally connect Wwise to the project. I finally got help from a teacher who guided me through properly initializing the soundbanks and Ak components, and that resolved the issue.
- Wwise branch merging conflicts with every branch: The Wwise branch caused merge conflicts with nearly every other branch due to the large number of auto-generated files (.bnk, .xml, .json, Unity .meta files) that Wwise modifies. This made it very difficult to integrate the audio work without interfering with unrelated changes in other parts of the project. Due to the limited time and risk of breaking other working features, we decided not to merge the Wwise branch directly into the main development branch. Instead, the partly functional audio implementation can be found in the wwisedevelopment branch, where sound events are integrated and working.

### Minor Challenges and Solutions
- Something I learned when 3D modeling was its very important to keep close attention to the normals of a model, because if the normals are flipped (red) unity won't show those faces, and that can be really painful to fix, the solution is to just always keep checking on the normals in blender
- Challenges Faced in Door Teleportation System: The player didn’t appear in the right place after teleporting or changing scenes. In the beginning the data was also not preserving which when changing the room which is now fixed bot the player is still when teleporting falling in an open space. Tried to fix it but didn’t work so we left it as it is since it doesn’t affect the rest of the game.

### Reflections on the Project
- The animations could be smoother
- Would have loved to make all the assets ourselves (like mountains, rocks and graveyard)
- Recording some of the audio elements would have been nice
- Learned how things really work under the surface and understood the need for planning and structure early on
- All in all we are proud of what we achieved in such a short amount of time, but there are definitely a lot of improvements we could have made if we had more time :)


## 3D Models
<!-- Raven (smaller) -->
<p>
  <img src="https://github.com/user-attachments/assets/9bc6d61b-8b9b-4e07-9e12-943aa2742af8" alt="RavenSideView" width="200">
</p>

<!-- Wisp images side by side -->
<p>
  <img src="https://github.com/user-attachments/assets/53cbb4fe-cc27-40e3-a9ca-5bfd5306d8c2" alt="WispFrontView" width="150">
  <img src="https://github.com/user-attachments/assets/1622e2db-d034-439c-807c-a510047661fe" alt="WispSideView" width="150">
</p>

<!-- Ghost images side by side -->
<p>
  <img src="https://github.com/user-attachments/assets/0b362b88-ae72-481f-8e93-6706488b1e24" alt="GhostFrontView" width="150">
  <img src="https://github.com/user-attachments/assets/d65cf083-0669-4427-b20d-ff4f2a73815c" alt="GhostSideView" width="150">
</p>

<!-- Potion bottles side by side -->
<p>
  <img src="https://github.com/user-attachments/assets/8170665a-20b2-4471-ae83-ab120d051373" alt="PotionBottleHeal" width="100">
  <img src="https://github.com/user-attachments/assets/d6c675a5-96ef-429b-b0b3-2c4f078fe6a2" alt="PotionBottleDamage" width="100">
  <img src="https://github.com/user-attachments/assets/c043cb99-8edc-46bd-9715-feddc8b0ec6b" alt="PotionBottleBlast" width="100">
  <img src="https://github.com/user-attachments/assets/b7775062-e935-49ba-944e-b762cc086325" alt="PotionBottleStun" width="100">
  <img src="https://github.com/user-attachments/assets/75939c77-a305-49a2-83e6-5db7c4a40e10" alt="PotionBottleSwift" width="100">
</p>

<!-- Cauldron -->
<p>
  <img src="https://github.com/user-attachments/assets/dc1845d3-b384-4583-afbd-b3f28150be03" alt="Cauldron" width="150">
</p>

<!-- Witch House Interior -->
<p>
  <img src="https://github.com/user-attachments/assets/20b5bb8c-7ba1-41cb-bd8c-9302cba75b84" alt="WitchHouse01" width="300">
  <img src="https://github.com/user-attachments/assets/b97e5bc7-2b7f-47e0-9eb5-c165bac3dcfa" alt="WitchHouse02" width="300">
</p>

<!-- Collectables -->
<p>
  <img src="https://github.com/user-attachments/assets/212206e8-10f7-445c-b1f1-f4f08ff8d366" alt="Collectables" width="300">
</p>

<!-- Decorations -->
<p>
  <img src="https://github.com/user-attachments/assets/c76206cb-d0b8-431f-95f7-1d96df3a002b" alt="PineTrees" width="300">
  <img src="https://github.com/user-attachments/assets/9fd67d20-511a-4181-b251-a5f3df982322" alt="Pumpkin" width="150">
</p>

<br>
<br>
<br>
<br>
<br>

## In-Game
<p>
  <img src="https://github.com/user-attachments/assets/69e400f8-7772-4f1a-bbff-bd8d80c1891a" alt="Scene01" width="400">
  <img src="https://github.com/user-attachments/assets/96030ea4-5b3b-4eab-bfd0-19cc353084e3" alt="Scene02" width="400">
</p>

<p>
  <img src="https://github.com/user-attachments/assets/5e1d64a7-f737-4b10-9dad-a85291a2f74c" alt="Scene03" width="400">
  <img src="https://github.com/user-attachments/assets/46c749fe-6613-4d69-b2c0-cd1dbc05f0a2" alt="Scene04" width="400">
  <img src="https://github.com/user-attachments/assets/5a37016b-7e1e-4637-a434-3a7a5dbbc2f1" alt="Scene05" width="400">
</p>

<br>
<br>
<br>
<br>
<br>

<p align="center">
<img src="https://github.com/user-attachments/assets/81575a37-8e73-48ed-b636-efc306fe902a" alt="WitchsBrewLogo" width="100">
</p>












