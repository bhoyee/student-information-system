
# Student Information System

## INTRODUCTION AND SCOPE OF PROJECT
This Project’s scope is allowed admin to register student to a program base on a cohort and able to assign modules, assessment and give marks to student base on the program offer and also to be able grade and view over result with grade.

## Admin Activities:

• Create and Manage (Add, View, Delete) Programs
• Create and Manage (Add, View, Delete) Modules
• Create and Manage (Add, View, Delete) Assessment
• Give Marks and Set Grade
• View Over All Student Result

## Definition of operational terms

BLL : This is the Business logic layer . BLL Folder contains all the business logic used in the application. E.g ProgramBLL (this is the business logic for Program module)

IBLL: This is the Business logic layer Interface.

DAL: Data Access Later

DTO: Data Transfer Object

IDAO: This Interface for Data Access Object

DAO : Data Access Object


## Modules Of the System:

### 1.) Program:

Admin can create and manage the Program based on cohort by entering the Program title and selecting the cohort in which the program belongs.

### 2.) Modules:
Admin can create, update, and delete modules. The module will be assigned to a program. One or more modules can be assigned to a problem and 2 or more programs cannot do the same module.

### 3.) Assessment:
Admin can create assessments based on program and module selected. One or more assessments can be added to a module. Admin also has the privilege to edit and delete assessments.

### 4.) Student:
Admin can create, edit and Update student. Admin can also assign students to module, assessment and give score to student.

### 5.) Report:
Admin can view student report which have the details on the student with the grade if the student pass or fail or its undefined


## System Architecture

The system is split into Presentation layer, Business logic layer , Data Layer and the Database
This gives the view of how the system works with the main component and the services they provided and how they communicated between each other.
The System is implemented using Multi-Layer Architecture with Facade Design Pattern and Ado.net to access the database (SQL Server).


### Presentation Layer
This is the most top most level of the application and it’s the user interface which contain the forms and the main function of this interface is to translate the task and result to something user can understand.

### Logic Layer
This contains the business layer (BLL) and this coordinates the app process command and makes logical decision and evaluation as well as performance calculation. It also helps in moving process data between data layer and presentation layer.

The BLL Folder take care of all the business logic of the app which include an Interface that define the core functionality which include INSERT, UPDATE DELETE AND SELECT

### Data Layer :
This the layer that do database processing .
Inside this proceeding I have Data Access Object and Data Transfer Object .
The DTO is able to transfer value between classes and also hold the values together

## USE CASE MODEL
Entity Relationship Diagram
Diagram of data model


## Entity Relationship Diagram


### Note
Grade Student : Student will get Distinction if overall program mark is greater or equal 70 and fail if less than 50.
If less than 50 but greater than 45 that is Pass Compensation.
Module Pass if equal or greater than 50
Undefined is when one module or assessment doesn’t have mark