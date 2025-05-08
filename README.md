# MoVis: Mobility Vision – Smart Helmet Simulation for the Visually Impaired

MoVis (Mobility Vision) is an assistive smart helmet simulation developed using Unity. It is designed to help visually impaired individuals navigate safely by integrating obstacle detection, haptic feedback, and real-time status display. This project simulates a virtual smart helmet that responds to environmental input with tactile and visual cues, providing spatial awareness without relying on vision.

## Features

- Obstacle Detection using Raycasting  
  Detects obstacles in front of the user using Unity’s raycasting system, with a configurable detection range and angle.

- Haptic Feedback System  
  Simulates vibration motors that activate based on proximity. Vibration intensity increases as obstacles come closer (starts at 1.5 units, peaks at less than 0.5 units).

- Status Display HUD  
  A heads-up display shows real-time status such as:
  - “Clear” (no obstacles)
  - “Object in Front” (obstacle within detection range)

- FixedUpdate Optimization  
  Ensures smooth and real-time performance for collision detection and feedback with checks every 0.05 seconds.

- Sprint-based Agile Development  
  Iterative releases with key features added in each sprint. Sprint 3 introduced haptic movement and clear status updates.

## Project Goal

To simulate an affordable, effective, and intuitive wearable navigation system for the blind, providing them with non-visual environmental awareness through haptic and auditory feedback.

## Sustainable Development Alignment

This project aligns with UN SDG Goal 3: Good Health and Well-being and Goal 10: Reduced Inequalities by promoting inclusive assistive technology for the visually impaired.

## Tech Stack

- Game Engine: Unity (C#)
- Physics & Sensors: Unity Raycasting
- UI Elements: Unity Canvas (HUD)
- Version Control: GitHub
- Development Methodology: Agile (Scrum)

## Folder Structure

