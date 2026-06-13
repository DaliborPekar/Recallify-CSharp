# Recallify (C#)

Recallify is a simple console-based study tool built in C#. It is a flashcard-style application designed to help practice active recall using a weighted repetition system based on difficulty ratings.

This project is a C# reimplementation of an earlier Python version, built as part of my learning process in programming and software development.

---

## Features

* Study mode for reviewing questions and answers
* Recall mode with weighted random selection
* Difficulty rating system:

  * Easy (e)
  * Medium (m)
  * Hard (h)
* Dynamic weighting based on difficulty:

  * Hard questions appear more often
  * Medium questions appear moderately often
  * Easy questions appear less often
* Ability to re-run study sessions

---

## How It Works

Each question is assigned a difficulty rating. In recall mode, questions are added multiple times into a weighted list based on their rating:

* Hard → 3 entries
* Medium → 2 entries
* Easy → 1 entry

A random question is selected from this weighted list, creating spaced repetition behavior.

After each answer, the user can re-rate the question, which affects future recall sessions.

---

## Project Structure

The program is currently implemented as a single console application containing:

* StudyMode()
* RecallMode()
* Rate()
* DoRestart()

All logic is contained within a single project for simplicity and learning purposes.

---

## Purpose

This project is not meant to be a production-ready application. It is a learning project used to:

* Practice C# syntax and structure
* Understand methods and scope
* Work with arrays and lists
* Learn basic algorithm design
* Experiment with weighted random selection

---

## Future Improvements (Planned)

* File storage for saving questions and ratings
* Load/save sessions between runs
* Improved data structures (classes instead of parallel arrays)
* Better UI formatting in console
* Optional GUI or mobile version (possibly Unity or MAUI)

---

## Technologies Used

* C#
* .NET Console Application
* Visual Studio

---

## Notes

This project was built as part of my learning journey in programming. The focus is on understanding logic and improving problem-solving skills rather than perfect architecture.

---

## Related Project

* Recallify (Python version)

---

## Author

Created as a personal learning project in software development and programming fundamentals.
