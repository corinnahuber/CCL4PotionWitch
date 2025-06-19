<p align="center">
  <img src="https://github.com/user-attachments/assets/81575a37-8e73-48ed-b636-efc306fe902a" alt="WitchsBrewLogo">
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

<br>

Witch’s Brew” is a dark, low-poly 3D adventure game set in a haunted forest. You play as Raven, a young witch who must collect ingredients, brew magical potions, and banish ghostly enemies that spawn from an ancient graveyard. 
Guided by Wisp, a mysterious moth-like creature, players explore a small open world filled with spooky atmosphere and magical danger. This project was created to apply and combine skills in 3D modeling, animation, 
Unity programming, and game audio. It represents our first complete game developed as a team

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
 Armed only with her cunning and her potions, Raven must face each ghost and banish them all to restore the forest’s peace—or be consumed by the spirits that hunger in the shadows.

### Ending
With the last ghost banished, a calm silence returns to the forest. Raven’s potions have driven away the darkness, and the woods can finally breathe again. 
She stands among the whispering trees, knowing that peace has been restored—at least, for now.

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
To do this, they can craft up to five unique potions, each with its own effect. Ingredients are scattered throughout the world and must be gathered to brew potions at the cauldron inside the witch’s home.
When a ghost appears, the player must quickly choose the right potion and throw it at the ghost to kill it. But beware — if the ghosts get too close and deal too much damage, it's game over!

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
  8. Three different kinds of Pine Trees
  9. Pumpkin
  10. Well
  11. Crystal Ball
  12. Pencil
  13. Cup
  14. Small Desk Storage

- Game Audio
  1. Pickup Sound
  2. Button Click
  3. Book Flipping
  4. Player getting attacked
  5. Different sounds for areas (cave, lake, graveyard,...)
  6. Ambient Sounds (wind, forest, main menu audio)
  7. Ghost Sound
  8. Footsteps

- Unity Coding
  1.
  2.
  3.

- C# & Theory of CG&A
  1.
  2.
  3.

### Implementation Logic Explained
STILL MISSING

### Achievements
- Very proud of the characters we made, it was a long and hard process at times, especially the rigging and weight painting part for it to look good when animating, but we are really proud of the outcome
- We tried to make as many assets as possible ourselves so the whole game would have a nice feel to it, we are very happy with how the world looks and feels like
- We were able to implement almost every function we planned on having, we have a nice combat system, the inventory works really well, the witch is able to brew potions as planned and use them to fight off the ghosts

### Major Challenges and Solutions
- One of the biggest challenges was definitely the rigging part and adjusting the weight painting accordingly, it just took a lot longer than expected
- I faced a lot of challenges in Blender with exporting the right files and also animations not saving, but now I know how to tackle those problems correctly which will safe me a lot of time, energy and struggle in the future

### Minor Challenges and Solutions
- Something I learned when 3D modeling was its very important to keep close attention to the normals of a model, because if the normals are flipped (red) unity won't show those faces, and that can be really painful to fix, the solution is to just always keep checking on the normals in blender

### Reflections on the Project
- The animations could be smoother
- Would have loved to make all the assets ourselves (like mountains, rocks and graveyard)
- Recording some of the audio elements would have been nice



## System Infrastructure
![ClassDiagram](https://github.com/user-attachments/assets/926b4e39-fdb8-4a14-94c6-d99f7624ed8c)

### Update
![ClassDiagram](https://github.com/user-attachments/assets/7e930688-ccdb-4ddb-bd98-aa4144c694bb)


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
  <img src="https://github.com/user-attachments/assets/dc1845d3-b384-4583-afbd-b3f28150be03" alt="Cauldron" widht="150">
</p>

<!-- Witch House Interior -->
<p>
  <img src="https://github.com/user-attachments/assets/20b5bb8c-7ba1-41cb-bd8c-9302cba75b84" alt="WitchHouse01" widht="200">
  <img src="https://github.com/user-attachments/assets/b97e5bc7-2b7f-47e0-9eb5-c165bac3dcfa" alt="WitchHouse02" widht="200">
</p>













