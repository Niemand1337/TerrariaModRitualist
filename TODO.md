## Ideas

### Buff-Adjustment: Eyes On You Blessing
Change text by adding comment that it might guide some projectiles or so.
Make some projectiles homing, when they are shoot while having this effect (else not).

### Buff: Bone Kings Blessing
Increases defense by 7, lifeRegen by 3
Decreases sacrifical damage by 2
Immunity to poison
Something bone related? -> Extra bone projectile? Skull or Skeleton summon?

### Buff: Fiends Blessing
Increases ritualist damage by 11%, speed by 7%, jump height by 5%, defense by 3 and lifeRegen by 2
Grants fire resistance
Summons an imp that fights (same as in fiends contract)
Should only be used for short times

### Weapon: Cursed Weapon
Projectiles are anti-homing and try to evade enemys. Fly straight with Eyes On You Blessing.

### Weapon: Sacrifical Bone Dagger
Skeletron drop
Grants Minor Dark and Bone Kings Blessing

### Weapon Sacrificial Molten Dagger
Crafting: Hellstone and other stuff
Grants Minor Dark and Fiends Blessing
Burns player on-use (longer time than Fiends Blessing protects?)

### Weapon: Crimtane/Demonite Spear
Crafting: Crimtane/Demonite Bars and other stuff
Cost life on usage without dark blessing.
Shoots laser with Eye On You Blessing (So only good at post Cthulhu).
Laser pierces one time with Corruption Blessing.
Crimtane red and Demonite purple color for spear and laser.

### Weapon: Meteorite Spear
Craftig: Meteorite Bars (+ Crimtane/Demonite Spear)
Cost life on usage without dark blessing.
Same projectile als Meteorite Spellbook with Fiends Blessing, but on every third use

### Weapon: Meteorite Spellbook (name bad and mabye not a good idea)
Craftig: Meteorite Bars and stuff comparable to MinorDarkSpellbook
Cost life on usage without dark blessing.
Extremly high cooldown and mana cost.
Minor Corruption Blessing reduces mana cost.
Bone Kings Blessing reduces high cooldown.

### Accessory: Chain with Demonic Blade
Crafting: Sacrifical Demonic Dagger and shackle
Grants Eye on you Blessing on sacrifice.
Increases armor by 2 and ritualist damage by 3%

### Accessory: Fiend's Contract
Flavor text like 'What is the worth of a soul anyway?' or "What is the worth of a soul - in face of true power?"
Summons an imp, shoots only when player has Dark Blessing.
Projectiles should be homing when player has Eyes On You Blessing.
Make sure that MinorCorruption armor pen. applies to imp as well.

### Accessory: Corrupting Cuffs
Äquivalent to Magic Cuffs - Crafted from a (throned) shackle, a band (of Corruption) and an item that ensures it can not directly be crafted
Combine effects from both items - Lose some of the drawbacks (7% jumpheigt and 1 lifeRegen decrease)



## System

### Recipes
Missing for BandOfCorruption



## Needed adjustments

### Sound rework
Currently every item usw has just a random sound. There are Items with missmatches sound, for example a sowrd with a shooting sound.

### Buff Icon
There is no time below the icons. There is an option for that but enabeling it leads to the time being shown to far down.
Reason for that is, that it appears below the image - which is 4 times longer than shown as it is animated and consists of frames.

### PurpleLaserProjectile
Improve the visual - more research and testing with lasers is needed.

### Code
- Improve the namespacing
- Uniform order for variables in SetDefaults() in all items
- Uniform order of function in class for all items
- Leave changes to the accesories, where "player.GetModPlayer<RitualistPlayer>().hasThornedShackle = true;" is in UpdateAccessory and not central in RitualistPlayer on Equipmentchange



## Balancing

### Possible problem - "Worse sacrificial dagger is actually better" or "Using weapons without minor dark debuff is good"
Using an older sacrifical dagger leads t more frequent usage and a worse life to buff ratio, if one tooks the time to recast only on Darknes Blessing end.
Additionally one is missing out on the buffs from the better daggers - in return the accessories on-sacrifice effects will be cast in a shorter interval.
Needs to be consindered to prevent the effects from on-sacrifice to be as good to outweight using a better dagger.