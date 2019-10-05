# Web interface

This folder contains an ASP.NET Core MVC project.

The web application is available at [martian-robots.azurewebsites.net](https://martian-robots.azurewebsites.net/).

It's deployed automatically by [this](https://langsamu.visualstudio.com/MartianRobots/_build?definitionId=14) Azure DevOps account based on [this](https://github.com/langsamu/MartianRobots/blob/master/azure-pipelines.yml) YAML build pipeline.

## UI
The application exposes a [simple form-based user interface](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots.Web/Controllers/DefaultController.cs#L29) for entering, parsing and executing commands as well as serialising the output.

## API
The application also exposes the same functionality over an [API](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots.Web/Controllers/ApiController.cs#L29).

The API is described by a [machine-readable specification](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots.Web/wwwroot/openapi.json) (see it [live](https://martian-robots.azurewebsites.net/openapi.json)).

The specification is rendered for documentation and testing purpose (see it [live](https://martian-robots.azurewebsites.net/openapi)).