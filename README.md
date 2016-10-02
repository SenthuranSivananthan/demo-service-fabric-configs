# demo-service-fabric-configs
Service Fabric demo that outlines the various levels of application configuration settings.

In Service Fabric, you have the option to define application configuration in 3 areas:

1.  Service Configuration (located in `[ServiceProject]\PackageRoot\Config\Settings.xml`)
2.  Application Manifest (located in `[ApplicationProject]\ApplicationPackageRoot\ApplicationManifest.xml`)
3.  Application Parameters (located in `[ApplicationProject]\ApplicationParameters\*.xml`)

When your application & services start, configuration is loaded in the order they are defined above, in other words:

1.  Load Service Configuration - this is the baseline for configuration.
2.  Load Application Manifest - replace any configuration that has the same keys.
3.  Load Application Parameters - replace any configuration that has the same keys.

At the end of the configuration load, all settings are overlayed and the final configuration (including any overrides) are presented to the application.

You can access the configuration through:  `FabricRuntime.GetActivationContext().GetConfigurationPackageObject("Config")`

You can encrypt the configuration values and this is explained in [Azure Documentation](https://azure.microsoft.com/en-us/documentation/articles/service-fabric-application-secret-management/).
