# Original Feature Disposition

| Original feature | Disposition | Rebuild decision |
| --- | --- | --- |
| Account list, aliases, groups, sorting | Modernize | Local account cards, display labels, search, favorites, and MVVM state. |
| Local account file encryption | Modernize | Use Windows DPAPI for supported local secrets; no raw auth material is accepted. |
| Public user metadata and avatars | Keep | Use official/public endpoints with async failure states. |
| Recent games and favorites | Keep | Store non-sensitive game metadata locally. |
| Standard game launching | Modernize | Open public Roblox URLs through the user's normal Roblox/browser session. |
| Multi Roblox / repeated process launching | Replace | Multi Launch plans and opens supported public URLs; no mutex bypass or ticket construction. |
| Server list and player counts | Modernize | Public server information only, with retry/error states and no private-server access. |
| `.ROBLOSECURITY` import/export and cookie refresh | Remove | Credential/session-token extraction and handling are intentionally unsupported. |
| Password storage, Quick Log In, auth tickets, CSRF tokens | Remove | No credential harvesting, token display, or authentication-material workflows. |
| Embedded browser automation and proxy support | Remove | Avoid account impersonation, stealth automation, and proxy credential risk. |
| Local web API / Lua account-control protocol | Remove | No remote account-control surface or dangerous script integration. |
| Captcha-solving integration | Remove | Do not automate or outsource security challenges. |
| FPS unlocker, watcher, exploit-adjacent utilities | Remove | Outside legitimate account organization scope and potentially unsafe. |
| Theme editor and WinForms UI | Replace | WinUI 3 Fluent shell, theme resources, responsive navigation, and accessible controls. |
| Auto-updater | Modernize | Prefer GitHub Releases and signed/managed deployment in a later milestone. |
