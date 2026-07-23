# Pain Component

Pain Component is a dependency/gameplay mod for **The Long Dark** by Hinterland Studios

Pain Component extends a pain and painkiller system for modders to use for their custom afflictions.

## Pain

While the pain affliction has been repurposed, new afflictions that use this system are not without pain. Each pain affliction now has it's own pain level. When an affliction is contracted, the pain level is at it's maximum and will go down over time as the wound heals. Various afflictions have differing levels of pain, but pain will always go down at a consistent rate per affliction. Once the affliction has healed enough and it's pain has reduced to 30% of it's maximum, the effects will be lessened.

The effects of pain depend on the severity, affliction and where it's located. But here's a list of what to expect:

* Blurred and distorted visual effects
* Tunnel vision for concussions and intense pain pulses
* Slower walk speed for lower body injuries on legs and feet
* Slower break down and crafting speed for upper body injuries on arms and hands
* Climbing restriction on ropes and rocks (two hands, hand and arm, both arms, combination of those 3, etc...)
* Slower climbing speed if you are able to climb
* Reading restriction if you have a concussion
* Etc...

## Painkillers

The effects of pain do not go away quickly, your injuries take time to heal. Unlike in vanilla, painkillers will not instantly heal any pain you have. There are no quick fixes. 
Painkillers are a way to temporarily ease the effects of pain. You can take painkillers at any time, even if you have no afflictions. When you take 1 dose (2 pills) of painkillers, it takes 20 minutes in game time to kick in. The new Blood Drug Level counter in your status screen is a UI element that represents how much painkillers you have in your system. Like pain, they will go down over time. It takes 10 hours in game for it to leave your system. The more doses you take, the more the half-life time increases relative to how much you've taken. Additionally, the amount of drugs a dose of painkillers gives is relative to the condition of the meds.

Painkillers will reduce the effects of pain by varying degrees. If your blood drug level is higher than the pain level of an affliction, the painkillers are taking effect. Experiment with this! 

## Emergency Stim

Emergency Stims also act as a painkiller. But instead of taking 20 minutes to kick in, they give an instant 50% administration of drugs into your system. Useful in a pinch!

## Overdose

Painkillers are not without their downsides. Taking too much can result in an overdose! More than 60% blood drug level and you will slowly get tired quicker. The more you take, the more this will worsen. If your blood drug level is higher than 80%, nearing 100%, you will be overdosing. While overdosing, you will get tired significantly quicker and begin to lose condition. As well as stumble around as you are high on the opioids running through your system. 

Overdose will be fleshed out as feedback comes in.

## Installation

* Install MelonLoader by downloading and running [MelonLoader.Installer.exe](https://github.com/HerpDerpinstine/MelonLoader/releases/latest/download/MelonLoader.Installer.exe)
* Install the following dependencies in your mods folder: 

- [AfflictionComponent](https://github.com/TLD-Mods/AfflictionComponent/releases/latest)
- [ModData](https://github.com/dommrogers/ModData/releases/latest)
- [Moment](https://github.com/No3371/TLD-Moment/releases/latest)
- [ModSettings](https://github.com/DigitalzombieTLD/ModSettings/releases/latest)
- [ComplexLogger](https://github.com/Arkhorse/Complex-Logger/releases/latest)

* Install the latest release and drop it in your mods folder
