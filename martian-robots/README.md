# Rust 

[![Build Status](https://langsamu.visualstudio.com/MartianRobots/_apis/build/status/Build%20Rust?branchName=master)](https://langsamu.visualstudio.com/MartianRobots/_build/latest?definitionId=19&branchName=master)

This folder contains a Rust Hyper web application.

## Online components
- [Web UI](https://martian-robots.azurewebsites.net/rust) (on Azure App Service container)
- [Continuous deployment](https://langsamu.visualstudio.com/MartianRobots/_build?definitionId=19) (Azure DevOps)
- [Infrastructure](https://portal.azure.com/) (Azure, requires login)

## Source-code components
- [Rust source](https://github.com/langsamu/MartianRobots/blob/master/martian-robots/src/main.rs)
- [Rust package manifest](https://github.com/langsamu/MartianRobots/blob/master/martian-robots/Cargo.toml)
- [Web-server configuration](https://github.com/langsamu/MartianRobots/blob/master/martian-robots/wwwroot/web.config)
- [Build pipeline](https://github.com/langsamu/MartianRobots/blob/master/martian-robots/azure-pipelines.yml)
