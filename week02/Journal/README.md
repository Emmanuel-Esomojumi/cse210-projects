# Journal Program

## Overview
This is a simple console-based Journal program written in C#.  
It allows users to write daily journal entries, display them, and save or load them from a file.

The project demonstrates the principle of **abstraction** by separating responsibilities into different classes.

## Features
- Write journal entries using random prompts
- Display all saved entries
- Save entries to a file
- Load entries from a file

## Abstraction Design
- `Entry` handles the data and formatting of a single journal entry
- `Journal` manages a collection of entries and file operations
- `PromptGenerator` provides random writing prompts
- `Program` handles user interaction
- This design ensures that changes to one class do not require changes to others.
## How to Run
1. Open the project in Visual Studio or VS Code
2. Build and run the program
3. Follow the on-screen menu options

## Notes
- The `journal.txt` file is created automatically when saving entries.
- No data files are included in the repository.