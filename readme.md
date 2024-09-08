# Blatant Zelda Ripoff

## Instructions
WASD controls player movement
Mouse cursor controls player facing
Spacebar "stabs" in front of player with a sword
Green boxes are platforms to next/previous levels

Purple sphere is melee enemy who rushes you
Yellow box is archer enemy who will fire arrows and run if player gets close
Orange sphere is fireguy enemy who drops flame traps
Red capsule at the end is Big Bad Evil Guy

## Features
- Players and enemies knocked back when damaged
- Enemy death persistence
- Enemy melee attacks and arrows damage other enemies

## Bugs
- Ramming enemies cause them to float off indefinitely, and through the boundaries of the scene

## ToDo
- Follow Design Document
- gamestart scene                       DONE
- gameover scene                        DONE
- scene 1
  - wasd movement                       DONE
  - sword slash in front                DONE
  - always face mouse                   DONE
- scene 2
  - camera locks on scene               DONE
  - scene switch when player leaves     DONE
  - singleton
    - enemy death status                DONE
    - player health                     DONE
    - gameover when health reaches 0    DONE
  - basic sword enemy
    - damage enemy                      DONE
      - bounce away when damaged        DONE
    - death                             DONE
    - enemy agro pathfinding            DONE
    - enemy attack                      DONE
- scene 3
  - sword enemy                         DONE
  - archer
    - runs away from player             DONE
    - shoot projectile at player        DONE
  - health powerup
- scene 4
  - archer enemy                        DONE
  - sword enemy                         DONE
  - fireguy enemy
    - runs away from player             DONE
    - drops fire on ground to dmg       DONE
  - quad damage powerup
- scene 5
  - boss                                DONE
  - health powerup
  - quad damage powerup
- Submit results to itch.io
