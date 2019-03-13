| [<img src="https://avatars1.githubusercontent.com/u/43104007?s=400&v=4" width=100 alt="GitHub avatar for author claramunro">](https://github.com/claramunro) | [<img src="https://avatars1.githubusercontent.com/u/46427680?s=400&v=4" width=100 alt="GitHub avatar for author LondresRi">](https://github.com/LondresRi) | [<img src="https://avatars1.githubusercontent.com/u/46455727?s=400&v=4" width=100 alt="GitHub avatar for author MarkStrickland562">](https://github.com/MarkStrickland562) | [<img src="https://avatars1.githubusercontent.com/u/43095957?s=400&v=4" width=100 alt="GitHub avatar for author MicaelaDJ">](https://github.com/MicaelaDJ) |
|:-----:|:-----:|:-----:|:-----:|
| [**claramunro**](https://github.com/claramunro) | [**LondresRi**](https://github.com/LondresRi) | [**MarkStrickland562**](https://github.com/MarkStrickland562) | [**MicaelaDJ**](https://github.com/MicaelaDJ) |
| Clara Munro | Shawn Lunsford | Mark Strickland | Micaela Jawor |

## | **eHappenings Project** |

#### By Clara Munro, Mark Strickland, Micaela Jawor, Shawn Lunsford
###### Initiated March 5th, 2019. Updated March 6th, 2019.

----------

## Description
An event planning web application to assist in organizing venues, menus, food, and mood to maximize event success. The applications manages databases take into account menu ingredients and preparation, else catering options, venue details, invitees and their responses or requirements, tasks prioritizing and distributing among event managers, etc.

## Known Bugs

* No known bugs.

## Specifications

| Scenario 01 |             |
|------------:|:------------|
| Behavior    | As an event planner, I need to be able to see a list of events |
| Input       | Click on view events |
| Output      | Return list of all events |
| Notes       | Events should display some details about them |
| Completion  | False |

| Scenario 02 |             |
|------------:|:------------|
| Behavior    | As an event planner, I need to be able to add an event |
| Input       | Click on add/new events, submit form |
| Output      | Return new event form, creates new instance on submit |
| Notes       | Will create one event at a time |
| Completion  | False |

| Scenario 02 |             |
|------------:|:------------|
| Behavior    | As an event planner, I need to be able to set the menu for an event |
| Input       | On new event form, set event menu|
| Output      | Return new event list, with menu set to that event |
| Notes       | One menu for an event |
| Completion  | False |

| Scenario 04 |             |
|------------:|:------------|
| Behavior    | As an event planner, I need to be able to delete a single event |
| Input       | Click on delete/remove event |
| Output      | Delete selected event, return to event list |
| Notes       | Will delete one event at a time |
| Completion  | False |

| Scenario 05 |             |
|------------:|:------------|
| Behavior    | As an event planner, I need to be able to delete all events |
| Input       | Click on delete/remove events |
| Output      | Delete all events, return to event list |
| Notes       | Will delete all events at one time |
| Completion  | False |

| Scenario 06 |             |
|------------:|:------------|
| Behavior    | As an event planner, I need to be able to add tasks to an event|
| Input       | Select task for an event |
| Output      | Add given task to event, return to event list |
| Notes       | Will add one task at a time |
| Completion  | False |

## Setup and Use

#### Prerequisites
* .NET Core 1.1 SDK or higher
* .NET Core Runtime 1.1 or higher
* [Mono](https://www.mono-project.com/)

#### Download Repo
1. Download required software: .NET Core SDK, .NET Core Runtime, Mono
2. Clone [this repository](https://github.com/LondresRi/EventPlanner.Solution): _$ git clone (repo HTTPS TODO)_

#### Open Locally - Browser
1. Navigate to the application directory: _$ cd EventPlanner.Solution/EventPlanner_
2. Execute the commands _$ dotnet restore_, _$ dotnet build_, and then _$ dotnet run_
3. Open the localhost link provided by the terminal in your preferred browser
```
D:\user\EventPlanner.Solution\EventPlanner>dotnet restore
D:\user\EventPlanner.Solution\EventPlanner>dotnet build
D:\user\EventPlanner.Solution\EventPlanner>dotnet run
Hosting environment: Production
Content root path: D:\user\EventPlanner.Solution\EventPlanner
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```

#### Open Locally - Mono
1. Navigate to the working directory: _$ cd EventPlanner.Solution_
2. Use your preferred IDE or editor to edit the project
3. Open the Program.exe file or use _$ mono Program.exe_ to run application

#### Compile Locally
1. Navigate to the project directory: _$ cd EventPlanner.Solution/EventPlanner_
2. Execute _$ mcs Program.cs Models/TODO.cs_ to compile new Program.exe file

#### MySql Database Import
1. Open your preferred database manager
2. Import event_planner.sql
3. Review database to ensure import was successful

```
D:\user>mysql -u root -p
Welcome to the MySQL monitor.  Commands end with ; or \g.
Your MySQL connection id is [Your connection id here]
Server version: [Your server version and system here]

Copyright (c) 2000, 2019, Oracle and/or its affiliates. All rights reserved.

Oracle is a registered trademark of Oracle Corporation and/or its
affiliates. Other names may be trademarks of their respective
owners.

Type 'help;' or '\h' for help. Type '\c' to clear the current input statement.

mysql>USE event_planner;
Database changed

mysql>SHOW TABLES;
Query OK, 0 row affected (0.00 sec)

mysql>DESCRIBE [insert any table name, case sensitive];
Query OK, 0 row affected (0.00 sec)
```

#### Edit
1. Navigate to the working directory: _$ cd EventPlanner.Solution_
2. Use your preferred IDE or editor to edit the project

#### Test
1. Navigate to the working directory: _$ cd EventPlanner.Solution/EventPlanner.Tests_
2. Execute _$ dotnet tests_ to run application tests


## Built With

* TODO
* Linux Ubuntu 18.04 bionic
* Atom (IDE)
* C#
* HTML / CSS
* Bootstrap 3.TODO
* Microsoft SDK
* .NET Core 1.1 - 2.2
* .ASPNetCore
* MySql

## Contributors

| Author | GitHub | Email |
|--------|:------:|:-----:|
| Clara Munro | [claramunro](https://github.com/claramunro) | [clarajmunro@gmail.com](mailto:clarajmunro@gmail.com) |
| Mark Strickland | [MarkStrickland562](https://github.com/MarkStrickland562) |  [markstrickland562@hotmail.com](mailto:markstrickland562@hotmail.com) |
| Micaela Jawor | [MicaelaDJ](https://github.com/MicaelaDJ) | [micaelajawor@yahoo.com](mailto:micaelajawor@yahoo.com) |
| Shawn Lunsford | [LondresRi](https://github.com/LondresRi) |  [lunsford.sk@gmail.com](mailto:lunsford.sk@gmail.com) |

## Credits

| | Clara Munro | Mark Strickland | Micaela Jawor | Shawn Lunsford |
|-|:-----------:|:---------------:|:-------------:|:--------------:|
| **Design** |
| Core Mechanics | |◈| |◈|
| Databases | |◈| | |
| User Interface |◈| |◈| |
| **Programming** |
| Back-End | |◈| |◈|
| Front-End |◈| |◈| |
| Integration |◈|◈| | |
| Refractoring | | | |◈|
| **Visuals** | | | | |
| Wire Frame |◈| |◈| |
| CSS Styling |◈| |◈| |
| Graphics Management | | |◈| |
| **Quality Assurance** |
| Documentation | |◈| |◈|
| Testing | |◈| |◈|

## Support and contact details

If you have any feedback or concerns, please contact any of the contributors (see above).

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). Copyright (C) 2019 [Clara Munro](https://github.com/claramunro), [Mark Strickland](https://github.com/MarkStrickland562), [Micaela Jawor](https://github.com/MarkStrickland562), [Shawn Lunsford](https://github.com/LondresRi). All Rights Reserved.
```
MIT License

Copyright (c) 2019 Clara Munro, Mark Strickland, Micaela Jawor, Shawn Lunsford

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

## Acknowledgments

#### [Epicodus](https://www.epicodus.com/)
>"A school for tech careers... to help people learn the skills they need to get great jobs."

#### [The Internet](https://webfoundation.org/)
> "...the first thing that humanity has built that humanity doesn't understand..."
> - Eric Schmidt, Google (Alphabet Inc.)
