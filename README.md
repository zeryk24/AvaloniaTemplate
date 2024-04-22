# Avalonia Template Project

This is a starter template for an Avalonia application with basic features like navigation, settings integration, and hot reload enabled.

## Getting Started

### Prerequisites

Make sure you have [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0) and [Avalonia UI](https://avaloniaui.net/) installed on your system.

### Installation

Just clone this repository to your local machine.

### Features

#### Basic navigation

The template includes basic navigation setup using **Avalonia Simple Router**. You can find more info about it here: [Avalonia simple router](https://github.com/sandreas/Avalonia.SimpleRouter)

#### AppSettings.json integration

You can use appsetings.json with Microsoft.Extensions.Configuration.Json however you need to on every platform.

#### Hot reload

The project is configured to support hot reload for XAML on desktop. Simply make changes to XAML files and see them reflected instantly in the running application without restarting. To make this possible is used awesome package [HotAvalonia](https://github.com/Kir-Antipov/HotAvalonia). In the current version it works only for desktop, so you need to comment marked line in app.axaml.cs if you want to debug other platform.

## License

This project is licensed under the MIT License.
