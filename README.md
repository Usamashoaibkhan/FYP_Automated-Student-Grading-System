<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&height=220&color=0:000000,50:0d1117,100:1f2a44&text=Student%20Grading%20System&fontColor=58a6ff&fontSize=50&fontAlignY=40&desc=AI%20Powered%20Automated%20Grading%20Platform&descColor=c9d1d9&descSize=18&descAlignY=62" width="100%" alt="Banner"/>

<a href="https://github.com/Usamashoaibkhan/Automated-Student-Grading-System">
  <img src="https://readme-typing-svg.demolab.com?font=Orbitron&weight=700&size=26&duration=3000&pause=1000&color=58A6FF&background=00000000&center=true&vCenter=true&width=720&lines=%F0%9F%8E%93+AUTOMATED+STUDENT+GRADING+SYSTEM;NLP+%2B+LLM+%2B+ML.NET;Grade+Faster.+Grade+Fairer.;Role-Based+Web+Platform" alt="Typing title"/>
</a>

<br/>

**An AI-powered, role-based web platform that automatically evaluates Word-based assignments and quizzes using NLP and Large Language Models.**

<br/>

<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
<img src="https://img.shields.io/badge/ASP.NET_Core_MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white"/>
<img src="https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white"/>
<img src="https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black"/>

<br/><br/>

<img src="https://img.shields.io/badge/Final_Year_Project-0d1117?style=flat-square&labelColor=161b22&color=58a6ff"/>
<img src="https://img.shields.io/badge/BS_Computer_Science-0d1117?style=flat-square&labelColor=161b22&color=3fb950"/>
<img src="https://img.shields.io/badge/University_of_Southern_Punjab-0d1117?style=flat-square&labelColor=161b22&color=f78166"/>

</div>

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## 📌 Overview

> Manual grading is slow, inconsistent and delays student feedback.

This system solves that by combining **automated NLP-based grading** with **instructor review**, so grading is fast, fair and transparent.

Students submit their work as **Word (`.docx`) files**, and the system **automatically reads and evaluates the Word file on its own**, assigning marks and generating feedback using an LLM and a rule-based engine. Teachers can then review, adjust and publish the final results. Students see their marks, GPA, grade and personalised feedback in their own dashboard.

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## 🎬 Demo

<div align="center">

<a href="https://drive.google.com/file/d/1OAUfslDyeX8Gy8vxNZ1dXmRGcfecWy8W/view?usp=drive_link"><img src="https://img.shields.io/badge/🎥_Watch_Demo_Video-161b22?style=for-the-badge&logo=googledrive&logoColor=white"/></a>
<a href="https://drive.google.com/file/d/1PzGv9T7Gh7-9kijBqL4RPdfv9r3TUpcG/view?usp=drive_link"><img src="https://img.shields.io/badge/📄_Read_FYP_Report-161b22?style=for-the-badge&logo=readthedocs&logoColor=white"/></a>

</div>

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## ✨ Features

<table>
<tr>
<td width="33%" valign="top">

### 👨‍💼 Admin
- Manage departments, subjects, semester-wise subjects, teachers and students
- View, update and delete student results
- Dashboard with institution-wide summary

</td>
<td width="33%" valign="top">

### 👩‍🏫 Teacher
- Upload assignments with due dates and track student submissions
- **Automatic evaluation of Word files**: the system reads the submitted `.docx` itself and assigns marks using NLP, for both assignments and quizzes
- Manual override of predicted marks and custom feedback
- Enter attendance, midterm and final marks; **total, GPA and grade** are calculated automatically
- Visual dashboard with grade distribution and GPA charts
- **At-risk student detection** (GPA below 2.0) with direct feedback messaging

</td>
<td width="33%" valign="top">

### 🎓 Student
- View assignments, deadlines and submission status
- Upload answers in `.docx` format
- View detailed results and teacher feedback
- Reply to teachers through the notification module

</td>
</tr>
</table>

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## 🧠 How the Grading Works

```mermaid
flowchart TD
    A["📄 Student uploads assignment / quiz (.docx)"] --> B["⚙️ System automatically extracts and cleans text from the Word file"]
    B --> C["🤖 DeepInfra LLM<br/>grammar, relevance, structure"]
    B --> D["📐 Rule-based NLP with ML.NET<br/>keywords, similarity, structure"]
    C --> E["🎯 Predicted marks + feedback"]
    D --> E
    E --> F["👩‍🏫 Teacher reviews / adjusts"]
    F --> G["🏆 Final result: marks, GPA, grade"]
```

This hybrid approach combines the context awareness of an LLM with the transparency of rule-based scoring.

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## 🛠️ Tech Stack

<div align="center">

<img src="https://skillicons.dev/icons?i=cs,dotnet,html,css,js,bootstrap,git,github,visualstudio&theme=dark&perline=9" alt="Tech stack"/>

<br/><br/>

<img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white"/>
<img src="https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/ML.NET-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/DeepInfra_API-0d1117?style=for-the-badge&logo=openai&logoColor=58a6ff"/>
<img src="https://img.shields.io/badge/Meta--LLaMA_3_8B-0467DF?style=for-the-badge&logo=meta&logoColor=white"/>
<img src="https://img.shields.io/badge/OpenXML_SDK-D83B01?style=for-the-badge&logo=microsoftword&logoColor=white"/>

</div>

<br/>

| Layer | Technology |
|:---|:---|
| ⚙️ Backend | C#, ASP.NET Core MVC, Entity Framework Core |
| 🎨 Frontend | HTML, CSS, JavaScript, Bootstrap |
| 🗄️ Database | Microsoft SQL Server |
| 🤖 AI / NLP | DeepInfra API (Meta-LLaMA 3 8B Instruct), ML.NET, OpenXML SDK |
| 🧰 Tools | Visual Studio 2022, GitHub |

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## 🗂️ Project Structure

```
Test2/
├── Controllers/    Request handling and business logic
├── Models/         Academic entities (Student, Teacher, Subject, ...)
├── ViewModels/     Data passed to views
├── Views/          Razor views for Admin, Teacher and Student
├── Data/           Database context
├── wwwroot/        Static files (CSS, JS, images)
├── Program.cs
├── appsettings.json
└── script.sql      Database script
Test2.sln           Visual Studio solution
```

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 (ASP.NET workload)
- .NET SDK matching `Test2.csproj`
- Microsoft SQL Server
- A DeepInfra API key

### Installation

1. **Clone the repository**

```bash
git clone https://github.com/Usamashoaibkhan/Automated-Student-Grading-System.git
```

2. **Open** `Test2.sln` in Visual Studio 2022.
3. **Create the database** by running `Test2/script.sql` in SQL Server.
4. **Configure** `Test2/appsettings.json` with your own database connection string and DeepInfra API key.
5. **Run** the project with `F5`.

> ⚠️ Never commit real API keys or passwords. Use your own credentials locally.

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## 🔐 User Roles

| Role | Access |
|:---|:---|
| 👨‍💼 Admin | System, academic data and result management |
| 👩‍🏫 Teacher | Assignments, quizzes, NLP grading, results and feedback |
| 🎓 Student | Submissions, results and feedback |

Each role has its own secure login and dashboard.

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## ⚠️ Limitations & Future Work

**Current scope**
- Automatically evaluates **online Word-based (`.docx`) assignments and quizzes** using NLP and assigns marks with feedback
- Attendance, midterm and final marks are entered by the teacher; the system calculates total marks, GPA and grade automatically

**Limitations**
- Only online, text-based submissions are graded
- Plagiarism detection is not included yet

**Planned improvements:** domain-specific NLP tuning, plagiarism detection, advanced analytics, a mobile app and personalised AI recommendations.

<img src="https://capsule-render.vercel.app/api?type=rect&height=2&color=0:000000,50:58a6ff,100:000000" width="100%"/>

## 👤 Author

**Usama Shoaib**
BS Computer Science (2021-2025), University of Southern Punjab, Multan

<a href="https://github.com/Usamashoaibkhan"><img src="https://img.shields.io/badge/GitHub-Usamashoaibkhan-181717?style=for-the-badge&logo=github&logoColor=white"/></a>
<a href="https://www.linkedin.com/in/usama-shoaib-45a521259/"><img src="https://img.shields.io/badge/LinkedIn-Usama_Shoaib-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white"/></a>

<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&height=120&color=0:1f2a44,50:0d1117,100:000000&section=footer" width="100%" alt="footer"/>

</div>
