# AspNetTrainingOne

This is a training project to help orient new developers in our organization. Its purpose is to give a quick overview of some features that new developers might not have been exposed to yet.

The intent is to git pull a commit at a time so the developer can see the "evolution" of the code.

## 1. Initial Commit

The first commit is a "stock" ASP.Net (Framework, not Core) project created with Visual Studio 2019 using .Net Framework 4.7.2.

It has a simple Entity Framework Code First DbContext containing one entity - City.

It uses a Migration to create the database, create the table and populate the table with data using the Seed method.

## 2. Scaffolded Cities controller and views

A new controller was added (Cities) and used the "MVC 5 Controller with views, using Entity Framework" option. The only other change was the Cities was added to the top level menu in the \_Layout.cshtml in the Views\Shared folder.

## 3. Adding Telerik Kendo MVC UI 

A new controller was added (KendoCity) using the Kendo UI Scaffolder option. This demonstrates the Kendo grid with editing functionality.
This requires that you add a custom NuGet feed that Telerik provides as described here - https://docs.telerik.com/aspnet-mvc/getting-started/installation/nuget-install.
You should install Telerik.UI.for.AspNet.Mvc5.Trial, version 2020.1.114.

## 4. Adding Tenant Controller

In a multi-tenant system, each tenant's users should only see data for their tenant. Pretend that the states represent our tenants. If a user from Texas (TX) logged in, we only want to show them cities in Texas.

The Tenant Controller handles this, along with new routes in the App_Start\RouteConfig.cs file. We need the Tenant route to have a wildcard (the tenant alias - in this case, the state abbreviation), so we need to add hard-coded routes for the existing Home, Cities, and KendoCity controllers. This route will send requests to this URL - https://localhost:44358/TX to the Index action of the Tenant controller passing in "TX" as the tenant alias. The grid will only show cities with a state value of "TX".

Note the .Data("additionalInfo") added to the end of the .DataSource.Read line in the Grid definion. This calls the javascript function "additionalInfo" to get the extra argument value to filter the data.

If you substitute any 2 character state abbreviation that has data in the Seed method - you will simulate logging in as a user from that tenant and only see "their" data.