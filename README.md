# Invoker (still in development)

![](invoker.gif)

## Game Summary
Invoker is a 2D bullet-hell, adventure game that lets you combine spirits to cast different spells. There are three different spirits that you can use. They represent the three main states of matter: solid, liquid, gas.
You can combine up to three spirits, making the total number of spells to be 19. Spells allow you to damage enemies, maneuver more easily, protect/heal yourself, and 
allows you to creatively combo them to increase their potency. You can poison, stun, and burn enemies. Enemies may inflict these status effects on you as well and may kill you if you don't dispel them with your spells. Stunning or immobilizing the player does not disable spell casting. Spirits are independent to the player. The player can cast spells at any point of the game as long as it's not in cooldown.

Each spirit is given to you one-by-one as you discover and collect them throughout the game.  You can discover what kind of spells you can create by combining them. Each spell has a cooldown on its own, so you have to keep using different spells if you want to constantly dish out damage. Using different spells and killing enemies fills up a combo bar and improves all your spells. Be sure to keep casting and defeating enemies while avoiding taking damage because this bar drains over time and decreases whenever you take damage. The game rewards creativity and fast actions per minute.

Invoker is made using C# and Unity as the engine. I use Aseprite to create the pixel art.

## Mechanics

### Spells

Each spirit is represented as a letter. S for solid, L for liquid, G for gas. These S, L, G, spirits can be combined in many different ways. You can combine up to three. There are 19 total spells each with its own combination:

* S (Boulder Throw) - throw a boulder that damages enemies in an area. Can be used as a double jump if aimed down.  

* L (Icicle Shot) - shoot fast-moving icicles that damage enemies.  

* G (Lightning Strike) - create a lightning strike that deals heavy area damage and stuns enemies.  

* SS (Earth Armor and Shield) -  buff your physical resistance and gain oil status immunity. Take less damage from direct damage for a limited time. Summon a shield that can destroy projectiles on hit.  

* LL (Heal) - heal for a short time and also dispels any negative status effect.  

* GG (Lightning Dash) - dash for a short distance. Damage enemies in between.  

* SL (Ground Slam) - slam the ground damaging enemies in your path. Oils and poisons enemies hit.  

* SG (Ring of Fire) - spin fireballs around you. Damages enemies on impact and burns them. Fireballs destroy projectiles on hit.  

* LG (Poison Explosion) - create a poison bubble that continuously damages enemies in the area. Also applies poison for enemies hit.  

* SSS (Summon Oil Golem) - summon an oil golem that attacks nearby enemies with a projectile that oils enemies that it hits. Useful for blocking enemy projectile.  

* LLL (Hibernate) - gain immunity to all damage and lock player movement for a short time. Dispels negative status effects. Even if you're immobalized, you may still cast spells.

* GGG (Tornado) - create a moving tornado that deals damage and stuns enemies in a huge area.

* SSL (Lava Burst) - shoot molten lava in multiple directions that damages and burn enemies on hit.

* SSG (Wisp) - summon a slow-moving wisp that damages nearby enemies continuously.

* SLL (Solar Flare) - destroy all projectiles on screen and burn nearby enemies.

* SGG (Wings) - gain the ability to fly for a short time.

* LLG (Bubble) - gain negative status effect immunity for a short time. Increase movement speed and jump height.

* LGG (Wind Trampoline) - create an area that increases your jump height drastically. Damages any nearby enemies besides the trampoline whenever it's used.

* SLG (Cooldown Reset) - resets all spell cooldowns. Useful for spell combos.

Each spell has its own cooldown. Using only a few spells may not be enough, you have to utilize your entire arsenal Cast different spells while the others are cooling down. Spells casted using only one spirit will always have a lower cooldown than spells casted using two. This is pattern is true for spells casted with two and three spells. Spells casted with fewer spirits will always have a lower cooldown.

### Combo Bar and Comboing Spells
Casting spells and defeating enemies fills up your combo bar. The combo bar depletes over time. The combo bar has 4 stages that determine how potent your spells will be. Each stage grants each spell different upgrades and additional effects. The stage of the combo bar is determined by how much it's filled.

Casting spells while not hitting enemies is not enough to fill up the bar. Taking damage will slightly decrease the combo bar as well. So make sure you keep defeating enemies while avoiding taking damage.

### Game Areas and Levels
You don't start with all the spells at your disposal. You increase the number of spirits you have as you progress throughout the game. Each spirit you collect makes you stronger. You gain more spells to use to defeat enemies and fill your combo bar. Areas have battlefields where you have to defeat all enemies in the area to progress. Find the key to unlock the exit.

### Status Effects
There are four negative status effects that enemies and the player can have: 

* Poison - deals constant damage. Each tick damage is small but poisons last long.
* Oil - slows movement and decrease jump height. Will increase burning damage.
* Buring - deals constant damage. Each tick damage is big but only lasts quickly. If target is oiled when buring is applied, total burning damage is increased.
* Stun - disables the target for a short time. The player can still cast spells while stunned.


## From the developer

This game allows me to do what I'm passionate about: creating games. Above 90% percent of what you see here is made by myself, art/animation and programming included. I used third-party modules such as CineMachine, LeanTween, TextMeshPro to help me create the game faster. Making this game gives me an opportunity to showcase what I can do with Unity, as well as what kind of art I can produce myself. This game has been in development for some months and I work in it on my free time as a passion project and as a sharpening tool as a programmer. As of now, the name "Invoker" is not set in stone. I may or may not change this name depending on how development goes. I may think of a better name someday.

The game is inspired by a character from DOTA 2. A hero named "Invoker" combines spirits that let him cast different spells. I've also taken insperation from Magicka.
