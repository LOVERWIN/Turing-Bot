# VR Turing Bot

Un juego educativo de Realidad Virtual para la plataforma PICO, diseñado para enseñar los principios de los **autómatas finitos** de una manera interactiva y visual.

## Concepto Principal

El proyecto simula una máquina expendedora en un entorno de Realidad Virtual. El jugador puede interactuar con la máquina insertando monedas de diferentes denominaciones (5 y 10).

El núcleo del juego es un modelo 3D de un autómata finito que reacciona a las monedas insertadas. Cada vez que el jugador añade una moneda, el autómata transita visiblemente a un nuevo estado (de q0 a q1, q2, etc.), mostrando al jugador cómo una entrada afecta el estado de la máquina.

Cuando el valor total insertado alcanza un "estado de aceptación" (por ejemplo, 20), la máquina expendedora dispensa una botella que el jugador puede coger, completando el ciclo y proporcionando una recompensa tangible por haber completado la secuencia correcta de entradas.

## Tecnología Utilizada

*   **Motor:** Unity
*   **Plataforma de RV:** PICO
*   **SDK:** PICO Unity Integration SDK

## Cómo Empezar

Para ejecutar este proyecto, necesitarás:
1.  Clonar el repositorio.
2.  Abrir el proyecto con una versión compatible de Unity.
3.  Asegurarte de que el SDK de PICO para Unity esté correctamente configurado en el proyecto.
4.  Construir y ejecutar la escena principal `Game.unity` en un dispositivo PICO.
