# Hexagonal Chess Program in C#

![Played Game](https://github.com/GarrettSidle/Hexagonal-Chess-Application/assets/91274223/aec30d78-e442-48c1-a0d1-4c908607a6ef)

## Project Overview
This WPF application offers a fresh take on classic chess, bringing hexagonal chess variants—such as Glinski, McCooey, and Hexofen—to a digital platform. Designed with both single and multiplayer modes, it allows users to experience the complexity and strategy of hexagonal chess in an engaging and user-friendly format.

## Software Architecture
The application is built with C#, leveraging WPF for a clean and responsive interface. It features a custom **Breadth-Depth Search** system for move validation, dynamically calculating available moves in real-time and adapting to hexagonal board mechanics. The **modular architecture** facilitates easy addition of new game variants and components, while a lightweight chess evaluation system assesses board positions to guide strategic decision-making.

## Bot / Engine

The application includes a **built-in chess bot** for single-player games. The bot logic lives in a separate C++ engine; for the full source code and build instructions, see the [Hexagonal Chess Engine](https://github.com/GarrettSidle/Hexagonal-Chess-Engine) repository.

The engine uses a material-based evaluation (piece values such as pawn=1, knight/bishop=3, rook=5, queen=9) and searches the game tree with the **minimax** algorithm. To stay fast under tight node limits, it employs several classic chess-engine techniques: **alpha–beta pruning**, **Zobrist hashing** and transposition tables to avoid re-evaluating identical positions, **iterative deepening** to improve move ordering and provide a best move at any depth, and a **killer move heuristic** to prioritize historically strong moves and trigger early cutoffs. The WPF application talks to the engine over stdin/stdout, sending commands like the variant name and moves, and receives the bot’s replies in turn.

## Online Play

The application supports **peer-to-peer** multiplayer, allowing users to play against others with minimal setup. Using **asynchronous communication**, the game ensures smooth turns and state synchronization across devices. Advanced networking features, such as automatic reconnection enhance the multiplayer experience, making it intuitive and accessible.

## Variants

![Settings](https://github.com/GarrettSidle/Hexagonal-Chess-Application/assets/91274223/1c312b42-a860-4c7d-abc7-983ae0f5fc23)

Three unique hexagonal chess variants are implemented: **Glinski**, **McCooey**, and **Hexofen**. Each variant retains its distinct rules and board layouts. The chess engine accommodates each variant’s specific rules, seamlessly adapting move validation and board rendering to suit the selected game type.

### Glinski Variant
![Glinski Board](https://github.com/GarrettSidle/Hexagonal-Chess-Application/assets/91274223/ff578e56-f9e2-427d-bca0-1f8421a45b75)

### McCooey Varient
![McCooey Board](https://github.com/GarrettSidle/Hexagonal-Chess-Application/assets/91274223/b737b718-4a3d-4341-9ee8-084c89e2981d)

### Hexofen Varient
![Hexofren Board](https://github.com/GarrettSidle/Hexagonal-Chess-Application/assets/91274223/e85ffb73-80d7-4917-ab62-ded9ccd62430)


## Other Images

### Home Screen
![Home](https://github.com/GarrettSidle/Hexagonal-Chess-Application/assets/91274223/98988a54-8021-4d25-81db-ef2f4adbe1a0)

### Result Screen
![Settings](https://github.com/GarrettSidle/Hexagonal-Chess-Application/assets/91274223/1c312b42-a860-4c7d-abc7-983ae0f5fc23)