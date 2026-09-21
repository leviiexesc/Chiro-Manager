# Roblox Account Manager

Roblox Account Manager is an independent, local-first Windows 10/11 application for organizing Roblox account profiles, public game shortcuts, launch history, and multi-launch planning.

> This project is an independent community application and is not affiliated with or endorsed by Roblox Corporation.

## Features

- Modern WinUI 3 navigation with Dashboard, Accounts, Multi Launch, Games, Servers, Activity, Favorites, Settings, and About pages.
- Local account metadata with public username lookup and optional favorites.
- DPAPI utility for Windows-protected local values.
- Async operations with cancellation support and user-visible error states.
- Safe launching through ordinary Roblox public URLs; no cookie, token, password, or credential extraction.
- Windows x64 GitHub Actions build and tagged release packaging.

## Security

The application deliberately does not import, extract, display, log, transmit, or manage Roblox authentication cookies, session tokens, passwords, authentication headers, captcha-solving keys, or private-server credentials. It does not bypass platform protections or expose a local web API for account control. Local data is stored under the current user's Local Application Data directory.

## Requirements

- Windows 10 version 1809 or later, or Windows 11
- .NET 8 SDK
- Visual Studio 2022 with the Windows App SDK / WinUI 3 tooling

## Building

```powershell
dotnet restore RobloxAccountManager.sln
dotnet build RobloxAccountManager.sln --configuration Release --platform x64
dotnet test tests/RobloxAccountManager.Tests/RobloxAccountManager.Tests.csproj --configuration Release
dotnet publish src/RobloxAccountManager/RobloxAccountManager.csproj --configuration Release --runtime win-x64
```

## GitHub Actions

`build.yml` restores, builds, tests, publishes, packages, and uploads a Windows x64 artifact. `release.yml` performs the same verification for tags such as `v1.0.0` and attaches the ZIP to a GitHub Release.

## Architecture

- `Models`: account, game, and activity records.
- `ViewModels`: CommunityToolkit.Mvvm state and commands.
- `Services`: local persistence, public Roblox lookup, launching, and DPAPI support.
- `Views`: separate WinUI pages for each navigation destination.

## Original project review

The original repository was a legacy WinForms application using INI/JSON files, RestSharp, CefSharp/Puppeteer browser automation, a localhost web API, direct `.ROBLOSECURITY` cookie handling, multi-instance launch techniques, and several developer utilities. The implementation checklist is recorded in `docs/original-feature-disposition.md`. This rebuild keeps benign organization and public metadata workflows, modernizes them for WinUI/MVVM, and removes credential extraction, token display/export, captcha automation, exploit-oriented integrations, and unsupported security-bypass behavior.

## Screenshots

Screenshots will be added after the first Windows App SDK build is available.

## License

See `LICENSE`.
