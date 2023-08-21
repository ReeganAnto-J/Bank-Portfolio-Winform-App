# Bank system based CRUD application
## WinForm portfolio micro-project by Reegan Anto.J

#### Introduction:
This is a simple CRUD application which is built using WinForms. I have also implemented many necessary constraints within this program such that it handling almost every possible user errors.

I made this project in order to express my skills in C# programming language and the underlying .NET framework.

Most of the program is written by myself hence I wouldn't consider this program to be anywhere close to be perfect or optimized; but in all honesty I recieved some help from Stack Overflow and GPT 3.5 for some file handling and basics of WinForms. This is my first ever winform application so don't expect this to be anywhere close to good.

I am a third year student in the Artificial Intelligence and Data Science department of Adhi College of Engineering and Technology, and would appreciate any help you could provide me which could potentially improve my skills.

#### Key skills I applied in this project (In my humble opinion):
- Applying OOPs concept using C#
- File Handling
- Normalization and Specialization of data and files
- Exception handling
- Effecient state transwer
- Dynamic data handling from different files
- Basics of WinForms
- Using debugging tools offered by Visual Studio
- Problem solving

Below I will explain the program file by file.

# State Diagram:
![StateDiagram](BankStateDiagram.jpg)

# Forms:
### LoginForm
----------------
This is the first form you would see after Form1 (Introduction Form)
This form acts as the main menu for the user
#### New account
Opens the CreationForm
#### Existing account
Opens the default VerificationForm
#### Delete account
Opens the delete version of VerificationForm

### CreationForm
----------------
This form is used to create an user account
Takes Name, DateOfBirth, password, password confirmation
#### Constraints:
- No input box should be empty (Applies to all boxes)
- Name should only contain letters, spaces and dots, and is limited to 15 characters
- Age should be atleast 18 years old
- Name and DOB combination should be unique
- Password must have 4 digits, numbers only
- Password and password confirmation must be same
#### Storage
- The values are stored in Details.csv
- Auto indexing, which acts as primary key (I wrote the code for auto-indexing myself)
- Automatically fills deleted spaces and takes the index of the deleted value
- Saves index,name,DOB in Details.csv
- Saves index,password in Password.csv
- Saves index,0 in Balance.csv

### VerificationForm
--------------------
If the user chose the existing account button in the LoginForm it opens the default verification mode
It takes name and DOB, if it exists in Details.csv, the user is sent to DriverForm

If the user chose the Delete account button it opens the form in delete mode
Password and a confirmation box which asks the user to enter "DELETE" will be added to default mode
If the credentials match the value in all 3 data files will be replaced by ""

### DriverForm
---------------
(Note: The entire driver form runs on single account and one must log out and log back in to switch account)
If the user is verified in the default VerificationForm this form will be opened
It has 3 choices Deposit, Withdraw and CheckBalance all modifies this same form instead of creating new instances

#### Deposit
Asks the password from the user
Adds the specified value to the amount to the balance
It doesn't allow int overflow, I used int32 because 2000000000 seems to be a lot of money regardless of what currency you use,
It also doesn't accept negative value

#### Withdraw
Asks password from user
Removes specified value from balance as long as balance doesn't go below 0

#### Check Balance
Returns balance when user inputs the correct password


# Script
The 3 scripts are the heart of the program, I made these scripts to act as file handler, driver and variable handler. 

### AccountManagementScript
---------------------------
This script contains all file handling code except for the driver form

### DriverScript
----------------
This script contains all necessary operation and performs file handling for the driver form

### InputProperties
-------------------
Contains an abstract class which stores all the properties (getters and setters) in this program which is also responsible for enfocing most constraints



# Conclusion
This project wouldn't be that big of a deal to many but I really enjoyed building this project and this means a lot to me.

Practical application of coding feels new compared to endlessly working on console applications.

I would be really happy to hear your thoughts about my program so feel free to comment, it would really help me improve as a programmer

In case if you happen to be or planning to work on some project and need some aid, feel free to contact me on https://www.linkedin.com/in/reegan-anto-j/

Thanks for reading and I hope you would have a wonderful day
Happy coding!
