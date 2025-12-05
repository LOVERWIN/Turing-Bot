# VR Turing Bot

Un juego educativo de Realidad Virtual para la plataforma PICO, diseñado para enseñar los principios de los **autómatas finitos** de una manera interactiva y visual.

## Concepto Principal

El proyecto simula una máquina expendedora en un entorno de Realidad Virtual. El jugador puede interactuar con la máquina insertando monedas de diferentes denominaciones (5 y 10).

El núcleo del juego es un modelo 3D de un autómata finito que reacciona a las monedas insertadas. Cada vez que el jugador añade una moneda, el autómata transita visiblemente a un nuevo estado (de q0 a q1, q2, etc.), mostrando al jugador cómo una entrada afecta el estado de la máquina.

Cuando el valor total insertado alcanza un "estado de aceptación" (por ejemplo, 20), la máquina expendedora dispensa una botella que el jugador puede coger, completando el ciclo.

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

## Demo y Video
Puedes ver una demostración en del juego en nuestro canal de YouTube:
[▶️ Ver el Tráiler Oficial de Turing Bot](https://youtu.be/xOLFvd0n8RA?si=Fhzry8yPJg5RnXo-)

👥 Créditos y Contribuciones
Este proyecto de Realidad Virtual fue desarrollado por un equipo con los siguientes roles:

Modelado 3D
Fernando Cruz

Creación de todos los modelos 3D base (Autómata Finito, Máquina Expendedora, etc.) utilizando Blender.

Animación, Integración y Desarrollo VR
Erwin Santiago

Exportación y preparación de los modelos 3D al formato FBX.

Maquetado, acomodamiento y diseño de todas las Escenas en Unity.

Toda la Programación en C# para la lógica del Autómata Finito y la interacción del jugador en la plataforma PICO.
