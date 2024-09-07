# Blatant Zelda Ripoff

## ToDo
- Follow Design Document
- gamestart scene
- gameover scene
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
    - player powerups
      - idk what this is?
      - probably quad damage and health up
  - basic sword enemy
    - damage enemy                      DONE
      - bounce away when damaged        DONE
    - death                             DONE
    - enemy agro pathfinding            DONE
    - enemy attack                      DONE
- scene 3
  - sword enemy                         DONE
  - archer
    - shoot projectile at player
  - health powerup
- scene 4
  - archer enemy
  - sword enemy                         DONE
  - fireguy enemy
    - runs away from player
    - drops fire on ground to dmg
  - quad damage powerup
- scene 5
  - boss
  - health powerup
  - quad damage powerup

- ...
- Submit results to itch.io

##
- lot of bugs on end of game (look at scene view)
- enemies can damage and kill each other!
    bc i am using idamageable and using the same "call" (or whatever the term is) to the Damage method
    leaving it in
