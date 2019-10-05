# Martian Robots

[![Build Status](https://langsamu.visualstudio.com/MartianRobots/_apis/build/status/langsamu.MartianRobots?branchName=master)](https://langsamu.visualstudio.com/MartianRobots/_build/latest?definitionId=14&branchName=master)

## Online components
- [Web UI](https://martian-robots.azurewebsites.net/) (on Azure App Service)
- [Web API](https://martian-robots.azurewebsites.net/openapi) (Swagger UI)
- [Continuous deployment](https://langsamu.visualstudio.com/MartianRobots/_build?definitionId=14) (Azure DevOps)
- [Infrastructure](https://portal.azure.com/) (Azure, requires login)

## Source-code components

- [Class library](https://github.com/langsamu/MartianRobots/tree/master/MartianRobots)
- [Command-line interface](https://github.com/langsamu/MartianRobots/tree/master/MartianRobots.Cli)
- [Web interface](https://github.com/langsamu/MartianRobots/tree/master/MartianRobots.Web)
- [Tests](https://github.com/langsamu/MartianRobots/tree/master/MartianRobots.Test)
- [Availability monitoring](https://github.com/langsamu/MartianRobots/tree/master/MartianRobots.Availability)
- [Build pipeline](https://github.com/langsamu/MartianRobots/blob/master/azure-pipelines.yml)

### Notable commits

1. [Initial naive implementation](https://github.com/langsamu/MartianRobots/commit/ee8efe2c2b841bcf9e7d2297785ab9c7e1008883#diff-6275e95e0434c98ab8be9c2ee1f1d518)
2. [Extract functionality](https://github.com/langsamu/MartianRobots/compare/ee8efe2c2b841bcf9e7d2297785ab9c7e1008883...dd28d8ad2cf14832d7294e3c775ed67e5859a99f#diff-81ce25f780c31e8c34e0e0372abf5e29)
3. [Code maintainability improvements](https://github.com/langsamu/MartianRobots/commit/2a6acb8d1c79819ed5a3382ef2263d4c229ee687)
4. [Command-line interface](https://github.com/langsamu/MartianRobots/commit/f1b15602bc6c2206770465fa23ea7faacc0e3852#diff-0a162b9c8a9867f9ea1f9e418a4a3aab)
5. [Continuous deployment](https://github.com/langsamu/MartianRobots/commit/c2610af99b32caf28c88981df1c26ce181179722#diff-fec826feae04e51c0d94076385408bdc)
6. [User interface](https://github.com/langsamu/MartianRobots/commit/8c4e18934831130bf7fd6bae56d7165d9cb1b448#diff-77b89c254c96f3701bb78b34ebc4c6e8R20)
7. [Application programming interface](https://github.com/langsamu/MartianRobots/commit/993aade31e5e427e342e4bf5c7193990d5682825#diff-1d0876697fded8de5f659153c981f0caR20)
8. [Availability monitoring](https://github.com/langsamu/MartianRobots/commit/f70f5be9f0f1dec95c731a5585975fd0c3ca3c60)
