# Availability Monitoring

This folder contains a WebTest project.

[Availability.webtest](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots.Availability/Availability.webtest) is used for availability monitoring of the web application using Azure Application Insights.

## Monitoring results
Available [on the Azure portal](https://portal.azure.com/#resource/subscriptions/d40c53cc-9981-4d98-a471-35df02d0bdc7/resourceGroups/MartianRobots/providers/microsoft.insights/components/martian-robots/availability) (requires login).

## Monitored requests
The test contains the following requests:
- API GET
- API GET reports 400 for bad data
- API POST with form parameters
- API POST with form parameters reports 400 for bad data
- API POST with request body
- API POST with request body reports 400 for bad data
- Swagger UI
- OpenApi document
- UI home
- UI POST
- UI POST with bad data reports 400 for bad data
