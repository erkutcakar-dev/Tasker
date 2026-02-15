<p align="center">
  <img src="https://img.shields.io/badge/.NET%20MAUI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET MAUI" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=xaml&logoColor=white" alt="XAML" />
  <img src="https://img.shields.io/badge/Platform-Android%20%7C%20iOS%20%7C%20Windows%20%7C%20macOS-blue?style=for-the-badge" alt="Platforms" />
</p>

<h1 align="center">Tasker</h1>

<p align="center">
  <strong>A beautiful, cross-platform task management app built with .NET MAUI</strong>
</p>

<p align="center">
  Organize your life with categories, track your progress visually, and stay on top of what matters.
</p>

---

## Screenshots

<p align="center">
  <img src="Screenshots/main_view.png" width="280" alt="Main View" />
  &nbsp;&nbsp;&nbsp;
  <img src="Screenshots/add_task.png" width="280" alt="Add New Task" />
  &nbsp;&nbsp;&nbsp;
  <img src="Screenshots/progress.png" width="280" alt="Progress Tracking" />
</p>

> **Note:** Place your screenshots in the `Screenshots/` folder with the filenames above, or update the paths accordingly.

---

## Features

- **Category-Based Organization** -- Group your tasks into custom categories, each with its own unique color for instant recognition.
- **Visual Progress Tracking** -- Each category card displays a dynamic progress bar that fills up as you complete tasks, giving you a satisfying sense of accomplishment at a glance.
- **Interactive Task Completion** -- Check off tasks with color-coded checkboxes. Completed tasks are visually struck through so you can focus on what's left.
- **Add Tasks On-The-Fly** -- Quickly add new tasks through a clean, dedicated page. Select a category, type your task, and you're done.
- **Create Custom Categories** -- Need a new category? Create one instantly with a randomly generated accent color.
- **Real-Time Updates** -- Task counts and progress bars update in real time as you check or uncheck tasks.
- **Cross-Platform** -- Runs natively on Android, iOS, Windows, and macOS from a single codebase.

---

## Architecture

Tasker follows the **MVVM (Model-View-ViewModel)** architectural pattern for clean separation of concerns:

```
Tasker/
├── MVVM/
│   ├── Models/
│   │   ├── Category.cs          # Category data model with INotifyPropertyChanged
│   │   └── MyTask.cs            # Task data model with INotifyPropertyChanged
│   ├── Views/
│   │   ├── MainView.xaml/.cs    # Home screen with categories & task list
│   │   └── NewTaskView.xaml/.cs # Add new tasks & categories
│   └── ViewModels/
│       ├── MainViewModel.cs     # Core logic, data management & live updates
│       └── NewTaskViewModel.cs  # New task page state
├── Converters/
│   └── ColorConverter.cs        # Hex string → MAUI Color converter
├── Resources/
│   └── Styles/
│       ├── AppStyle.xaml        # Custom card, button & typography styles
│       ├── Colors.xaml          # Theme color definitions
│       └── Styles.xaml          # Global control styles
└── MauiProgram.cs               # App bootstrap & platform config
```

---

## Tech Stack

| Layer | Technology |
|---|---|
| **Framework** | .NET 9.0 / .NET MAUI |
| **Language** | C# |
| **UI Markup** | XAML |
| **Pattern** | MVVM |
| **Data Binding** | PropertyChanged.Fody (auto-implemented `INotifyPropertyChanged`) |
| **Collections** | `ObservableCollection<T>` with `CollectionChanged` events |
| **Platforms** | Android 21+, iOS 15+, Windows 10+, macOS (Catalyst) |

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022 17.8+](https://visualstudio.microsoft.com/) with the **.NET MAUI workload** installed
- For Android: Android SDK (API 21+)
- For iOS/macOS: Xcode 15+ (macOS only)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/yourusername/Tasker.git
   cd Tasker
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Run the app**

   ```bash
   # Windows
   dotnet build -t:Run -f net9.0-windows10.0.19041.0

   # Android
   dotnet build -t:Run -f net9.0-android

   # iOS (macOS only)
   dotnet build -t:Run -f net9.0-ios

   # macOS
   dotnet build -t:Run -f net9.0-maccatalyst
   ```

   Or simply press **F5** in Visual Studio with your target platform selected.

---

## How It Works

### Main View

The home screen is divided into two sections:

1. **Category Cards** -- Horizontally scrollable cards showing each category's name, pending task count, and a color-coded progress bar.
2. **Pending Tasks List** -- A vertical list of all tasks with interactive checkboxes. Checking a task instantly updates the category progress bar and task count above.

### Adding Tasks & Categories

Tap the **+** button to navigate to the task creation screen where you can:

- Type a new task name
- Select a category via radio buttons
- Add an entirely new category with a custom name and auto-generated color

---

## Key Implementation Details

- **PropertyChanged.Fody** -- Eliminates boilerplate `INotifyPropertyChanged` code. The `[AddINotifyPropertyChangedInterface]` attribute automatically weaves property change notifications at compile time.
- **ColorConverter** -- A custom `IValueConverter` that transforms hex color strings (e.g. `#CF14DF`) into native `Microsoft.Maui.Graphics.Color` objects, enabling dynamic color theming throughout the UI.
- **Data Triggers** -- XAML `DataTrigger` on task labels automatically applies strikethrough styling and muted colors when a task is marked as completed.
- **ObservableCollection Events** -- The `Tasks.CollectionChanged` event ensures that adding or removing tasks triggers an automatic data refresh across all category cards.

---

## License

This project is open source and available under the [MIT License](LICENSE).

---<img width="446" height="994" alt="main_view" src="https://github.com/user-attachments/assets/6665d325-1144-4d94-a01e-9c764c5ad58f" />
<img width="439" height="995" alt="add_task" src="https://github.com/user-attachments/assets/f4001af1-a28d-4a35-b4a8-9d1a6c81e702" />
<img width="445" height="992" alt="progress" src="https://github.com/user-attachments/assets/be8f7b92-0bea-4e2d-9cf8-1be1a33acec0" />


<p align="center">
  Built with passion using <strong>.NET MAUI</strong>
</p>
