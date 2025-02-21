# Student Management System

A simple console application for managing student records using Entity Framework Core with SQLite database.

## Features

- Add new students
- List all students
- Search students by name
- SQLite database for data persistence


## Usage

The application provides a menu-driven interface with the following options:

1. **Add Student**
   - Enter student's first name
   - Enter student's last name
   - Enter date of birth (format: DD.MM.YYYY)
   - Enter email address

2. **List All Students**
   - Displays all students in the database
   - Shows ID, name, date of birth, and email for each student

3. **Search Student**
   - Search students by first name or last name
   - Displays matching results with full details

4. **Exit**
   - Closes the application

## Database

The application uses SQLite as its database. The database file (`StudentDb.db`) is automatically created in the project root directory when you run the application for the first time.

## Project Structure

- `Program.cs`: Main application logic and user interface
- `Models/Student.cs`: Student entity model
- `Data/StudentContext.cs`: Database context class
- `StudentDb.db`: SQLite database file

